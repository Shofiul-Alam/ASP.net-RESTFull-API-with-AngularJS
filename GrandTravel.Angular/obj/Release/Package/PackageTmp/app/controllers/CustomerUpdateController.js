angular.module('grandTravelApp').controller('CustomerUpdateController', ['$scope', 'CustomerService','$routeParams','$location',

    function ($scope, CustomerService, $routeParams, $location) {

        CustomerService.getById($routeParams.id).then(function (response) {
            $scope.customer = response.data;
        });

        $scope.update = function () {
            CustomerService.updateCustomer($scope.customer).then(function (response) {
                alert('Customer was updated');
                $location.path('/Account');
            })
        };


        //allow user to save change
    }]);