angular.module('grandTravelApp').controller('CustomersDeleteController', ['$scope', 'CustomerService', '$routeParams', '$location',

    function ($scope, CustomerService, $routeParams, $location) {

        //Controller stuff goes here.

        CustomerService.deleteCustomer($routeParams.id).then(function (response) {
            $location.path('/Admin');
        })

    }]);
