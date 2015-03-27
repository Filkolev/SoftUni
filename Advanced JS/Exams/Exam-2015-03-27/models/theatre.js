var imdb = imdb || {};

(function (scope) {
    'use strict';

    function Theatre(name, lengthInMinutes, rating, country, isPuppet) {
        scope._movie.call(this, name, lengthInMinutes, rating, country);
        this.isPuppet = isPuppet;
    }

    Theatre.prototype = Object.create(scope._movie.prototype);
    Theatre.prototype.constructor = Theatre;

    scope.getTheatre = function (name, lengthInMinutes, rating, country, isPuppet) {
        return new Theatre(name, lengthInMinutes, rating, country, isPuppet);
    }
})(imdb);