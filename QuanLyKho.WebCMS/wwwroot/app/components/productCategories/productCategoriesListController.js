(function () {
    'use strict';

    angular
        .module('app.product_categories')
        .controller('productCategoriesListController', productCategoriesListController);

        //$score service của angluar
    productCategoriesListController.$inject = ['$scope', 'apiService','notificationService']; 

    function productCategoriesListController($scope, apiService, notificationService) {

        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                //trung vs tham so cua method getall cua pro_cate_Contr
                params: {                    
                    page: page,
                    keyword: $scope.keyword,
                    pageSize: 3
                }
            };

            apiService.get('/api/productcategories/getall', config, function (result) {
                if (result.data.pageSize === 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào');
                } else {
                    notificationService.displaySuccess('Có ' + result.data.totalPages +' trên '+result.data.pageSize + ' bản ghi');

                }

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
