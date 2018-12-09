angular.module('grandTravelApp').controller('CustomerAdminUpdateController', ['$scope', 'CustomerService', '$routeParams', '$location',

    function ($scope, CustomerService, $routeParams, $location) {

        //$scope.lesson = {};

        //$scope.create = function () {
        //    LessonService.createLesson($scope.lesson).then(function (response) {
        //        alert("Lesson was created");
        //    });
        //}
        //---------------

        //Get the lesson by its id
        CustomerService.getByAdmin($routeParams.id).then(function (response) {
            $scope.customer = response.data;
            console.log($scope.customer);
        });

        $scope.update = function () {
            CustomerService.updateCustomer($scope.customer).then(function (response) {
                alert('Customer was updated');
                $location.path('/Admin');
            })
        };


        $scope.roles = [
            { id: 0, text: "User" },
            { id: 1, text: "Customer" },
            { id: 2, text: "Travel Provider" },
            { id: 3, text: "Admin" }
        ];


        //allow user to save change
    }]);