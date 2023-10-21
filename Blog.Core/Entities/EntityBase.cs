using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {

        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? UpdatedDate { get; set; }

    }
}
