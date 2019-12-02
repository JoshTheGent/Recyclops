(function ($) {
    var _$modal = $("#OrderForm");
    var _$form = $('form[name=createForm]');

    $(".js-example-basic-multiple").select2({
        theme: "classic",
        width: 'resolve' // need to override the changed default
    });
    


    $(".save-button").on("click",
        function (e) {
            e.preventDefault();
            abp.ui.setBusy(_$modal);
            if (!_$form.valid()) {
                abp.ui.clearBusy(_$modal);
                return;
            }

            $.ajax({
                url: "Order/Create",
                method: "POST",
                dataType: "json",
                data: $("#OrderForm").serialize(),
                success: function () {
                    $("#modal").modal("hide");
                    location.reload(true);
                },
                error: function (e) {
                    abp.notify.error('Error: ' + e);
                }
            }).always(function () {
                abp.ui.clearBusy(_$modal);

            });
        });


})(jQuery);