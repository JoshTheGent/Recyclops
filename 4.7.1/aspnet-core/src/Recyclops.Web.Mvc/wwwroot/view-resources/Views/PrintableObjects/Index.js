
$("#PrintableObjectTable").DataTable({
    "language": {
        emptyTable: "No Content to Display",
        search: "_INPUT_",
        searchPlaceholder: "Search",
        paginate: {
            first: "<i class='fa fa-step-backward'></i>",
            previous: "<i class='fa fa-caret-left'></i>",
            next: "<i class='fa fa-caret-right'></i>",
            last: "<i class='fa fa-step-forward'></i>"
        }
    },
    "columnDefs": [{ targets: 'no-sort', orderable: false }],
    "order": [[1, "asc"]]
});


$("#addButton").on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: abp.appPath + "PrintableObject/LoadForm",
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
        url: abp.appPath + "PrintableObject/LoadForm?id=" + tagId,
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
        abp.utils.formatString(abp.localization.localize("AreYouSureWantToDelete", "Recyclops"), "this Printable Object"),
        function (isConfirmed) {
            if (isConfirmed) {
                abp.ajax({
                    url: "PrintableObject/Delete",
                    dataType: "json",
                    contentType: 'application/x-www-form-urlencoded',
                    data: { id: tagId },
                    success: function () {
                        location.reload(true);
                    },
                    error: function (e) {
                        abp.notify.error('Error: ' + e);
                    }
                });
            }
        }
    );
});
