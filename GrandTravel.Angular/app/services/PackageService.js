angular.module('grandTravelApp').factory('PackageService', ['$http', function ($http) {


    
    var _getAllPackages = function () {
        return $http.get('api/packages');
    };
    var _getLocations = function () {
        return $http.get('api/locations');
    };

    var _createPackage = function (Package) {
        return $http.post('api/packages', Package);
    };
    var _searchPackage = function (searchQuery) {
        return $http.post('api/packages/search', searchQuery);
    };
    var _getById = function (id) {
        return $http.get('api/packages/' + id);
    };
    var _updatePackage = function (Package) {
        return $http.put('api/packages' + Package.Id, Package);
    };
    var _cart = function (orderLineItem) {
       
        return $http.post('api/packages/addToCart', orderLineItem);
    };
    var _cartById = function (id) {
        return $http.get('api/packages/addToCart/' + id);
    };
    
    var _getCarts = function () {

        return $http.get('api/packages/carts');
    };
    var _removeCartItem = function (id) {
        return $http.get('api/packages/RemoveCartItem/' + id);
    };
    var _checkOutNow = function (carts) {
        return $http.post('api/packages/AddOrder', carts);
    };
    var _insertFeedback = function (feedback) {
        return $http.post('api/packages/feedback', feedback);
    };
    var _getAllFeedback = function (id) {

        return $http.get('api/packages/feedback/' + id);
    };

    var _checkAuth = function () {

        return $http.get('api/customers/authentication');
    };
    
    
    

    return {
        getLocations: _getLocations,
        createPackage: _createPackage,
        getById: _getById,
        updatePackage: _updatePackage,
        searchPackage: _searchPackage,
        cart: _cart,
        getCarts: _getCarts,
        removeCartItem: _removeCartItem,
        checkOutNow: _checkOutNow,
        getAllPackages: _getAllPackages,
        cartById: _cartById,
        insertFeedback: _insertFeedback,
        getAllFeedback: _getAllFeedback,
        checkAuth: _checkAuth
    };

    
}]);



