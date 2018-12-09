angular.module('grandTravelApp').controller('CustomerAllController', ['$scope', 'CustomerService',

    function ($scope, CustomerService) {

        //Controller stuff goes here.

        CustomerService.getAllCustomer().then(function (response) {

            $scope.allCustomers = response.data;

        });

    }]);
