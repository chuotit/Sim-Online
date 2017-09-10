(function () {
    angular.module('simonline', ['simonline.simStores', 'simonline.appUsers', 'simonline.appRoles', 'simonline.appGroups', 'simonline.order', 'simonline.auth', 'simonline.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']
    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        //$locationProvider.hashPrefiKx(''); // by default '!'
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('auth', {
                url: '/auth',
                templateUrl: '/app/components/auth/authView.html',
                controller: 'authController'
            })
            .state('dashboard', {
                parent: 'base',
                url: '/dashboard',
                templateUrl: '/app/components/dashboard/dashboardView.html',
                controller: 'dashboardController',
                ncyBreadcrumb: {
                    label: 'Home'
                }
            });
            $urlRouterProvider.otherwise('/auth/login');
    };

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status === "401") {
                        $location.path('/auth/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status === "401") {
                        $location.path('/auth/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();