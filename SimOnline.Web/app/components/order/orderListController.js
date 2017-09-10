(function (app) {
    app.controller('orderListController', orderListController);

    orderListController.$inject = ['$scope'];

    function orderListController($scope) {
        console.log(1111111111111);
    };
})(angular.module('simonline.order'));