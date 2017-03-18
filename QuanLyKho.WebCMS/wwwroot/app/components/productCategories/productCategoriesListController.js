(function () {
    'use strict';

    angular
        .module('app.product_categories')
        .controller('productCategoriesListController', productCategoriesListController);

        //$score service của angluar
    productCategoriesListController.$inject = ['$scope', 'apiService']; 

    function productCategoriesListController($scope, apiService) {

        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        $scope.page = 0;
        $scope.pagesCount = 0;

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                //trung vs tham so cua method getall cua pro_cate_Contr
                params: {
                    page: page,
                    pageSize: 3
                }
            };

            apiService.get('/api/productcategories/getall', config, function (result) {
                $scope.productCategories = result.data.model;
                $scope.page = result.data.pageNumber;
                $scope.pagesCount = result.data.totalPages;
                $scope.totalCount = result.data.pageSize;
            }, function () {
                console.log("Load product categories failed");
            });
        }
        $scope.getProductCategories();
    }
})();
