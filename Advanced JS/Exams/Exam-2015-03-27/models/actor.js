var imdb = imdb || {};

(function (scope) {
    'use strict';

    var idCounter = 0;

    function Actor(name, bio, born) {
        idCounter++;
        this._id = idCounter;
        this.name = name;
        this.bio = bio;
        this.born = born;
    }

    scope.getActor = function (name, bio, born) {
        return new Actor(name, bio, born);
    }
})(imdb);