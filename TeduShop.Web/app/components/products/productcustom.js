//images choose ckfinder
$("#imageChoose").click(function () {
    var finder = new CKFinder();
    finder.selectActionFunction = function (fileUrl) {
        $("input[name='image']").val(fileUrl);
    };
    finder.popup();
});

