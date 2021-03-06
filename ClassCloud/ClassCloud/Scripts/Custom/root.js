﻿var VM = VM || {};

VM.index = (function (ko, $) {
    function home() {
        var self = this;
        self.searchVM = new searchVM();
        self.listOfEvents = ko.observableArray([]);
        self.goClasses = function () {
            window.location.href = '/Student/Index';
        };

        self.addClass = function () {
            window.location.href = '/Student/SearchClasses';

        };
        
        self.studentHome = function () {
            window.location.href = '/Student/Index';
        }

        self.createLecture = function () {
            alert('test');

        };

        self.showCalendar = function () {
            self.searchVM.GetStudentCourses();
        };
        
        self.fillEvents = function (listOfCourses) {
            var test = []
            ko.utils.arrayForEach(listOfCourses, function (item) {
                console.log(ko.toJSON(item, null, 2));
                color = self.colorChooser(item.ID);
                ko.utils.arrayForEach(item.Lectures, function (lect) {
                    self.listOfEvents().push({ id: lect.ID, title: item.Name + '-' + lect.Name, start: self.convertDate(lect.Date), color: color });

                })
            });

            if(window.location.href.indexOf('/Student/Calendar') < 0)
                window.location.href = '/Student/Calendar/';



        };
        self.convertDate = function (date) {
            splitDate = date.split(' ');
            day = splitDate[1].split(',')[0];
            year = splitDate[2];
            month = '';
            switch(splitDate[0])
            {
                case 'January':
                    return year + '-' + '01' + '-' + day;
                case 'Feburary':
                    return year + '-' + '02' + '-' + day;
                case 'March':
                    return year + '-' + '03' + '-' + day;
                case 'April':
                    return year + '-' + '04' + '-' + day;
                case 'May':
                    return year + '-' + '05' + '-' + day;
                case 'June':
                    return year + '-' + '06' + '-' + day;
                case 'July':
                    return year + '-' + '07' + '-' + day;
                case 'August':
                    return year + '-' + '08' + '-' + day;
                case 'September':
                    return year + '-' + '09' + '-' + day;
                case 'October':
                    return year + '-' + '10' + '-' + day;
                case 'November':
                    return year + '-' + '11' + '-' + day;
                case 'December':
                    return year + '-' + '12' + '-' + day;
            }

        };

        self.colorChooser = function (n) {
            switch (n) {
                case 1:
                    return 'red';
                case 2:
                    return 'blue';
                case 3:
                    return 'green';
                case 4:
                    return 'LightSlateGray';
                case 5:
                    return 'indigos';
                case 6:
                    return 'purple';
                case 7:
                    return 'orange';
                case 8:
                    return 'crimson';
                case 9:
                    return 'Coral';
                case 10:
                    return 'pink';
                default:
                    return 'lightblue';
            }
        };
           




    }
    function initModule() {
        var viewModel = new home();
        ko.applyBindings(new home());
        return viewModel;
    }
    return { initModule: initModule };
})(ko, $);
