/// <reference path="../../../Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productCategoryListController", productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;

        function search() {
            getProductCategories();
        };
       
        $scope.getProductCategories = getProductCategories;

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize : 12
                }
            }

            apiService.get("/api/productCategorys/getallpage", config, function (result) {

                //$scope.productCategories = result.data; (if nothing paging then you use)
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }

                $scope.productCategories = result.data.Items; //use then with paging
                //info for paging
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log("load productCategorys fail");
            });
        }
        
        $scope.getProductCategories();
    }
})(angular.module("tedushop.product_categories"));