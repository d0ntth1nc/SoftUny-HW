var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		moviesContainer.addEventListener('click', function( e ) {
			if (e.target.tagName === 'LI' ||
				e.target.tagName === 'DIV' ||
				e.target.tagName === 'H3') {
				var movies = [],
					movieId,
					movie;
					
				movieId = parseInt( e.target.getAttribute( 'data-id' ) );
				if (isNaN(movieId)) {
					movieId = parseInt( e.target.parentNode.getAttribute( 'data-id') );
				}
				
				for (var i = 0, len = data.length; i < len; i++) {
					var genre = data[ i ];
					movies = movies.concat( genre.getMovies() );
				}
				
				movie = movies.filter(function( __movie ) {
					return __movie._id === movieId;
				});
				
				clearDetailsContainer();
				
				detailsHtml = loadDetails(movie[0]);
				detailsContainer.appendChild(detailsHtml);
			} else if (e.target.tagName === 'BUTTON') {
				var moviesUl = moviesContainer.querySelector('ul');
				
				var id = e.target.getAttribute('data-id'),
					liToRemove = e.target.parentNode;
				moviesUl.removeChild(liToRemove);
				
				clearDetailsContainer();
				deleteMovie( id );
			}
		});
		
		function clearDetailsContainer() {
			while (detailsContainer.firstChild) {
				detailsContainer.removeChild(detailsContainer.firstChild);
			}
		}
	
		function deleteMovie( id ) {
			for (var i = 0, len = data.length; i < len; i++) {
				data[ i ].deleteMovieById( id );
			}
		}
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
			var liMovie = document.createElement('li');
				
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			liMovie.innerHTML += '<button data-id=' + movie._id + '>Delete movie</button>';
			
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	function loadDetails(movie) {
		var actors = movie.getActors(),
			reviews = movie.getReviews(),
			docFragment = document.createDocumentFragment(),
		
			actorsContainer = document.createElement( 'div' ),
			reviewsContainer = document.createElement( 'div' ),
			actorsHeader = document.createElement( 'h1' ),
			reviewsHeader = document.createElement( 'h1' ),
			actorsUl = document.createElement( 'ul' ),
			reviewsUl = document.createElement( 'ul' );
			
		actorsHeader.innerText = 'Actors';
		actorsContainer.appendChild( actorsHeader );
		actorsContainer.appendChild( actorsUl );
		
		reviewsHeader.innerText = 'Reviews';
		reviewsContainer.appendChild( reviewsHeader );
		reviewsContainer.appendChild( reviewsUl );
		
		for (var i = 0, len = actors.length; i < len; i++) {
			var actor = actors[ i ],
				actorLi = document.createElement( 'li' ),
				actorNameP = document.createElement( 'p' ),
				actorBioP = document.createElement( 'p' ),
				actorBornP = document.createElement( 'p' );
				
			actorNameP.innerText = actor.name;
			actorBioP.innerText = 'Bio: ' + actor.bio;
			actorBornP.innerText = 'Born: ' + actor.dateOfBirth;
				
			actorLi.appendChild( actorNameP );
			actorLi.appendChild( actorBioP );
			actorLi.appendChild( actorBornP );
			actorsUl.appendChild( actorLi );
		}
		
		docFragment.appendChild(actorsContainer);
		
		for (var i = 0, len = reviews.length; i < len; i++) {
			var review = reviews[ i ],
				reviewLi = document.createElement( 'li' ),
				reviewNameP = document.createElement( 'p' ),
				reviewContentP = document.createElement( 'p' ),
				reviewCreatedP = document.createElement( 'p' );
				
			reviewNameP.innerText = review.authorName;
			reviewContentP.innerText = 'Content: ' + review.content;
			reviewCreatedP.innerText = 'Created: ' + review.createdOn;
				
			reviewLi.appendChild( reviewNameP );
			reviewLi.appendChild( reviewContentP );
			reviewLi.appendChild( reviewCreatedP );
			reviewsUl.appendChild( reviewLi );
		}
		
		docFragment.appendChild(reviewsContainer);
		
		return docFragment;
	}
	
	scope.loadHtml = loadHtml;
}(imdb));