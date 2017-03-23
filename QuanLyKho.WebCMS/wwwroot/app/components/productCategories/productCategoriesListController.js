(function () {
    'use strict';

    angular
        .module('app.product_categories')
        .controller('productCategoriesListController', productCategoriesListController);

        //$score service của angluar
    productCategoriesListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','$filter'];

    function productCategoriesListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;

        $scope.deleteMultiple = deleteMultiple;
        $scope.selectAll = selectAll;


        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategories.alias = commonService.getSeoTitle($scope.productCategories.name);
        }
        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.id);
            });
            var config = {
                params: {
                    listIDProductCategory: listId
                }
            }
            apiService.del('api/productcategories/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data.model.length + ' bản ghi.');
                search();
            }, function (error) {
                console.log(error);
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            console.log($scope.productCategories);
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/productcategories/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

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
                    notificationService.displaySuccess('Có ' + result.data.pageSize + ' trên ' + result.data.totalRows + ' bản ghi');

                }                
                $scope.productCategories = result.data.model;
                $scope.page = result.data.pageNumber;
                $scope.totalRows = result.data.totalRows;
                $scope.pagesCount = result.data.totalPages;
                $scope.totalCount = result.data.pageSize;
            }, function () {
                console.log("Load product categories failed");
            });
        }
        $scope.getProductCategories();
    }
})();
