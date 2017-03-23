﻿(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.product = {};
        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.name);
        }
        console.log($stateParams.id);
        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
               
                console.log(result.data.model);
                $scope.product = result.data.model;
            }, function (error) {
                notificationService.displayError(error.data);
            });
            console.log($scope.productCategory);
        }
        function UpdateProduct() {
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.model.name + ' đã được cập nhật.');
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadProductCategory() {
            apiService.get('api/productcategories/getallparents', null, function (result) {
                $scope.productCategories = result.data.model;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadProductCategory();
        loadProductDetail();
    }

})(angular.module('app.products'));