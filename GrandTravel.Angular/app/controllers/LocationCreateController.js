angular.module('grandTravelApp').controller('LocationCreateController', ['$scope', 'LocationService',

    function ($scope, LocationService) {

        $scope.location = {};


        $scope.create = function ()
        {
            LocationService.createLocation($scope.location).then(function (response) {
                alert("Location was created");
            });
        }


    }]);