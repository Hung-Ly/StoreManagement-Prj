/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('app.products', ['app.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product', {
            url: "/product",
            templateUrl: "/app/components/products/productsListView.html",
            controller: "productsListController"
        })
            .state('add_product', {
                url: "/add_product",
                templateUrl: "/app/components/products/productAddView.html",
                controller: "productAddController"
            })
            .state('edit_product', {
                url: "/edit_product/:id",
                templateUrl: "/app/components/products/productEditView.html",
                controller: "productEditController",
            });
    }
})();