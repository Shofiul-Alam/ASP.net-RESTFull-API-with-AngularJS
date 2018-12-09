angular.module('grandTravelApp').controller('TravelProviderListController', ['$scope', 'TravelProviderService',

    function ($scope, TravelProviderService) {

        //Controller stuff goes here.

        TravelProviderService.getTravelProviders().then(function (response) {

            $scope.TravelProviders = response.data;

        });

    }]);