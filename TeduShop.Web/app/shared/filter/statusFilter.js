(function (app) {
    app.filter('statusFilter', function () {
        return function(input)
        {
            if (input == true)
                return 'kích hoạt'
            else
                return 'khóa'
        }
    })
})(angular.module('tedushop.common'))