(function ($) {
    var _$modal = $("#PlasticSpoolForm");
    var _$form = $('form[name=createForm]');


    $(".save-button").on("click",
        function (e) {
            e.preventDefault();
            abp.ui.setBusy(_$modal);
            if (!_$form.valid()) {
                abp.ui.clearBusy(_$modal);
                return;
            }

            $.ajax({
                url: "PlasticSpool/Create",
                method: "POST",
                dataType: "json",
                data: $("#PlasticSpoolForm").serialize(),
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