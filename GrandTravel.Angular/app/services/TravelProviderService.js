angular.module('grandTravelApp').factory('TravelProviderService', ['$http', function ($http) {

    var _getTravelProviders = function () {
        return $http.get('/api/TravelProvider');
    };

    var _createTravelProvider = function (TravelProvider) {
        return $http.post('/api/TravelProvider', TravelProvider);
    };

    var _getById = function (id) {
        return $http.get('/api/TravelProvider/' + id);
    };
    var _updateTravelProvider = function (customer) {
        return $http.put('/api/TravelProvider/' + TravelProvider.TravelProviderId, TravelProvider);
    };

    return {
        getTravelProviders: _getTravelProviders,
        createTravelProvider: _createTravelProvider,
        getById: _getById,
        updateTravelProvider: _updateTravelProvider
    };

    
}]);



