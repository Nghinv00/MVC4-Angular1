/// <reference path="../../../Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productAddController", productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }
        $scope.productCategories = [];

        $scope.AddProduct = AddProduct;
        $scope.loadProductCategory = loadProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name)
        }


        function AddProduct() {
            apiService.post('/api/products/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.config.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function loadProductCategory() {
            apiService.get("/api/productCategorys/getallparent", null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('can not listen parent');
            });
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        //$scope.chooseImages = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.product.Image = fileUrl;
        //    }
        //    finder.popup();
        //}

        loadProductCategory();
    }
})(angular.module("tedushop.products"));