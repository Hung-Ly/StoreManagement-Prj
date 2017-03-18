(function (app) {
    'use strict';
    //module con cua product
    angular
        .module('app.products')
        .controller('productsListController', productsListController);

    productsListController.$inject = ['$location']; 

    function productsListController($location) {

    }
})();
