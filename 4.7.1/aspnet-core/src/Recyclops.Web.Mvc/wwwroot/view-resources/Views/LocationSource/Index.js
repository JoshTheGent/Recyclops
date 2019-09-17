

$("#addButton").on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: abp.appPath + "LocationSource/LoadForm",
        type: "GET",
        contentType: "application/html",
        success: function (content) {
            $("#modal").modal("show");
            $("#modal div.modal-content").html(content);
        },
        error: function (e) {
            abp.notify.error('Error: ' + e);
        }
    });
});

$("#tableContainer").on('click', ".edit-tag", function (e) {
    var tagId = $(this).attr("data-tag-id");
    e.preventDefault();
    $.ajax({
        url: abp.appPath + "LocationSource/LoadForm?id=" + tagId,
        type: "GET",
        contentType: "application/html",
        success: function (content) {
            $("#modal").modal("show");
            $("#modal div.modal-content").html(content);
        },
        error: function (e) {
            abp.notify.error('Error: ' + e);
        }
    });
});

$("#tableContainer").on('click', ".delete-tag", function () {
    var tagId = $(this).attr("data-tag-id");
    abp.message.confirm(
        abp.utils.formatString(abp.localization.localize("AreYouSureWantToDelete", "Recyclops"), "this Location Source"),
        function (isConfirmed) {
            if (isConfirmed) {
                abp.ajax({
                    url: "LocationSource/Delete",
                    dataType: "json",
                    contentType: 'application/x-www-form-urlencoded',
                    data: { id: tagId },
                    success: function () {
                        LoadTable();
                    },
                    error: function (e) {
                        abp.notify.error('Error: ' + e);
                    }
                });
            }
        }
    );
});
