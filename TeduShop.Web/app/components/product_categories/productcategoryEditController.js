/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productCategoryEditController", productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {

        $scope.productCategory = [];

        $scope.productCategory = {
            CreateDate: new Date(),
            Status: true
        }


        $scope.UpdateProductCategory = UpdateProductCategory;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('/api/productCategorys/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data[0];
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }

        function UpdateProductCategory() {
            apiService.put('/api/productCategorys/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.config.data.Name + ' đã được cập nhật.');
                    $state.go('product_categories');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadParenCategory() {
            apiService.get("/api/productCategorys/getallparent", null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('can not listen parent');
            });
        }

       

        loadParenCategory();
        loadProductCategoryDetail();
    }
})(angular.module("tedushop.product_categories"));