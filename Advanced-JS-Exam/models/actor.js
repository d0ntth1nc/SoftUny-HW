var imdb = imdb || {};

(function() {
	'use strict';
	var nextId = 1;
	
	function Actor( name, bio, dateOfBirth ) {
		this.name = name;
		this.bio = bio;
		this.dateOfBirth = dateOfBirth;
	}

	
	imdb.getActor = function( name, bio, dateOfBirth ) {
		var actor = new Actor( name, bio, dateOfBirth );
		actor._id = nextId;
		nextId++;
		
		return actor;
	};
}());