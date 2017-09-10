(function (app) {
    app.service('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        function displaySuccess(message) {
            toastr.success(message);
        }

        function displayInfo(message) {
            toastr.info(message);
        }

        function displayWarning(message) {
            toastr.warning(message);
        }

        function displayError(message) {
            if (Array.isArray(message)) {
                message.each(function (mes) {
                    toastr.error(mes);
                });
            } else {
                toastr.error(message);
            }
        }

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayInfo: displayInfo,
            displayWarning: displayWarning
        };
    };
})(angular.module('simonline.common'));