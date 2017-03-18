(function (app) {
    'use strict';

    angular
        .module('app.products')
        .controller('productAddController', productAddController);

    productAddController.$inject = ['$location']; 

    function productAddController($location) {

    }
})();
