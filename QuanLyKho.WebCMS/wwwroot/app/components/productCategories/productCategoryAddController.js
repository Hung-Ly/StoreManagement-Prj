/// <reference path="../../../libs/angular/angular.min.js" />

(function () {
    'use strict';

    angular
        .module('app.product_categories')
        .controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope','apiService','notificationService']; 

    function productCategoryAddController($scope, apiService, notificationService) {
        $scope.productCategory = {
            createdDate: new Date(),
            status: true
        };
        $scope.AddProductCategory = AddProductCategory;

        function AddProductCategory() {
            apiService.post('api/productcategories/create', $scope.productCategory,
                function (result) {                   
                    notificationService.displaySuccess(result.data.model.name + ' đã được thêm mới.');
                    console.log(result.data.model);
                }, function (error) {
                    //console.log(error);
                    notificationService.displayError('Thêm mới không thành công.');
                });
        };

        function loadParentCategory() {
            apiService.get('api/productcategories/getallparents', null, function (result) {
                //console.log(result.data.model);
                //result.data.model.forEach(function (entry) {
                //    console.log(entry.name);
                //});
                $scope.parentCategories = result.data.model;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadParentCategory();
    }
})();
