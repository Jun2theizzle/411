var VM = VM || {};

VM.index = (function (ko, $) {
    function home() {
        var self = this;
        self.searchVM = new searchVM();




    }
    function initModule() {
        ko.applyBindings(new home());
    }
    return { initModule: initModule };
})(ko, $);
