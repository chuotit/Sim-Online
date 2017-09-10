(function (app) {
    app.controller('forgotPasswordController', ['$scope', '$injector', 'apiService', 'loginService', 'notificationService',
        function ($scope, $injector, apiService, loginService, notificationService) {
            $scope.forgotPasswordData = {
                email: ''
            };
            $scope.isSubmited = false;

            $scope.forgotPasswordSubmit = forgotPasswordSubmit;
            function forgotPasswordSubmit() {
                apiService.post('/api/account/forgot-password', $scope.forgotPasswordData, function (success) {
                    $scope.isSubmited = true;
                    console.log($scope.isSubmited);
                }, function (error) {
                    notificationService.displayError(error.data.Message);
                });
            }
        }]);
})(angular.module('simonline'));