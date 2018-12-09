angular.module('grandTravelApp').controller('CartItemDeleteController', ['$scope', 'PackageService', '$routeParams', '$location',

    function ($scope, PackageService, $routeParams, $location) {

        //Controller stuff goes here.

        PackageService.removeCartItem($routeParams.id).then(function (response) {
            $location.path('/carts');
        })

    }]);
