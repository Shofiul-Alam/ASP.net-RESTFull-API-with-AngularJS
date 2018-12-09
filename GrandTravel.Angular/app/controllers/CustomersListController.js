angular.module('grandTravelApp').controller('CustomersListController', ['$scope', 'CustomerService', '$routeParams',

    function ($scope, CustomerService, $routeParams) {

        //Controller stuff goes here.

        CustomerService.getCustomers().then(function (response) {

            $scope.customers = response.data;

        });


    }]);
