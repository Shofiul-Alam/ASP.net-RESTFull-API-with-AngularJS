angular.module('grandTravelApp').controller('CustomerLoginController', ['$scope','$window', 'CustomerService','$location',

    function ($scope, $window, CustomerService, $location) {

        var url = "";

        if ($location.search().ReturnUrl != null) {
            url = $location.search().ReturnUrl;
        }
        else {
            url = "";
        }
        //Controller stuff goes here.
        $scope.loginModel = { ReturnUrl: url};

        
        $scope.customerLogin = function () {
           CustomerService.login($scope.loginModel).then(function (response) {
                alert("Customer is Logged In");
                $window.location.href = $scope.loginModel.ReturnUrl;
            });
        }

    }]);







