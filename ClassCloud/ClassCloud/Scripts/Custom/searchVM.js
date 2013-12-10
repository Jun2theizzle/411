var searchVM = function () {
    var self = this;


    self.LoadCourseInfo = function (ID) {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
                console.log('adfa');
                console.log(response);
                return response
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
                alert('Class added!');
            }
        });
    }

    self.GetStudentCourses = function () {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/student/getAllCourses/',
            success: function (response) {
                console.log(response);
                home.fillEvents(response);
                window.location.href = '/Student/Calendar/';

            },
            error: function (xhr, textStatus, errorThrown) {
                alert('error');
                alert(ko.toJSON(xhr, null, 2));

            }
        });
    }
}
