angular.module('grandTravelApp').controller('CustomerCreateController', ['$scope','$location', 'Upload', function ($scope, $location, Upload) {

    // upload on file select or drop

    $scope.customer = {};

    $scope.upload = function (file) {
        Upload.upload({
            url: '/api/customers',
            data: { Customer: $scope.customer, file: file }
        }).then(function (resp) {
            alert("Customer was created");
            $location.path('/Login');
           
        }, function (resp) {
            console.log('Error status: ' + resp.status);
        }, function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '%');
        });
    };

}]);






