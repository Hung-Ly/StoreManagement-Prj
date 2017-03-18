(function () {
    'use strict';

    angular
        .module('app.product_categories')
        .controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$location']; 

    function productCategoryAddController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productCategoryAddController';

        activate();

        function activate() { }
    }
})();
