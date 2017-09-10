(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService'];

    function rootController($state, authData, loginService, $scope, authenticationService) {
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('auth.login');
        }
        $scope.authentication = authData.authenticationData;
        authenticationService.validateRequest();
    }
})(angular.module('simonline'));