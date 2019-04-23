var _note = function () {
    var self = this;

    self.id = ko.observable();
    self.title = ko.observable();
    self.body = ko.observable();

    self.Notes = ko.observableArray();

    self.Init = function () {

        self.GetAllNotes();
    };

    self.GetAllNotes = function () {
        $.ajax({
            url:  'http://localhost:51720/Note/GetAllNote',
            //cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data && data.length > 0) {
                    self.Notes(data);
                }
                else { self.Notes([]); }
            }
        });
    };

    self.AddNote = function () {
        var request = {
            id : 0,
            title: self.title(),
            body: self.body()
        };

        $.ajax({
            url: 'http://localhost:51720/Note/AddNote',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(request),
            success: function (data) {
                if (data) {
                    self.Clear();
                    self.GetAllNotes();
                }
            }
        });
    };

    self.DeletNote = function (id) {
        if (confirm("Are you sure.....?")) {
            $.ajax({
                url: 'http://localhost:51720/Note/DeleteNote?id=' + id,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data) {
                        self.Clear();
                        self.GetAllNotes();
                    }
                }
            });
        }
    };

    self.UpdateNote = function () {
        var request = {
            id: self.id(),
            title: self.title(),
            body: self.body()
        };

        $.ajax({
            url: 'http://localhost:51720/Note/UpdateNote',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(request),
            success: function (data) {
                if (data) {
                    self.Clear();
                    self.GetAllNotes();
                }
            }
        });
    };

    self.UpdateInfo = function (data) {
        if (data) {
            self.id(data.id);
            self.title(data.title);
            self.body(data.body);
        }
    };

    self.Clear = function () {
        self.id('');
        self.title('');
        self.body('');
    };
};
var NoteViewModel = new _note();
ko.applyBindings(NoteViewModel);