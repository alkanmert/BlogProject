
jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    'locale-compare-asc': function (a, b) {
        return a.localeCompare(b, 'cs', {
            sensitivity: 'case'
        })
    },
    'locale-compare-desc': function (a, b) {
        return b.localeCompare(a, 'cs', {
            sensitivity: 'case'
        })
    }
})

jQuery.fn.dataTable.ext.type.search['locale-compare'] = function (data) {
    return TurkishCharacter(data);
}

function TurkishCharacter(data) {
    return !data ?
        '' :
        typeof data === 'string' ?
            data
                .replace(/\n/g, ' ')
                .replace(/[��]/g, '�')
                .replace(/[��]/g, '�')
                .replace(/[i�]/g, 'i')
                .replace(/[��]/g, '�')
                .replace(/[��]/g, '�')
                .replace(/[��]/g, '�')
                .replace(/[�I]/g, '�') :
            data
}

var table = $('#articlesTable').DataTable({
    columnDefs: [{
        targets: 1,
        type: 'locale-compare'
    },]
})

$('#articlesTable input').keyup(function () {
    table
        .search(
            jQuery.fn.dataTable.ext.type.search.string(TurkishCharacter(this.value))
        )
        .draw()
})