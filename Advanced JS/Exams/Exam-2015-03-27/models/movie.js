var imdb = imdb || {};

(function (scope) {
    'use strict';

    var idCounter = 0;

    function Movie(title, lengthInMinutes, rating, country) {
        idCounter++;
        this._id = idCounter;
        this.title = title;
        this.length = lengthInMinutes;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
    }

    Movie.prototype.addActor = function (actor) {
        this._actors.push(actor);
    }

    Movie.prototype.getActors = function () {
        return this._actors;
    }

    Movie.prototype.addReview = function (review) {
        this._reviews.push(review);
    }

    Movie.prototype.deleteReview = function (review) {
        var reviewIndex = this._reviews.indexOf(review);

        if (reviewIndex !== -1) {
            this._reviews.splice(reviewIndex, 1);
        }
    }

    Movie.prototype.deleteReviewById = function (reviewId) {
        var reviewIndex,
            index;

        for (index in this._reviews) {
            if (this._reviews[index]._id === reviewId) {
                reviewIndex = index;
                break;
            }
        }

        if (reviewIndex) {
            this._reviews.splice(reviewIndex, 1);
        }
    }

    Movie.prototype.getReviews = function () {
        return this._reviews;
    }

    scope._movie = Movie;

    scope.getMovie = function (title, lengthInMinutes, rating, country) {
        return new Movie(title, lengthInMinutes, rating, country);
    }
})(imdb);