/// <reference path="../wwwroot/libs/angular/angular.min.js" />
/// <reference path="../wwwroot/libs/angular/angular.js" />


(function () {
	'use strict';

	angular.module('app.product_categories', ['app.common']).config(config);

	config.$inject = ['$urlRouterProvider', '$stateProvider'];

	function config($urlRouterProvider, $stateProvider) {
	    $stateProvider.state('product_categories', {
	        url: "/product_categories",
	        templateUrl: "/app/components/productCategories/productCategoriesListView.html",
	        controller: "productCategoriesListController"
	    })
            .state('product_categoriest_add', {
            	url: "/product_categories_add",
            	templateUrl: "/app/components/productCategories/productCategoryAddView.html",
            	controller: "productCategoryAddController"
            })
            .state('product_categoriest_edit', {
            	url: "/product_categories_edit",
            	templateUrl: "/app/components/productCategories/productCategoryEditController.html",
            	controller: "productCategoryEditView"
            });
	}
})();