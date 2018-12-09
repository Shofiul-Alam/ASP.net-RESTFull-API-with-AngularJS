angular.module('grandTravelApp').controller('PackageCreateController', ['$scope', 'PackageService','$window',

    function ($scope, PackageService, $window) {

        $scope.Package = {};


        $scope.create = function ()
        {
            PackageService.createPackage($scope.Package).then(function (response) {
                alert("Package was created");

                $window.location.href = "/packages";
                
            });
        }


    }]);