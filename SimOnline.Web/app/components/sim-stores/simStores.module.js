(function () {
    angular.module('simonline.simStores', ['simonline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('sim-stores', {
                parent: 'base',
                url: '/sim-stores',
                template: '<div ui-view></div>',
                abstract: true,
                ncyBreadcrumb: {
                    label: 'Kho sim',
                    parent: 'dashboard'
                }
            })
            .state('sim-stores.add', {
                parent: 'sim-stores',
                url: '/add',
                templateUrl: '/app/components/sim-stores/simStoresAddView.html',
                controller: 'simStoresAddController',
                ncyBreadcrumb: {
                    label: 'Thêm mới',
                    parent: 'sim-stores'
                }
            })
            .state('sim-stores.list', {
                parent: 'sim-stores',
                url: '/list',
                templateUrl: '/app/components/sim-stores/simStoresListView.html',
                controller: 'simStoresListController',
                ncyBreadcrumb: {
                    label: 'Tìm sim',
                    parent: 'sim-stores'
                }
            });
            //// Specify HTML5 mode (using the History APIs) or HashBang syntax.
            //$locationProvider.html5Mode(false).hashPrefix('!');
    };
})();