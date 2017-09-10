(function (app) {
    app.controller('loginController', ['$scope', '$injector', 'loginService', 'notificationService',
        function ($scope, $injector, loginService, notificationService) {

            $scope.loginData = {
                userName: '',
                password: ''
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        notificationService.displayError('Thông tin đăng nhập không đúng');
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('dashboard');
                    }
                });
            }
        }]);
})(angular.module('simonline'));