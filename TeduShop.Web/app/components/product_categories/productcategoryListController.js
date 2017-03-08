/// <reference path="../../../Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productCategoryListController", productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {
            apiService.get("/api/productCategorys/getall", null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("load productCategorys fail");
            });
        }
        
        $scope.getProductCategories();
    }
})(angular.module("tedushop.product_categories"));