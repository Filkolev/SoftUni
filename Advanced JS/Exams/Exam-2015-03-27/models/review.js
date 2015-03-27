var imdb = imdb || {};

(function (scope) {
    'use strict';

    var idCounter = 0;

    function Review(author, content, date) {
        idCounter++;
        this._id = idCounter;
        this.author = author;
        this.content = content;
        this.date = date;
    }

    scope.getReview = function (author, content, date) {
        return new Review(author, content, date);
    }
})(imdb);