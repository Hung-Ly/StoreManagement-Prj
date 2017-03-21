/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('app.product_categories', ['app.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/productCategories/productCategoriesListView.html",
            controller: "productCategoriesListController"
        })
            .state('add_product_category', {
                url: "/add_product_category",
                templateUrl: "/app/components/productCategories/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('edit_product_category', {
                url: "/edit_product_category/:id",
                templateUrl: "/app/components/productCategories/productCategoryEditView.html",
                controller: "productCategoryEditController",
                //resolve: {
                //    resolvedHikelist: ['Hikelist', function (Hikelist, $stateParams) {
                //        return Itemlist.get({ id: $stateParams.listId });
                //    }]
                //}
            });
    }
})();