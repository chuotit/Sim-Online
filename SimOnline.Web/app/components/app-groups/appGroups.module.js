(function () {
    angular.module('simonline.appGroups', ['simonline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('app-groups', {
                url: '/app-groups',
                parent: 'base',
                template: '<div ui-view></div>',
                abstract: true,
                ncyBreadcrumb: {
                    label: 'Nhóm người dùng',
                    parent: 'dashboard'
                }
            })
            .state('app-groups.list', {
                parent: 'app-groups',
                url: '/list',
                templateUrl: '/app/components/app-groups/appGroupListView.html',
                controller: 'appGroupListController',
                ncyBreadcrumb: {
                    label: 'Danh sách nhóm người dùng',
                    parent: 'app-groups'
                }
            })
            .state('app-groups.add', {
                parent: 'app-groups',
                url: '/add',
                templateUrl: '/app/components/app-groups/appGroupAddView.html',
                controller: 'appGroupAddController',
                ncyBreadcrumb: {
                    label: 'Thêm nhóm người dùng',
                    parent: 'app-groups'
                }
            })
            .state('app-groups.edit', {
                parent: 'app-groups',
                url: '/edit/:id',
                templateUrl: '/app/components/app-groups/appGroupEditView.html',
                controller: 'appGroupEditController',
                ncyBreadcrumb: {
                    label: 'Sửa nhóm người dùng',
                    parent: 'app-groups'
                }
            });
    }
})();