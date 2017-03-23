(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        };
        $scope.AddProduct = AddProduct;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.alias = commonService.getSeoTitle($scope.product.name);
        }

        function AddProduct() {
            apiService.post('api/product/createproduct', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.model.name + ' đã được thêm mới.');
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadProductCategory() {
            apiService.get('api/productcategories/getallparents', null, function (result) {
                console.log(result.data.model);
                $scope.productCategories = result.data.model;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        $scope.moreImages = [];
        loadProductCategory();
    }

})(angular.module('app.products'));