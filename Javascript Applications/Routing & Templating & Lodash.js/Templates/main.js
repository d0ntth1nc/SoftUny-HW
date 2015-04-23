"use strict";
(function( Handlebars ) {

var source = document.getElementById( "table-template" ).innerHTML,
	template = Handlebars.compile( source ),
	people = [
		{ name: "Bob Marley", jobTitle: "Weed smoker", website: "http://bobmarley.com" },
		{ name: "Charlie Chaplin", jobTitle: "Dead walker", website: "http://charlie.com" },
		{ name: "Aziz Asis", jobTitle: "*** sucker", website: "http://azis.com" },
		{ name: "Bat Georgi", jobTitle: "Manager", website: "http://satana.za.dinko.com" },
	];

document
	.getElementById( "container" )
	.innerHTML = template( people );

}( Handlebars ));