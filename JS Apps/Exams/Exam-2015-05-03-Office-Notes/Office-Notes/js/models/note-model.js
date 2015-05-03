var app = app || {};

app.noteModel = (function () {
    var POSTS_PER_PAGE = 10;

    function NoteModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Note';
        this.requester = requester;
        this.headers = headers;
    }

    NoteModel.prototype.listOfficeNotes = function (page) {
        var today = new Date().toLocaleDateString(),
            year = today.split('/')[2],
            month = (parseInt(today.split('/')[0]) < 10 ? '0' : '') + today.split('/')[0],
            day = (parseInt(today.split('/')[1]) < 10 ? '0' : '') + today.split('/')[1],
            formattedCurrentDate = year + '-' + month + '-' + day,
            url = this.serviceUrl + '?where={"deadline":"' + formattedCurrentDate + '"}' +
                '&include=author' +
                '&count=1000' +
                '&limit=' + POSTS_PER_PAGE +
                '&skip=' + (POSTS_PER_PAGE * (page - 1));

        return this.requester.get(url, this.headers.getHeaders(true));
    };

    NoteModel.prototype.listCurrentUserNotes = function (page) {
        var userId = sessionStorage['userId'],
            url = this.serviceUrl + '?where={' +
                '"author": { "__type": "Pointer","className": "_User",   "objectId": "' + userId + '"}}' +
                '&include=author' +
                '&count=1000' +
                '&limit=' + POSTS_PER_PAGE +
                '&skip=' + (POSTS_PER_PAGE * (page - 1));

        return this.requester.get(url, this.headers.getHeaders(true));
    };

    NoteModel.prototype.addNote = function (title, text, deadline) {

        if (title && text && deadline) {
            var userId = sessionStorage['userId'],
                data = {
                    title: title,
                    text: text,
                    deadline: deadline,
                    author: {
                        __type: "Pointer",
                        className: "_User",
                        objectId: userId
                    },
                    ACL: {
                        "*": {
                            read: true
                        }
                    }
                };

            data.ACL[userId] = {
                "write": true,
                "read": true
            };

            return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), data);
        } else {
            Noty.error('All fields are required!', 'top');
        }

    };

    NoteModel.prototype.editNote = function (noteId, title, text, deadline) {
        var url = this.serviceUrl + '/' + noteId,
            data = {};

        if (title) {
            data.title = title;
        }

        if (text) {
            data.text = text;
        }

        if (deadline) {
            data.text = deadline;
        }

        return this.requester.put(url, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.deleteNote = function (noteId) {
        var url = this.serviceUrl + '/' + noteId;

        return this.requester.remove(url, this.headers.getHeaders(true));
    };

    return {
        load: function (baseUrl, requester, headers) {
            return new NoteModel(baseUrl, requester, headers);
        }
    }
})();