angular.module('grandTravelApp').controller('PackageSearchController', ['$scope', 'PackageService', '$routeParams', '$location',

function ($scope, PackageService, $routeParams, $location) {

        //Controller stuff goes here.
        $scope.searchQuery = {};
        $scope.orderLineItem = { PackageId: "" };
        $scope.order = {};


        PackageService.getLocations().then(function (response) {

            $scope.Locations = response.data;

        });
        PackageService.getCarts().then(function (response) {

            $scope.carts = response.data;

        });

        $scope.search = function () {
            PackageService.searchPackage($scope.searchQuery).then(function (response) {
                $scope.Packages = response.data;
                $scope.orderLineItem = {PackageId: $scope.Packages.PackageId}
            });
        };
        $scope.addToCart = function () {
                PackageService.cart($scope.orderLineItem).then(function (response) {
                    $scope.cartItems = response.data;
                    alert("Item is Added to Cart.")
            });
        };

        $scope.checkOut = function () {
            PackageService.checkOutNow($scope.carts).then(function (res) {
                $scope.order = res.data;
            });
        }


    }]);

