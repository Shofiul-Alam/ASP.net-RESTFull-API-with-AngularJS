angular.module('grandTravelApp').factory('LocationService', ['$http', function ($http) {

    var _getCustomers = function(){
        return $http.get('/api/customers');
    };

    var _getAllCustomer = function () {
        return $http.get('/api/customers/allCustomer');
    };

    var _createLocation = function (location) {
        return $http.post('api/locations', location);
    };

    var _getById = function (id) {
        return $http.get('/api/customers/' + id);
    };
    var _getByAdmin = function (id) {
        return $http.get('/api/admin/customer/edit/' + id);
    };
    var _updateCustomer = function (customer) {
        return $http.put('/api/customers/' + customer.CustomerId, customer);
    };

    return {
        getCustomers: _getCustomers,
        createLocation: _createLocation,
        getById: _getById,
        getByAdmin: _getByAdmin,
        updateCustomer: _updateCustomer,
        getAllCustomer: _getAllCustomer
    };

    
}]);



