/// <reference path="../../../Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productEditController", productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.product = {}
        $scope.productCategories = [];

        $scope.UpdateProduct = UpdateProduct;
        $scope.loadProductCategory = loadProductCategory;
        $scope.loadProductDetail = loadProductDetail;
        $scope.GetSeoTitle = GetSeoTitle;

        

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name)
        }

        function loadProductDetail() {
            apiService.get('/api/products/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data[0];
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }

        function UpdateProduct() {
            apiService.put('/api/products/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.config.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
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
        loadProductDetail();
    }
})(angular.module("tedushop.products"));