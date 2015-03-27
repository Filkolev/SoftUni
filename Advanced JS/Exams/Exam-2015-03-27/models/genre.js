var imdb = imdb || {};

(function (scope) {
    'use strict';

    var idCounter = 0;

    function Genre(name) {
        idCounter++;
        this._id = idCounter;
        this.name = name;
        this._movies = [];
    }

    Genre.prototype.addMovie = function (movie) {
        this._movies.push(movie);
    }

    Genre.prototype.deleteMovie = function (movie) {
        var movieIndex = this._movies.indexOf(movie);

        if (movieIndex !== -1) {
            this._movies.splice(movieIndex, 1);
        }
    }

    Genre.prototype.deleteMovieById = function (movieId) {
        var movieIndex,
            index;

        for (index in this._movies) {
            if (this._movies[index]._id === movieId) {
                movieIndex = index;
                break;
            }
        }

        if (movieIndex) {
            this._movies.splice(movieIndex, 1);
        }
    }

    Genre.prototype.getMovies = function () {
        return this._movies;
    }

    scope.getGenre = function (name) {
        return new Genre(name);
    }
})(imdb);