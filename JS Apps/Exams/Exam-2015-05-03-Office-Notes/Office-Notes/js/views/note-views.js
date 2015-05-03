var app = app || {};

app.noteViews = (function () {
    function NoteViews() {
        this.listNotes = {
            listNotes: loadNotesView
        };

        this.listCurrentUserNotes = {
            listCurrentUserNotes: loadOwnedNotesView
        };

        this.addNote = {
            loadAddNoteView: addNoteView
        };

        this.editNote = {
            loadEditNoteView: editNoteView
        };

        this.deleteNote = {
            loadDeleteNoteView: deleteNoteView
        }
    }

    function getFormattedDate(date) {
        var year = date.split('-')[2],
            month = (parseInt(date.split('-')[0]) < 10 ? '0' : '') + date.split('-')[0],
            day = (parseInt(date.split('-')[1]) < 10 ? '0' : '') + date.split('-')[1];

        return year + '-' + month + '-' + day;
    }

    function loadOwnedNotesView(selector, data) {
        $.get('templates/myNoteTemplate.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: 10,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/myNotes/'
            }).pagination('selectPage', '#/myNotes/');

            $('.edit').click(function () {
                var $this = $(this),
                    id = $this.attr('data-id'),
                    title = $this.attr('data-title'),
                    text = $this.attr('data-text'),
                    deadline = $this.attr('data-deadline'),
                    redirectUrl = '#/editNote/id=' + id + '&title=' + title + '&text=' + text + '&deadline=' + deadline;

                window.location.replace(redirectUrl);
            });

            $('.delete').click(function () {
                var $this = $(this),
                    id = $this.attr('data-id'),
                    title = $this.attr('data-title'),
                    text = $this.attr('data-text'),
                    deadline = $this.attr('data-deadline'),
                    redirectUrl = '#/deleteNote/id=' + id + '&title=' + title + '&text=' + text + '&deadline=' + deadline;

                window.location.replace(redirectUrl);
            });
        });
    }

    function loadNotesView(selector, data) {
        $.get('templates/officeNoteTemplate.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: 10,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/office/'
            }).pagination('selectPage', '#/office/');

            $('.edit').click(function () {
                var $this = $(this),
                    id = $this.attr('data-id'),
                    title = $this.attr('data-title'),
                    text = $this.attr('data-text'),
                    deadline = $this.attr('data-deadline'),
                    redirectUrl = '#/editNote/id=' + id + '&title=' + title + '&text=' + text + '&deadline=' + deadline;

                window.location.replace(redirectUrl);
            });

            $('.delete').click(function () {
                var $this = $(this),
                    id = $this.attr('data-id'),
                    title = $this.attr('data-title'),
                    text = $this.attr('data-text'),
                    deadline = $this.attr('data-deadline'),
                    redirectUrl = '#/deleteNote/id=' + id + '&title=' + title + '&text=' + text + '&deadline=' + deadline;

                window.location.replace(redirectUrl);
            });
        });
    }

    function addNoteView(selector) {
        $.get('templates/addNote.html', function (template) {
            var outHtml = Mustache.render(template);

            $(selector).html(outHtml);
        }).then(function () {
            $('#addNoteButton').click(function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = new Date($('#deadline').val()).toLocaleDateString();

                deadline = getFormattedDate(deadline.split('/').join('-'));

                $.sammy(function () {
                    this.trigger('addNote', {title: title, text: text, deadline: deadline});
                });

                return false;
            });
        });
    }

    function editNoteView(selector, data) {
        $.get('templates/editNote.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#editNoteButton').click(function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val();

                $.sammy(function () {
                    this.trigger('editNote', {id: data.id, title: title, text: text, deadline: deadline});
                });

                return false;
            });
        });
    }

    function deleteNoteView(selector, data) {
        $.get('templates/deleteNote.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#deleteNoteButton').click(function () {
                $.sammy(function () {
                    this.trigger('deleteNote', {id: data.id});
                });

                return false;
            });
        });
    }

    return {
        load: function () {
            return new NoteViews();
        }
    }
})();