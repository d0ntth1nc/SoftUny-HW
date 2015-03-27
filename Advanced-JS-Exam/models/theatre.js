var imdb = imdb || {};

(function() {
	'use strict';
	
	function Theatre( title, length, rating, country, isPuppet ) {
		this.title = title;
		this.length = length;
		this.rating = rating;
		this.country = country;
		this.isPuppet = isPuppet;
		this._actors = [];
		this._reviews = [];
	}
	
	Theatre.prototype.addActor = function( actor ) {
		this._actors.push( actor );
	};
	
	Theatre.prototype.removeActor = function( actor ) {
		var newArr = [];
		this._actors.forEach(function( __actor ) {
			if (__actor != actor) {
				newArr.push( __actor );
			}
		});
		
		this._actors = newArr;
	};
	
	Theatre.prototype.removeActorById = function( id ) {
		var newArr = [];
		this._actors.forEach(function( actor ) {
			if (actor._id != id) {
				newArr.push( actor );
			}
		});
		
		this._actors = newArr;
	};

	Theatre.prototype.getActors = function() {
		return this._actors;
	};
	
	Theatre.prototype.addReview = function( review ) {
		this._reviews.push( review );
	};
	
	Theatre.prototype.removeReview = function( review ) {
		var newArr = [];
		this._actors.forEach(function( __review ) {
			if (__review != review) {
				newArr.push( __review );
			}
		});
		
		this._reviews = newArr;
	};
	
	Theatre.prototype.removeReviewById = function( id ) {
		var newArr = [];
		this._actors.forEach(function( review ) {
			if (review._id != id) {
				newArr.push( review );
			}
		});
		
		this._reviews = newArr;
	};
	
	Theatre.prototype.getReviews = function() {
		return this._reviews;
	};
	
	imdb.getTheatre = function( title, length, rating, country, isPuppet ) {
		var theatre = new Theatre( title, length, rating, country, isPuppet );
		theatre._id = imdb._getNextId();
		
		return theatre;
	};
}());