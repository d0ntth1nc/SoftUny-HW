"use strict";
var models = models || {};

(function( models ) {
var
	PARSE_DOT_COM_HEADER = {
		"X-Parse-Application-Id": "UucnOhHWKvI7reaJdeDgy5soLhWm96Nu4jZSrNc7",
		"X-Parse-REST-API-Key": "5ntRNlqRapavThJZ9Vj5ITZqlVjTJ6INe0Hcowjo"
	},
	URL = "https://api.parse.com/1/classes/";
	
function Country( name ) {
	this.name = name || "undefined";
	this.objectId = "";
}

function save() {
	var url = URL + this.constructor.name,
		deferred = $.Deferred();
	
	if ( this.objectId ) {
		url += "/" + this.objectId;
	}
	
	$.ajax({
		method: this.objectId ? "PUT" : "POST",
		url: url,
		data: JSON.stringify( this ),
		headers: PARSE_DOT_COM_HEADER,
		context: this
	})
	.done(function( data ) {
		// Save important data so we can sync later
		if ( !this.objectId ) {
			this.objectId = data.objectId;
		}
		this.sync().done( deferred.resolve ).fail( deferred.reject );
	})
	.fail( deferred.reject );
	
	return deferred.promise();
}

function remove() {
	return $.ajax({
		method: "DELETE",
		url: URL + this.constructor.name + "/" + this.objectId,
		headers: PARSE_DOT_COM_HEADER
	});
}

function sync() {
	var deferred = $.Deferred();
	
	$.ajax({
		method: "GET",
		url: URL + this.constructor.name + "/" + this.objectId,
		headers: PARSE_DOT_COM_HEADER,
		context: this
	})
	.done(function( data ) {
		for ( var prop in data ) {
			this[ prop ] = data[ prop ];
		}
		
		deferred.resolve();
		
		noty({
			text: this.constructor.name + " successfully updated!",
			timeout: 1000
		});
	})
	.fail( deferred.reject );
	
	return deferred.promise();
}

Country.prototype = {
	save: save,
	remove: remove,
	sync: sync,
	constructor: Country
}

Country.loadAll = function() {
	var deferred = $.Deferred();
	
	$.ajax({
		method: "GET",
		url: URL + this.name,
		headers: PARSE_DOT_COM_HEADER,
		context: this
	})
	.done(function( data ) {
		data = data.results;
		var countries = [];
		
		for ( var i = 0, len = data.length; i < len; i++ ) {
			var entry = data[ i ],
				country = new this( entry.name );
				
			$.extend( country, entry );
			countries.push( country );
		}
		
		deferred.resolve( countries );
	})
	.fail( deferred.reject );
	
	return deferred.promise();
};

models.Country = Country;

}( models ));