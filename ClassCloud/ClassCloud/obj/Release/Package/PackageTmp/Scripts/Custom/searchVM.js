var searchVM = function () {
    var self = this;
    self.test = function () {
        alert('hi');
    }

    self.LoadCourseInfo = function (ID) {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
                console.log(response);
            }
        });
    }

    self.AddCourse = function (ID) {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/addcourse/' + ID,
            data: {},
            success: function (response) {
                console.log(response);
            }
        });
    }
}
