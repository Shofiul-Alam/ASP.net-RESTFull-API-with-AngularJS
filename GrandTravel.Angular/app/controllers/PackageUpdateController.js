angular.module('grandTravelApp').controller('CustomerUpdateController', ['$scope', 'CustomerService','$routeParams','$location',

    function ($scope, CustomerService, $routeParams, $location) {

        //$scope.lesson = {};

        //$scope.create = function () {
        //    LessonService.createLesson($scope.lesson).then(function (response) {
        //        alert("Lesson was created");
        //    });
        //}
        //---------------

        //Get the lesson by its id
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