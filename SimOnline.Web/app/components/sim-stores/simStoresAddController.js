(function (app) {
    app.controller('simStoresAddController', simStoresAddController);

    simStoresAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];
    function simStoresAddController($scope, apiService, notificationService, $state) {
        $scope.listSimInfo = [];
        $scope.AddSimNumber = AddSimNumber;
        function AddSimNumber() {
            if ($scope.listSimInput) {
                var simItems = $scope.listSimInput.split(/\n|\r/);

                // Collect list sim error
                var listSimError = [];
                for (var i = 0; i < simItems.length; i++) {
                    var num = simItems[i].split('\t');
                    console.log(num[0].replace('.', '').replace('.', ''));
                    $scope.listSimInfo.push({'SimName': num[0], 'Price': num[1]});
                }
                //var jsonSimError = $.toJSON(listSimError);
                //console.log(jsonSimError);

                apiService.post('/api/simnumber/createmultipe', $scope.listSimInfo, function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới thành công.');
                    $state.go('sim-networks');
                }, function (error) {
                    console.log($scope.simNetwork);
                    notificationService.displayError('Thêm mới không thành công');
                });
                $scope.listSimInfo = [];
            }

        }
    };
})(angular.module('simonline.simStores'));