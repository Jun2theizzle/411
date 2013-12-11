var searchVM = function () {
    var self = this;
    var Lecture = function (Value, Name,Date) {
        this.id = Value;
        this.name = Name;
        this.date = Date;
       
    };
    self.activeClass = ko.observable();
    self.LectureList = ko.observableArray();
    self.LoadCourseInfo = function (ID) {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
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

            },
            error: function (xhr, textStatus, errorThrown) {
                alert('error');
                alert(ko.toJSON(xhr, null, 2));

            }
        });
    }

    self.DisplayLecture = function (ID) {
        self.LectureList([]);
        self.activeClass(ID);
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
                console.log(response);
                
                var Lectures = response.Lectures;//grab the lectures
                for (var i = 0; i < Lectures.length; i++) {

                   // parsedDate = new Date(parseInt(Lectures[i].Date.replace("/Date(", "").replace(")/", ""), 10));
                    self.LectureList.push(new Lecture(Lectures[i].ID, Lectures[i].Name, Lectures[i].Date));
                }
                console.log(self.LectureList());

            }
        });

    }
}
