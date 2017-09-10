(function () {
    angular.module('simonline.appRoles', ['simonline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('app-roles', {
                parent: 'base',
                url: '/app-roles',
                template: '<div ui-view></div>',
                abstract: true,
                ncyBreadcrumb: {
                    label: 'Phân quyền',
                    parent: 'dashboard'
                }
            })
            .state('app-roles.add', {
                parent: 'app-roles',
                url: '/add',
                templateUrl: '/app/components/app-roles/appRoleAddView.html',
                controller: 'appRoleAddController',
                ncyBreadcrumb: {
                    label: 'Thêm mới',
                    parent: 'app-roles'
                }
            })
            .state('app-roles.list', {
                parent: 'app-roles',
                url: '/list',
                templateUrl: '/app/components/app-roles/appRoleListView.html',
                controller: 'appRoleListController',
                ncyBreadcrumb: {
                    label: 'Danh sách phân quyền',
                    parent: 'app-roles'
                }
            })
            .state('app-roles.edit', {
                parent: 'app-roles',
                url: '/edit/:id',
                templateUrl: '/app/components/app-roles/appRoleEditView.html',
                controller: 'appRoleEditController',
                ncyBreadcrumb: {
                    label: 'Sửa phân quyền',
                    parent: 'app-roles'
                }
            });
    }
})();