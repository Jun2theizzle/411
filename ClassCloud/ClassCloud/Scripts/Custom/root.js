﻿var VM = VM || {};

VM.index = (function (ko, $) {
    function home() {
        var self = this;
        self.searchVM = new searchVM();
        self.listOfEvents = ko.observableArray([{ title: 'Event1', start: '2013-12-8' } ,{ title: 'Event2', start: '2013-12-9' }]);
        self.goClasses = function () {
            window.location.href = '/Student/Index';
        };

        self.addClass = function () {
            window.location.href = '/Student/SearchClasses';

        };

        self.createLecture = function () {
            alert('test');

        }

        self.showCalendar = function () {
            //self.searchVM.GetStudentCourses();
            window.location.href = "/Student/Calendar";
        }
        
        self.fillEvents = function () {
            alert('hey');
            

        }
           




    }
    function initModule() {
        var viewModel = new home();
        ko.applyBindings(new home());
        return viewModel;
    }
    return { initModule: initModule };
})(ko, $);
