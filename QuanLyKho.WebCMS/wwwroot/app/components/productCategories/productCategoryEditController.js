(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            createdDate: new Date(),
            status: true
        };

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle();


        function GetSeoTitle() {
            $scope.productCategory.alias = commonService.getSeoTitle($scope.productCategory.name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategories/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data.model;
            }, function (error) {
                notificationService.displayError(error.data);
            });

           // console.log($scope.productCategory);
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategories/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.model.name + ' đã được cập nhật.');
                    $state.go('product_categories');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/productcategories/getallparents', null, function (result) {
                console.log(result.data.model.name);
                $scope.parentCategories = result.data.model;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        //console.log($scope.productCategory);
        loadParentCategory();
        loadProductCategoryDetail();
    }

})(angular.module('app.product_categories'));