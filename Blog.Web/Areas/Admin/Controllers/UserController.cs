using AutoMapper;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Entity.ViewModels.Users;
using Blog.Web.ResultMessages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IToastNotification toast;

        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IToastNotification toast,IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.toast = toast;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<ViewUser>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join(" ",await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new ViewUserAdd { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ViewUserAdd viewUserAdd)
        {
            var map = mapper.Map<AppUser>(viewUserAdd);
            var roles = await roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = viewUserAdd.Email;
                var result = await userManager.CreateAsync(map, viewUserAdd.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(viewUserAdd.RoleId.ToString());
                    await userManager.AddToRoleAsync(map,findRole.ToString());
                    toast.AddSuccessToastMessage(Messages.User.Add(viewUserAdd.Email), new ToastrOptions() { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                        ModelState.AddModelError("", errors.Description);

                    return View(new ViewUserAdd { Roles = roles });
                }
            }
            return View(new ViewUserAdd { Roles = roles }); 
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            var roles = await roleManager.Roles.ToListAsync();

            var map = mapper.Map<ViewUserUpdate>(user);
            map.Roles = roles;
            
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ViewUserUpdate viewUserUpdate)
        {
            var user = await userManager.FindByIdAsync(viewUserUpdate.Id.ToString());
            if(user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if(ModelState.IsValid)
                {
                    mapper.Map(viewUserUpdate, user);
                    //user.FirstName = viewUserUpdate.FirstName;
                    //user.LastName = viewUserUpdate.LastName;
                    //user.Email = viewUserUpdate.Email;
                    //user.PhoneNumber = viewUserUpdate.PhoneNumber;
                    //user.UserName = viewUserUpdate.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await roleManager.FindByIdAsync(viewUserUpdate.RoleId.ToString());
                        await userManager.AddToRoleAsync(user, findRole.Name);
                        toast.AddSuccessToastMessage(Messages.User.Update(viewUserUpdate.Email), new ToastrOptions() { Title = "İşlem Başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                            ModelState.AddModelError("", errors.Description);

                        return View(new ViewUserUpdate { Roles = roles });
                    }
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.Errors)
                    ModelState.AddModelError("", errors.Description);
            }
            return NotFound();
        }
    }
}
