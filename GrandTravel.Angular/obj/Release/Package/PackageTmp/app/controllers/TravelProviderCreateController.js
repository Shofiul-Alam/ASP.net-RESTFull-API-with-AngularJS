angular.module('grandTravelApp').controller('TravelProviderCreateController', ['$scope', 'TravelProviderService',

    function ($scope, TravelProviderService) {

        $scope.TravelProvider = {};


        $scope.create = function ()
        {
            TravelProviderService.createTravelProvider($scope.TravelProvider).then(function (response) {
                alert("Travel Provider was created");
            });
        }


    }]);