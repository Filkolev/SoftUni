var app = app || {};

app.noteController = (function () {
    function NoteController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    NoteController.prototype.loadAddNoteView = function (selector) {
        this.viewBag.addNote.loadAddNoteView(selector);
    };

    NoteController.prototype.loadNoteView = function (selector, urlParams, action) {
        var data = urlParams.split('&'),
            outData = {
                id: data[0].split('id=')[1],
                title: data[1].split('title=')[1],
                text: data[2].split('text=')[1],
                deadline: data[3].split('deadline=')[1]
            };

        if (action === 'delete') {
            this.viewBag.deleteNote.loadDeleteNoteView(selector, outData);
        } else {
            this.viewBag.editNote.loadEditNoteView(selector, outData);
        }
    };

    NoteController.prototype.listOfficeNotes = function (selector, page) {
        var _this = this;

        return this.model.listOfficeNotes(page)
            .then(function (data) {
                data.results.forEach(function (note) {
                    note.show = note.ACL.hasOwnProperty(sessionStorage.userId);
                });

                _this.viewBag.listNotes.listNotes(selector, data);
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    NoteController.prototype.listCurrentUserNotes = function (selector, page) {
        var _this = this;

        return this.model.listCurrentUserNotes(page)
            .then(function (data) {
                _this.viewBag.listCurrentUserNotes.listCurrentUserNotes(selector, data);
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    NoteController.prototype.addNote = function (title, text, deadline) {
        return this.model.addNote(title, text, deadline)
            .then(function (data) {
                window.location.replace('#/myNotes/');
                Noty.success('Note added successfully!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    NoteController.prototype.editNote = function (noteId, title, text, deadline) {
        return this.model.editNote(noteId, title, text, deadline)
            .then(function () {
                window.location.replace('#/myNotes/');
                Noty.success('Note edited successfully!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    NoteController.prototype.deleteNote = function (noteId) {
        return this.model.deleteNote(noteId)
            .then(function () {
                window.location.replace('#/myNotes/');
                Noty.success('Note deleted successfully!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    return {
        load: function (model, views) {
            return new NoteController(model, views);
        }
    }
})();