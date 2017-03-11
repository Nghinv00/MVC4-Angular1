/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productCategoryAddController", productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state','commonService'];

    function productCategoryAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreateDate: new Date(),
            Status: true
        }
        $scope.parentCategories = [];

        $scope.AddProductCategory = AddProductCategory;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name)
        }

        function AddProductCategory() {
            apiService.post('/api/productCategorys/create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.config.data.Name + ' đã được thêm mới.');
                    $state.go('product_categories');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
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
    }
})(angular.module("tedushop.product_categories"));