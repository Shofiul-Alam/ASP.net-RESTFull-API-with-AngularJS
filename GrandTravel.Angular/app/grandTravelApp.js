var grandTravelApp = angular.module('grandTravelApp', ['ngRoute', 'ngFileUpload', 'angularFileUpload']);

grandTravelApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
         .when('/Login',
        {
            templateUrl: '/app/templates/login.html',
            controller: 'CustomerLoginController'
        })
         .when('/UserRegister',
        {
            templateUrl: '/app/templates/customer-create.html',
            controller: 'CustomerCreateController'
        })
        .when('/Account',
        {
            templateUrl: '/app/templates/customer-list.html',
            controller: 'CustomersListController'
        })
       .when('/delete/:id',
        {
            templateUrl: '/app/templates/delete.html',
            controller: 'CustomersDeleteController'
        })
     .when('/Account/create',
        {
            templateUrl: '/app/templates/customer-create.html',
            controller: 'CustomerCreateController'
        })
    .when('/Account/edit/:id',
        {
            templateUrl: '/app/templates/customer-update.html',
            controller: 'CustomerUpdateController'
        })
    .when('/Account/TravelProvider',
        {
            templateUrl: '/app/templates/travelProvider-list.html',
            controller: 'TravelProviderListController'
        })
    .when('/Account/TravelProvider/create',
        {
            templateUrl: '/app/templates/travelProvider-create.html',
            controller: 'TravelProviderCreateController'
        })
    .when('/Account/TravelProvider/edit/:id',
        {
            templateUrl: '/app/templates/travelProvider-update.html',
            controller: 'TravelProviderUpdateController'
        })
    .when('/packages',
       {
           templateUrl: '/app/templates/package-list.html',
           controller: 'PackagesController'
       })
     .when('/PackageDetails/:id',
       {
           templateUrl: '/app/templates/package.html',
           controller: 'PackagesController'
       })
   .when('/Package/create',
       {
           templateUrl: '/app/templates/package-create.html',
           controller: 'PackageListController'
       })
   .when('/Pacakge/edit/:id',
       {
           templateUrl: '/app/templates/package-update.html',
           controller: 'PackageUpdateController'
       })
    .when('/Account/packageSearch',
       {
           templateUrl: '/app/templates/package-search.html',
           controller: 'PackageSearchController'
       })
   .when('/Account/carts',
       {
           templateUrl: '/app/templates/shopping-cart.html',
           controller: 'PackageSearchController'
       })
   .when('/removeCartItem/:id',
       {
           templateUrl: '/app/templates/shopping-cart.html',
           controller: 'CartItemDeleteController'
       })
         .when('/PackageDetails/delete/:id',
       {
           templateUrl: '',
           controller: 'PackageController'
       })
    .when('/Account/Admin',
       {
           templateUrl: '/app/templates/customers-list.html',
           controller: 'CustomerAllController'
       })
         .when('/Admin/customer/edit/:id',
        {
            templateUrl: '/app/templates/customer-admin-update.html',
            controller: 'CustomerAdminUpdateController'
        })
   .when('/Admin/create',
       {
           templateUrl: '/app/templates/package-create.html',
           controller: 'PackageCreateController'
       })
   .when('/Account/Admin/edit/:id',
       {
           templateUrl: '/app/templates/package-update.html',
           controller: 'PackageUpdateController'
       })
     .when('/Account/Admin/addlocation',
       {
           templateUrl: '/app/templates/location-create.html',
           controller: 'LocationCreateController'
       })
    .when('/PayPalPayment',
       {
           templateUrl: '/app/templates/paypal-checkout.html',
           controller: 'PackageSearchController'
       })
    
    ;


    $locationProvider.html5Mode(true);

}]);