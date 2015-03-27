var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

        function getAllMovies() {
            var movies = [];

            data.forEach(function (genre) {
                var moviesPerGenre = genre.getMovies();
                movies = movies.concat(moviesPerGenre);
            });

            return movies;
        }

        function deleteMovie(ev) {
            var parentDomElement = document.querySelector('div#movies ul'),
                liElementToRemove;

            movieId = parseInt(ev.target.dataset.id);

            data.forEach(function (genre) {
                genre.deleteMovieById(movieId);
            });

            liElementToRemove = parentDomElement.querySelector('li[data-id="' + movieId + '"]');
            parentDomElement.removeChild(liElementToRemove);
            detailsContainer.innerHTML = '';
        }

        function showMovieInfo(target) {
            var movieId = parseInt(target.dataset.id),
                allMovies = getAllMovies(),
                movieToShow,
                actorsHtml,
                reviewsHtml;

            movieToShow = allMovies.filter(function (movie) {
                return movie._id === movieId;
            })[0];

            actorsHtml = loadActors(movieToShow);
            reviewsHtml = loadReviews(movieToShow);

            detailsContainer.innerHTML = actorsHtml.outerHTML;
            detailsContainer.innerHTML += reviewsHtml.outerHTML;
        }

        container.appendChild(genresUl);

        genresUl.addEventListener('click', function (ev) {
            var genreId,
				genre,
				moviesHtml;

            if (ev.target.tagName === 'LI') {
                genreId = parseInt(ev.target.getAttribute('data-id'));
                genre = data.filter(function (genre) {
                    return genre._id === genreId;
                })[0];

                moviesHtml = loadMovies(genre.getMovies());
                moviesContainer.innerHTML = moviesHtml.outerHTML;
                moviesContainer.setAttribute('data-genre-id', genreId);
                detailsContainer.innerHTML = '';
            }
        });

        moviesContainer.addEventListener('click', function (ev) {
            var isMovieClicked,
                target;

            if (ev.target.tagName === 'BUTTON') {
                deleteMovie(ev);
            } else {
                if (ev.srcElement.nodeName === 'LI') {
                    isMovieClicked = true;
                    target = ev.srcElement;
                } else if (ev.srcElement.parentElement.nodeName === 'LI') {
                    isMovieClicked = true;
                    target = ev.srcElement.parentElement;
                }

                if (isMovieClicked) {
                    showMovieInfo(target);
                }
            }
        });

        detailsContainer.addEventListener('click', function (ev) {
            var movieId = parseInt(document.getElementById('reviews-section').getAttribute('data-id')),
                reviewId,
                parentUl,
                domElementToRemove,
                allMovies;

            if (ev.target.tagName === 'BUTTON') {
                reviewId = parseInt(ev.target.getAttribute('data-id'));

                allMovies = getAllMovies();

                allMovies.forEach(function (movie) {
                    if (movie._id === movieId) {
                        movie.deleteReviewById(reviewId);
                    }
                });

                parentUl = detailsContainer.querySelector('section#reviews-section ul');
                domElementToRemove = detailsContainer.querySelector('section#reviews-section li[data-id="' + reviewId + '"]');
                parentUl.removeChild(domElementToRemove);
            }
        });
    }

    function loadGenres(genres) {
        var genresUl = document.createElement('ul');
        genresUl.setAttribute('class', 'nav navbar-nav');
        genres.forEach(function (genre) {
            var liGenre = document.createElement('li');
            liGenre.innerHTML = genre.name;
            liGenre.setAttribute('data-id', genre._id);
            genresUl.appendChild(liGenre);
        });

        return genresUl;
    }

    function loadMovies(movies) {
        var moviesUl = document.createElement('ul');
        movies.forEach(function (movie) {
            var liMovie = document.createElement('li'),
                deleteMovieButton = document.createElement('button');

            liMovie.setAttribute('data-id', movie._id);
            deleteMovieButton.innerHTML = 'Delete movie';
            deleteMovieButton.setAttribute('data-id', movie._id);

            liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
            liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
            liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
            liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
            liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
            liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
            liMovie.innerHTML += deleteMovieButton.outerHTML;

            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    function loadActors(movie) {
        var actors = movie.getActors(),
            actorsSection = document.createElement('section'),
            actorsHeading = document.createElement('h2'),
            actorsUl = document.createElement('ul');

        actorsHeading.innerHTML = 'Actors';

        actorsSection.id = 'actors-section';
        actorsSection.appendChild(actorsHeading);

        actors.forEach(function (actor) {
            var liActor = document.createElement('li');
            liActor.setAttribute('data-id', actor._id);

            liActor.innerHTML = '<h4>' + actor.name + '</h4>';
            liActor.innerHTML += '<div><strong>Bio:</strong> ' + actor.bio + '</div>';
            liActor.innerHTML += '<div><strong>Born:</strong> ' + actor.born + '</div>';

            actorsUl.appendChild(liActor);
        });

        actorsSection.appendChild(actorsUl);

        return actorsSection;
    }

    function loadReviews(movie) {
        var reviews = movie.getReviews(),
            reviewsSection = document.createElement('section'),
            reviewsHeading = document.createElement('h2'),
            reviewsUl = document.createElement('ul'),
            noReviewsMessage;

        reviewsHeading.innerHTML = 'Reviews';

        reviewsSection.id = 'reviews-section';
        reviewsSection.setAttribute('data-id', movie._id);
        reviewsSection.appendChild(reviewsHeading);

        if (reviews.length === 0) {
            noReviewsMessage = document.createElement('h4');
            noReviewsMessage.innerHTML = 'No reviews';

            reviewsUl.appendChild(noReviewsMessage);
        } else {
            reviews.forEach(function (review) {
                var liReview = document.createElement('li'),
                    reviewDeleteButton = document.createElement('button');

                liReview.setAttribute('data-id', review._id);

                reviewDeleteButton.innerHTML = 'Delete review';
                reviewDeleteButton.setAttribute('data-id', review._id);

                liReview.innerHTML = '<h4>' + review.author + '</h4>';
                liReview.innerHTML += '<div><strong>Content:</strong> ' + review.content + '</div>';
                liReview.innerHTML += '<div><strong>Date:</strong> ' + review.date + '</div>';
                liReview.innerHTML += reviewDeleteButton.outerHTML;

                reviewsUl.appendChild(liReview);
            });
        }

        reviewsSection.appendChild(reviewsUl);

        return reviewsSection;
    }

    scope.loadHtml = loadHtml;
}(imdb));