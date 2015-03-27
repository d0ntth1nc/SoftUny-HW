var imdb = imdb || {};

(function() {
	'use strict';
	var nextId = 1;
	
	function Genre( name ) {
		this.name = name;
		this._movies = [];
	}
	
	Genre.prototype.addMovie = function( movie ) {
		this._movies.push( movie );
	};
	
	Genre.prototype.deleteMovie = function( movie ) {
		var newArr = [];
		this._movies.forEach(function( __movie ) {
			if (__movie != movie) {
				newArr.push( __movie );
			}
		});
		
		this._movies = newArr;
	};
	
	Genre.prototype.deleteMovieById = function( id ) {
		var newArr = [];
		this._movies.forEach(function( movie ) {
			if (movie._id != id) {
				newArr.push( movie );
			}
		});
		
		this._movies = newArr;
	};
	
	Genre.prototype.getMovies = function() {
		return this._movies;
	};
	
	imdb.getGenre = function( name ) {
		var genre = new Genre( name );
		genre._id = nextId;
		nextId++;
		
		return genre;
	};
}());