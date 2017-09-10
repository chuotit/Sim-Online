(function (app) {
    app.controller('resetPasswordController', ['$scope', '$injector', '$stateParams', 'apiService', 'loginService', 'notificationService',
        function ($scope, $injector, $stateParams, apiService, loginService, notificationService) {
            $scope.resetPasswordData = {
                Password: '',
                ConfirmPassword: '',
                UserId: $stateParams.UserId,
                Code: $stateParams.code
            };
            $scope.isSubmited = false;

            $scope.resetPasswordSubmit = resetPasswordSubmit;
            function resetPasswordSubmit() {
                apiService.post('/api/account/reset-password', $scope.resetPasswordData, function (success) {
                    $scope.isSubmited = true;
                    console.log($scope.isSubmited);
                }, function (error) {
                    notificationService.displayError(error.data.Message);
                });
            }
        }]);
})(angular.module('simonline'));