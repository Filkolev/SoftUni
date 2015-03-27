var imdb = imdb || {};

(function (scope) {
	var genres = [],
		movies = [],
		reviews = [],
		actors = [];

	function generateData() {
		var genreAction,
			genreComedy,
			genreRomantic;
		var movieGodfather,
			movieDarkKnight,
			movieInception,
			moviePrestige,
			movieGoodfellas,
			movieInterstellar,
			movieCasablanca,
			moviePsycho,
			movieWhiplash,
			movieMemento,
			movieGladiator,
			movieAliens,
			movieTaxiDriver,
			theatreInsurgent,
			theatreCinderella,
			theatreFocus,
			theatreChappie;

		// Generate genres
		genreAction = imdb.getGenre('Action');
		genreComedy = imdb.getGenre('Comedy');
		genreRomantic = imdb.getGenre('Romantic');
		genres = [genreAction, genreComedy, genreRomantic];

		// Generate Movies
		movieGodfather = imdb.getMovie('The Godfather', 220, 9.1, 'USA');
		movieDarkKnight = imdb.getMovie('Dark Knight', 117, 9.0, 'UK');
		movieInception = imdb.getMovie('Inception', 110, 8.1, 'Brazil');
		moviePrestige = imdb.getMovie('The Prestige', 89, 8.3, 'Germany');
		movieGoodfellas = imdb.getMovie('Goodfellas', 102, 8.7, 'Bulgaria');
		movieInterstellar = imdb.getMovie('Interstellar', 96, 7.6, 'Turkey');
		movieCasablanca = imdb.getMovie('Casablanca', 80, 7.9, 'Netherlands');
		moviePsycho = imdb.getMovie('Psycho', 108, 8.0, 'USA');
		movieWhiplash = imdb.getMovie('Whiplash', 115, 8.2, 'UK');
		movieMemento = imdb.getMovie('Memento', 123, 7.2, 'Cuba');
		movieGladiator = imdb.getMovie('Gladiator', 145, 7.5, 'Canada');
		movieAliens = imdb.getMovie('Aliens', 123, 7.4, 'Spain');
		movieTaxiDriver = imdb.getMovie('Taxi Driver', 133, 7.3, 'Bulgaria');
		theatreInsurgent = imdb.getTheatre('Insurgent', 103, 8.6, 'Romania');
		theatreCinderella = imdb.getTheatre('Cinderella', 122, 5.3, 'Greece');
		theatreFocus = imdb.getTheatre('Focus', 121, 6.3, 'Bulgaria');
		theatreChappie = imdb.getTheatre('Chappie', 111, 4.9, 'USA');

		// Add movies to genres
		genreComedy.addMovie(theatreInsurgent);
		genreComedy.addMovie(theatreFocus);
		genreComedy.addMovie(theatreChappie);
		genreComedy.addMovie(moviePsycho);
		genreAction.addMovie(movieInception);
		genreAction.addMovie(movieGodfather);
		genreAction.addMovie(movieDarkKnight);
		genreAction.addMovie(movieInterstellar);
		genreAction.addMovie(movieMemento);
		genreAction.addMovie(movieGladiator);
		genreRomantic.addMovie(moviePrestige);
		genreRomantic.addMovie(movieGoodfellas);
		genreRomantic.addMovie(movieCasablanca);
		genreRomantic.addMovie(movieWhiplash);
		genreRomantic.addMovie(movieAliens);
		genreRomantic.addMovie(movieTaxiDriver);
		genreRomantic.addMovie(theatreCinderella);

		movies = [movieGodfather, 
			movieDarkKnight,
			movieInception,
			moviePrestige,
			movieGoodfellas,
			movieInterstellar,
			movieCasablanca,
			moviePsycho,
			movieWhiplash,
			movieMemento,
			movieGladiator,
			movieAliens,
			movieTaxiDriver,
			theatreInsurgent,
			theatreCinderella,
			theatreFocus,
			theatreChappie
		];

		// Generate actors
		var actor1 = imdb.getActor('Jack Nicholson', 'Jack Nicholson, an American actor, producer, screenwriter and director, is a three-time Academy Award winner and 12-time nominee.', new Date(1937, 4, 22));
		var actor2 = imdb.getActor('Ralph Fiennes', 'He is the eldest of six children. Four of his siblings are also in the arts: Martha Fiennes, a director; Magnus Fiennes, a musician; Sophie, a producer; and Joseph Fiennes, an actor.', new Date(1962, 12, 22));
		var actor3 = imdb.getActor('Robert De Niro', 'Robert De Niro, thought of as one of the greatest American actors of all time, was born in New York City, to artists Virginia (Admiral) and Robert De Niro Sr. ', new Date(1943, 8, 17));
		var actor4 = imdb.getActor('Al Pacino', 'One of the greatest actors in all of film history, Al Pacino established himself during one of film\'s greatest decades, the 1970s, and has become an enduring and iconic figure in the world of American movies.', new Date(1940, 4, 25));
		var actor5 = imdb.getActor('Dustin Hoffman', 'Dustin Lee Hoffman was born in Los Angeles, California, to Lillian (Gold) and Harry Hoffman, who was a furniture salesman and prop supervisor for Columbia Pictures. He was raised in a Jewish family (from Ukraine, Russia-Poland, and Romania).', new Date(1937, 8, 8));
		var actor6 = imdb.getActor('Brad Pitt', 'An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winning actor Brad Pitt\'s most widely recognized role may be Tyler Durden in Fight Club.', new Date(1963, 12, 18));
		var actor7 = imdb.getActor('Anthony Hopkins', 'His parents were both of half Welsh and half English descent. Influenced by Richard Burton, he decided to study at College of Music and Drama and graduated in 1957.', new Date(1937, 12, 31));
		var actor8 = imdb.getActor('Leonardo DiCaprio', 'Few actors in the world have had a career quite as diverse as Leonardo DiCaprio\'s. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains and low budget horror movies, such as Critters 3, to a major teenage heartthrob in the 1990s, as the hunky lead actor in movies such as Romeo + Juliet', new Date(1974, 11, 11));
		var actor9 = imdb.getActor('Mel Gibson', 'Mel Columcille Gerard Gibson was born on January 3, 1956, in Peekskill, New York, USA as the sixth of eleven children to parents Hutton Gibson, a railroad brakeman, and Anne Patricia (Reilly) Gibson (who died in December of 1990). ', new Date(1956, 1, 3));
		var actor10 = imdb.getActor('Nicolas Cage', 'Nicolas Cage was born in Long Beach, California, the son of comparative literature professor August Coppola (a brother of director Francis Ford Coppola) and dancer/choreographer Joy Vogelsang. He is of Italian (father) and German, English, and Polish (mother) descent.', new Date(1964, 1, 7));

		// Add actors to movies
		movieGodfather.addActor(actor1);
		movieGodfather.addActor(actor4);
		movieDarkKnight.addActor(actor7);
		movieDarkKnight.addActor(actor9);
		movieDarkKnight.addActor(actor3);
		movieDarkKnight.addActor(actor6);
		movieInception.addActor(actor2);
		movieInception.addActor(actor5);
		movieInception.addActor(actor8);
		moviePrestige.addActor(actor9);
		moviePrestige.addActor(actor1);
		moviePrestige.addActor(actor7);
		movieGoodfellas.addActor(actor5);
		movieGoodfellas.addActor(actor3);
		movieGoodfellas.addActor(actor6);
		movieInterstellar.addActor(actor9);
		movieInterstellar.addActor(actor3);
		movieInterstellar.addActor(actor1);
		movieCasablanca.addActor(actor5);
		movieCasablanca.addActor(actor6);
		movieCasablanca.addActor(actor7);
		movieCasablanca.addActor(actor8);
		moviePsycho.addActor(actor1);
		moviePsycho.addActor(actor10);
		movieWhiplash.addActor(actor8);
		movieWhiplash.addActor(actor5);
		movieMemento.addActor(actor10);
		movieMemento.addActor(actor5);
		movieMemento.addActor(actor3);
		movieGladiator.addActor(actor7);
		movieGladiator.addActor(actor3);
		movieAliens.addActor(actor2);
		movieAliens.addActor(actor8);
		movieTaxiDriver.addActor(actor2);
		movieTaxiDriver.addActor(actor9);
		movieTaxiDriver.addActor(actor1);
		theatreInsurgent.addActor(actor7);
		theatreInsurgent.addActor(actor6);
		theatreInsurgent.addActor(actor9);
		theatreCinderella.addActor(actor5);
		theatreCinderella.addActor(actor3);
		theatreFocus.addActor(actor4);
		theatreFocus.addActor(actor9);
		theatreChappie.addActor(actor2);
		theatreChappie.addActor(actor3);

		// TODO: Generate reviews
		var review1 = imdb.getReview('Jiko Trapeca', 'Mnou qk film', new Date(2014, 9, 23));
		var review2 = imdb.getReview('Mincho Gyrba', 'Kopele she sa razcepish', new Date(2014, 9, 23));
		var review3 = imdb.getReview('Marko Trabanta', 'Mnogo rev. Nqma takava boza.', new Date(2014, 9, 23));
		var review4 = imdb.getReview('Geco Kombainata', 'Stava za vendyj na rabota', new Date(2014, 9, 23));
		var review5 = imdb.getReview('Shuri Kirkata', 'Maina, gledai go, che i ti da si zagubish vremeto', new Date(2014, 9, 23));
		var review6 = imdb.getReview('Trapo Genov', 'Ot typ po typ', new Date(2014, 9, 23));
		var review7 = imdb.getReview('Geno Arpadjika', 'Tiq ot IMDB reitinga im kuca neshto', new Date(2014, 9, 23));
		var review8 = imdb.getReview('Dimka Lopatata', 'Gledam go za 3ti pyt i nishto ne shvashtam', new Date(2014, 9, 23));
		var review9 = imdb.getReview('Maca Bosileka', 'Brato mnogo si typ, bace.', new Date(2014, 9, 23));
		var review10 = imdb.getReview('Tiro Durdunkov', 'Nqma takyv film. Za sefte mi e.', new Date(2014, 9, 23));
		var review11 = imdb.getReview('Haralampi Giuvecha', 'Hubav film', new Date(2014, 9, 23));
		var review12 = imdb.getReview('Trabi Traktorista', 'Gotino parche taq macka', new Date(2014, 9, 23));
		var review13 = imdb.getReview('Shina Bychvata', 'Na aktiora she mu skocha ako go nabaram', new Date(2014, 9, 23));

		// Add reviews to movies
		movieGodfather.addReview(review1);
		movieGodfather.addReview(review3);
		movieDarkKnight.addReview(review2);
		movieDarkKnight.addReview(review4);
		movieDarkKnight.addReview(review5);
		movieDarkKnight.addReview(review6);
		movieInception.addReview(review7);
		movieInception.addReview(review8);
		movieInception.addReview(review9);
		moviePrestige.addReview(review10);
		moviePrestige.addReview(review11);
		moviePrestige.addReview(review12);
		movieGoodfellas.addReview(review13);
		movieGoodfellas.addReview(review1);
		movieGoodfellas.addReview(review2);
		movieInterstellar.addReview(review3);
		movieInterstellar.addReview(review4);
		movieInterstellar.addReview(review5);
		movieCasablanca.addReview(review6);
		movieCasablanca.addReview(review7);
		movieCasablanca.addReview(review8);
		movieCasablanca.addReview(review9);
		moviePsycho.addReview(review10);
		moviePsycho.addReview(review11);
		movieWhiplash.addReview(review12);
		movieWhiplash.addReview(review13);
		movieMemento.addReview(review1);
		movieMemento.addReview(review2);
		movieMemento.addReview(review3);
		movieGladiator.addReview(review4);
		movieGladiator.addReview(review5);
		movieAliens.addReview(review6);
		movieAliens.addReview(review7);
		movieTaxiDriver.addReview(review8);
		movieTaxiDriver.addReview(review9);
		movieTaxiDriver.addReview(review10);
		theatreInsurgent.addReview(review11);
		theatreInsurgent.addReview(review12);
		theatreInsurgent.addReview(review13);
		theatreCinderella.addReview(review1);
		theatreCinderella.addReview(review2);
		theatreFocus.addReview(review6);
		theatreFocus.addReview(review8);
		theatreChappie.addReview(review11);
		theatreChappie.addReview(review7);
	}

	function getGenres() {
		return genres;
	}

	imdb.generateData = generateData;
	imdb.getGenres = getGenres;
}(imdb));