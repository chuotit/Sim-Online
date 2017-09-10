(function () {
    angular.module('simonline.auth', ['simonline.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('auth.login', {
                parent: 'auth',
                url: '/login',
                templateUrl: '/app/components/auth/loginView.html',
                controller: 'loginController'
            })
            .state('auth.forgot-password', {
                parent: 'auth',
                url: '/forgot-password',
                templateUrl: '/app/components/auth/forgotPasswordView.html',
                controller: 'forgotPasswordController'
            })
            .state('auth.reset-password', {
                parent: 'auth',
                url: '/reset-password?UserId&code',
                templateUrl: '/app/components/auth/resetPasswordView.html',
                controller: 'resetPasswordController'
            })
    }
})();