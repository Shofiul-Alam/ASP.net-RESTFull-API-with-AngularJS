angular.module('grandTravelApp').factory('CustomerService', ['$http', function ($http) {

    var _getCustomers = function(){
        return $http.get('/api/customers');
    };

    var _getAllCustomer = function () {
        return $http.get('/api/customers/allCustomer');
    };

    var _createCustomer = function (customer) {
        return $http.post('/api/customers', customer);
    };

    var _login = function (login) {
        return $http.post('/api/customers/login', login)
    }

    var _getById = function (id) {
        return $http.get('/api/customers/' + id);
    };
    var _getByAdmin = function (id) {
        return $http.get('/api/admin/customer/edit/' + id);
    };
    var _updateCustomer = function (customer) {
        return $http.put('/api/customers/' + customer.CustomerId, customer);
    };
    var _deleteCustomer = function (id) {
        return $http.get('/api/customers/delete/' + id);
    };

    return {
        getCustomers: _getCustomers,
        createCustomer: _createCustomer,
        getById: _getById,
        getByAdmin: _getByAdmin,
        updateCustomer: _updateCustomer,
        getAllCustomer: _getAllCustomer,
        login: _login,
        deleteCustomer: _deleteCustomer
    };

    
}]);



