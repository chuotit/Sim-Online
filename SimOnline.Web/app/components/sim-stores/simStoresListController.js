(function (app) {
    app.controller('simStoresListController', simStoresListController);

    simStoresListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function simStoresListController($scope, apiService, notificationService) {
        $scope.listSimStores = [];
        $scope.keyword = '';
        $scope.consignerId = null;
        $scope.networkId = null;
        $scope.minPrice = null;
        $scope.maxPrice = null;
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.pagesCount = 0;

        $scope.getSimStores = getSimStores;
        function getSimStores(page) {
            page = page || 1;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    consignerId: $scope.consignerId,
                    networkId: $scope.networkId,
                    minPrice: $scope.minPrice,
                    maxPrice: $scope.maxPrice,
                    page: page,
                    pagesize: $scope.pageSize
                }
            };

            apiService.get('http://localhost:49865/api/simnumber/search', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào!');
                } else {
                    $scope.listSimStores = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;
                    //notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi!');
                }

            }, function () {
                console.log('Load data failed.');
            });
        };
        $scope.getSimStores();

        $scope.search = search;
        function search() {
            getSimStores();
        }

        loadSimNetworks();
        function loadSimNetworks() {
            apiService.get('http://localhost:49865/api/simnetwork/getall', null, function (result) {
                $scope.simNetworks = result.data;
            }, function () {
                console.log('Load data failed.');
            });
        };
        loadConsigners();
        function loadConsigners() {
            apiService.get('http://localhost:49865/api/consigner/getall', null, function (result) {
                $scope.consigners = result.data;
            }, function () {
                console.log('Load data failed.');
            });
        };
    };
})(angular.module('simonline.simStores'));