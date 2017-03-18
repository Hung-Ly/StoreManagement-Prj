(function (app) {
    'use strict';

    angular
        .module('app.products')
        .controller('productEditController', productEditController);

    productEditController.$inject = ['$location']; 

    function productEditController($location) {

    }
})();
