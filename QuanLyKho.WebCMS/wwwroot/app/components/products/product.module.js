/// <reference path="../wwwroot/libs/angular/angular.min.js" />
/// <reference path="../wwwroot/libs/angular/angular.js" />


(function () {
    'use strict';

    angular.module('app.products', ['app.common']).config(config);

    config.$inject = ['$urlRouterProvider', '$stateProvider'];

    function config($urlRouterProvider, $stateProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productsListView.html",
            controller: "productsListController"
        })
            .state('product_add', {
                url: "/product_add",
                templateUrl: "/app/components/products/productAddView.html",
                controller: "productAddController"
            })
            .state('product_edit', {
                url: "/product_edit",
                templateUrl: "/app/components/products/productEditController.html",
                controller: "productEditView"
        });
    }
})();