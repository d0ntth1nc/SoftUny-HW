var imdb = imdb || {};

(function() {
	'use strict';
	var nextId = 1;
	
	function Review( authorName, content, createdOn ) {
		this.authorName = authorName;
		this.content = content;
		this.createdOn = createdOn;
	}

	imdb.getReview = function( authorName, content, createdOn ) {
		var review = new Review( authorName, content, createdOn );
		review._id = nextId;
		nextId++;
		
		return review;
	};
}());