$(document).on("click", ".minunupp", function () {
    $(this).css({ color: 'red' });
})

$(document).on('click', '.sortnupp', function () {
    var $nupp = $(this);
    var d = $nupp.data();
    var colnum = d.colnum;
    var isnumber = d.type && d.type === 'num';

    simpleSort($(this), colnum, isnumber);
});


function simpleSort($actor, colIndex, isNumeric) {
    var $tbody = $actor.closest('table').find('tbody');
    var rows = $tbody.find('tr').get();

    rows.sort(function (a, b) {
        var $a = $(a).children().eq(colIndex);
        var $b = $(b).children().eq(colIndex);

        var va = $a.text().trim();
        var vb = $b.text().trim();

        if (isNumeric) {
            va = parseFloat(va.replace(',', '.')) || 0;
            vb = parseFloat(vb.replace(',', '.')) || 0;
            return va - vb;              // numbriline
        } else {
            return va.localeCompare(vb);  // tekstiline
        }
    });

    $.each(rows, function (_, row) {
        $tbody.append(row); // tõstab read uues järjekorras tagasi
    });
}


$(document).on('click', '.editview', function () {
    var $td = $(this).closest('td');
    var val = $(this).html();
    $(this).hide();
    $td.find('.viewedit').show().find('input').focus().select();
});

$(document).on('keydown', '.viewedit', function (e) {
    if (e.key === 'Enter') {
        var $td = $(this).closest('td');
        var d = $td.data();
        var val =  $(this).find('input').val();
        $.ajax({
            url: '/home/change',
            method:'POST',
            data: { tabel: d.class, field : d.field, value: val, id: d.id},
            success: function () {
                $td.find('.editview').html(val);
                $td.find('.viewedit').hide();
                $td.find('.editview').show();
            },
            error: function () {
                alert("midaagi läks nihu");
            } 
        });


    }
    if (e.key === 'Escape') {
        $(this).hide();
        $(this).closest('td').find('.editview').show();

    }
})