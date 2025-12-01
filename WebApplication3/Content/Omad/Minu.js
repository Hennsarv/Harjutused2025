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

$(document).on('change', '.pildinupp' , function () {
    var file = this.files[0];
    if (file) {
        var url = URL.createObjectURL(file);
        $(this).closest('.pildigrupp').find('.piltise').attr('src', url);
        $(this).closest('.pildigrupp').find('.vahetapilt').show();
    }
});

$(document).on('click', '.vajutatavpilt', function () {
    $(this).closest('.pildigrupp').find('.pildinupp').click();
});

$(document).on('click', '.vahetapilt', function () {
    var $pg = $(this).closest('.pildigrupp');
    if ($pg && $pg.length > 0) {
        var d = $pg.data();
        var id = d.id;
        var file = $pg.find('input')[0].files[0];
        var fd = new FormData();
        fd.append('id', id);
        fd.append('file', file);
        $.ajax({
            url: '/Categories/ChangePicture',
            type: 'POST',
            data: fd,
            processData: false,
            contentType: false,
            success: function () {
                $pg.find('.vahetapilt').hide();

            },
            error: function () {
                $pg.find('.vahetapilt').css({ 'background-color': 'red' }).text("MISKI VIGA!");
            }
        });

    }

});

