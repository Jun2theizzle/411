var VM = VM || {};

VM.index = (function (ko, $) {
    function home() {
        var self = this;
        self.searchVM = new searchVM();

        self.goClasses = function () {
            window.location.href = '/Student/Index';
        };

        self.addClass = function () {
            alert('test');

        };

        self.createLecture = function () {
            alert('test');

        }




    }
    function initModule() {
        ko.applyBindings(new home());
    }
    return { initModule: initModule };
})(ko, $);
