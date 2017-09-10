(function () {
	angular.module('simonline.order', ['simonline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
    	$stateProvider
            .state('order', {
            	parent: 'base',
            	url: '/order',
            	template: '<div ui-view></div>',
            	abstract: true
            })
            .state('order.list', {
            	parent: 'order',
            	url: '/list',
            	templateUrl: '/app/components/order/orderListView.html',
            	controller: 'orderListController'
            });
        };
})();