"use strict";
var models = models || {};

(function( models ) {
var
	PARSE_DOT_COM_HEADER = {
		"X-Parse-Application-Id": "UucnOhHWKvI7reaJdeDgy5soLhWm96Nu4jZSrNc7",
		"X-Parse-REST-API-Key": "5ntRNlqRapavThJZ9Vj5ITZqlVjTJ6INe0Hcowjo"
	},
	URL = "https://api.parse.com/1/classes/";
	
function Country( name, id, createdAt, updatedAt ) {
	if ( typeof name == "object" ) {
		id = name.objectId;
		createdAt = name.createdAt;
		updatedAt = name.updatedAt;
		name = name.name;
	}
	
	this.name = name;
	this.objectId = id;
	this.createdAt = new Date( createdAt ).toLocaleString();
	this.updatedAt = new Date( updatedAt ).toLocaleString();
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
		data: JSON.stringify( { name: this.name } ),
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

function sync( params ) {
	var deferred = $.Deferred();
	
	$.ajax({
		method: "GET",
		url: URL + this.constructor.name + "/" + this.objectId,
		headers: PARSE_DOT_COM_HEADER,
		data: params,
		context: this
	})
	.done(function( country ) {
		this.constructor.call( this, country );
		
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

Country.loadAll = function( params ) {
	var deferred = $.Deferred();
	
	$.ajax({
		method: "GET",
		url: URL + this.name,
		headers: PARSE_DOT_COM_HEADER,
		data: params,
		context: this
	})
	.done(function( data ) {
		var self = this;
		var countries = data.results.map(function( country ) {
			return new self( country );
		});
		
		deferred.resolve( countries );
	})
	.fail( deferred.reject );
	
	return deferred.promise();
};

models.Country = Country;

}( models ));