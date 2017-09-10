(function () {
    angular.module('simonline.appUsers', ['simonline.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('app-users', {
                url: '/app-users',
                parent: 'base',
                template: '<div ui-view></div>',
                abstract: true,
                ncyBreadcrumb: {
                    label: 'Người dùng',
                    parent: 'dashboard'
                }
            })
            .state('app-users.list', {
                parent: 'app-users',
                url: '/list',
                templateUrl: '/app/components/app-users/appUserListView.html',
                controller: 'appUserListController',
                ncyBreadcrumb: {
                    label: 'Danh sách người dùng',
                    parent: 'app-users'
                }
            })
            .state('app-users.add', {
                parent: 'app-users',
                url: '/add',
                templateUrl: '/app/components/app-users/appUserAddView.html',
                controller: 'appUserAddController',
                ncyBreadcrumb: {
                    label: 'Thêm người dùng mới',
                    parent: 'app-users'
                }
            })
            .state('app-users.edit', {
                parent: 'app-users',
                url: '/edit/:id',
                templateUrl: '/app/components/app-users/appUserEditView.html',
                controller: 'appUserEditController',
                ncyBreadcrumb: {
                    label: 'Sửa người dùng',
                    parent: 'app-users'
                }
            });
    }
})();