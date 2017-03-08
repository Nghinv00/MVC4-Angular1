/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module("tedushop.product_categories", ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider)
    {
        $stateProvider.state("product_categories", {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/product_categoriesListView.html",
            controller: "product_categoriesListController"
        }).state("product_categories_add", {
            url: "/product_categoryes_add",
            templateUrl: "/app/components/product_categories/product_categoriesAddView.html",
            controller: "product_categoriesAddController"
        });
    }
})();