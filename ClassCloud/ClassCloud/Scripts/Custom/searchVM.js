var searchVM = function () {
    var self = this;
    var Lecture = function (Value, Name, Date) {
        this.id = Value;
        this.name = Name;
        this.date = Date;

    };

    var Comment = function (UserName, Message) {
        this.username = UserName;
        this.message = Message;
    };

    self.activeClass = ko.observable();
    self.activeLecture = ko.observable();
    self.inLecture = ko.observable(false);
    self.LectureList = ko.observableArray();
    self.CommentList = ko.observableArray();
    self.LoadCourseInfo = function (ID) {
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
              
                return response;
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
                // alert(response);
                home.fillEvents(response);

            },
            error: function (xhr, textStatus, errorThrown) {
                alert('error');
                alert(ko.toJSON(xhr, null, 2));

            }
        });
    }

    self.DisplayLecture = function (ID) {

        //self.LectureList([]);
        self.activeClass(ID);
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/home/loadcourseinfo/' + ID,
            data: {},
            success: function (response) {
               

                var Lectures = response.Lectures;//grab the lectures
                for (var i = 0; i < Lectures.length; i++) {

                    // parsedDate = new Date(parseInt(Lectures[i].Date.replace("/Date(", "").replace(")/", ""), 10));
                    self.LectureList.push(new Lecture(Lectures[i].ID, Lectures[i].Name, Lectures[i].Date));
                }
               

            }
        });

    }

    self.EnterLecture = function (ID) {

        self.activeLecture(ID);
        self.inLecture(true);
        $.ajax({
            type: 'get',
            dataType: 'json',
            cache: false,
            url: '/student/loadchat/' + ID,
            data: {},
            success: function (response) {
               
                if (response != null)
                    for (var i = 0; i < response.length; i++) { self.CommentList.unshift(new Comment(response[i].UserName, response[i].UserComment)); }
            }
        });

    }

    self.LeaveLecture = function () {
        self.inLecture(false);
        self.CommentList.removeAll();
        self.activeLecture();
    }

    $(function () {
        // Reference the auto-generated proxy for the hub.
        var chat = $.connection.chatHub;
        // Create a function that the hub can call back to display messages.
        chat.client.addNewMessageToPage = function (name, message, lecture) {
            // Add the message to the page.
            //only push messages that are in the correct lecture.
            if (lecture == self.activeLecture())
                self.CommentList.unshift(new Comment(name, message));
        };
        // Get the user name and store it to prepend to messages.
        // $('#displayname').val(prompt('Enter your name:', ''));
        // Set initial focus to message input box.
        $('#message').focus();
        // Start the connection.
        $.connection.hub.start().done(function () {
            $('#sendmessage').click(function () {
                // Call the Send method on the hub.
                chat.server.send($('#displayname').val(), $('#message').val(), $('#lecture').val());
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            });
            $('#message').keyup(function (event) {
                if (event.keyCode == 13) {
                    // Call the Send method on the hub.
                    chat.server.send($('#displayname').val(), $('#message').val(), $('#lecture').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                }
            });
        });
    });


}
