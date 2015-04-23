"use strict";

Sammy(function() {
	this
		.get( "Sam", function() {
			$( "#greetings" ).text( "Hello, Sam!" );
		})
		.get( "Bob", function() {
			$( "#greetings" ).text( "Hello, Bob!" );
		})
		.get( "Sashe", function() {
			$( "#greetings" ).text( "Hello, Sashe!" );
		});
}).run( "#/" );