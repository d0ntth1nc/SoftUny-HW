var imdb = imdb || {};

(function() {
	'use strict';
	var nextId = 1;
	
	function Movie( title, length, rating, country ) {
		this.title = title;
		this.length = length;
		this.rating = rating;
		this.country = country;
		this._actors = [];
		this._reviews = [];
	}
	
	Movie.prototype.addActor = function( actor ) {
		this._actors.push( actor );
	};
	
	Movie.prototype.getActors = function() {
		return this._actors;
	};
	
	Movie.prototype.addReview = function( review ) {
		this._reviews.push( review );
	};
	
	Movie.prototype.deleteReview = function( review ) {
		var newArr = [];
		this._reviews.forEach(function( __review ) {
			if (__review != review) {
				newArr.push( __review );
			}
		});
		
		this._reviews = newArr;
	};
	
	Movie.prototype.deleteReviewById = function( id ) {
		var newArr = [];
		this._reviews.forEach(function( review ) {
			if (review._id != id) {
				newArr.push( review );
			}
		});
		
		this._reviews = newArr;
	};
	
	Movie.prototype.getReviews = function() {
		return this._reviews;
	};
	
	imdb._getNextId = function() {
		return nextId++;
	};
	
	imdb.getMovie = function( title, length, rating, country ) {
		var movie = new Movie( title, length, rating, country );
		movie._id = imdb._getNextId();
		
		return movie;
	};
}());