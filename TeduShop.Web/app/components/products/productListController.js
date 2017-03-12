/// <reference path="../../../Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller("productListController", productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;

        $scope.deleteProduct = deleteProduct;
        $scope.deleteMutiple = deleteMutiple;

        function deleteMutiple() {
            var listID = [];
            $.each($scope.selected, function (i, item) {
                listID.push(item.ID);
            });

            var config = {
                params: {
                    checkedproductcategories: JSON.stringify(listID)
                }
            }
            apiService.del('/api/products/deletemuti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                search();
            },
                function (error) {
                    notificationService.displayError('Xóa không thành công');
                });
        }

        //begin in select check all input
        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.selectAll = selectAll;
        $scope.isAll = false;

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        //end begin in select all check input

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/products/delete', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        function search() {
            getProducts();
        };

        $scope.getProducts = getProducts;

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 12
                }
            }

            apiService.get("/api/products/getallpage", config, function (result) {

                //$scope.productCategories = result.data; (if nothing paging then you use)
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }

                $scope.products = result.data.Items; //use then with paging
                //info for paging
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log("load productCategorys fail");
            });
        }

        $scope.getProducts();
    }
})(angular.module("tedushop.products" ));