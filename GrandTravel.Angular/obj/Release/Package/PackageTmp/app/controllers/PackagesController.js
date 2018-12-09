angular.module('grandTravelApp').controller('PackagesController', ['$scope', 'PackageService','$routeParams', '$location', '$window',

function ($scope, PackageService, $routeParams, $location, $window) {

        //Controller stuff goes here.
        
    $scope.packages = {};
    $scope.cartItems = {};
    $scope.feedback = {};
    $scope.feedbacks = {};
    $scope.feedback = { PackageId: $routeParams.id };

        PackageService.getAllPackages().then(function (response) {
            $scope.packages = response.data;
        });

        PackageService.getLocations().then(function (response) {

            $scope.Locations = response.data;

        });

        $scope.search = function () {
            PackageService.searchPackage($scope.searchQuery).then(function (response) {
                $scope.packages = response.data;
                $scope.orderLineItem = { PackageId: $scope.Packages.PackageId }
            });
        };

        PackageService.getById($routeParams.id).then(function (response) {
            $scope.package = response.data;
        });

        $scope.addToCartById = function () {
            PackageService.cartById($routeParams.id).then(function (response) {
                $scope.cartItems = response.data;
                if ($scope.cartItems.length > 0) {
                    $scope.Cshow = true;
                } else { $scope.Cshow = false; }
                alert("Item is Added to Cart.");
            });
        };

        PackageService.getCarts().then(function (response) {

            $scope.cartItems = response.data;
            if ($scope.cartItems.length > 0) {
                $scope.Cshow = true;
            } else { $scope.Cshow = false; }

        });

        $scope.deleteCartItem = function (id) {
            PackageService.removeCartItem(id).then(function (response) {
                $scope.cartItems = response.data;
                if ($scope.cartItems.length > 0) {
                    $scope.Cshow = true;
                } else { $scope.Cshow = false; }
                alert("Item is Removed From Cart.")
                /*$window.location.href = "/PackageDetails/" + $scope.feedback.PackageId;*/

            });
        };
        $scope.showHide = function () {
            if (!$scope.show) {
                $scope.show = true;
            } else { $scope.show = false; }
        };

        
        $scope.addFeedback = function () {

            PackageService.checkAuth().then(function (res)
            {
                var auth = res.data;

                if (auth == "ok") {
                    PackageService.insertFeedback($scope.feedback).then(function (response) {
                        $scope.feedbacks = response.data;
                        alert("Feedback is Added.");

                    });
                }
                else
                {
                    $window.location.href = "/Login";
                }
            });
        };

        PackageService.getAllFeedback($routeParams.id).then(function (response) {

            $scope.feedbacks = response.data;

        });

        $scope.getNumber = function (num) {

            var cars = new Array(num);
            for (var i = 0; i < num; i++) {
                cars[i] = i;
            }
            return cars;
        }

    }]);

