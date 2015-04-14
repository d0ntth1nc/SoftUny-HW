"use strict";
var models = models || {};

(function( models ) {
    
var
	PARSE_DOT_COM_HEADER = {
		"X-Parse-Application-Id": "UucnOhHWKvI7reaJdeDgy5soLhWm96Nu4jZSrNc7",
		"X-Parse-REST-API-Key": "5ntRNlqRapavThJZ9Vj5ITZqlVjTJ6INe0Hcowjo"
	},
	URL = "https://api.parse.com/1/classes/";

function Town( name, country, id, createdAt, updatedAt ) {
	if ( typeof name == "object" ) {
		models.Country.call( this, name );
		name.country = name.country || {};
		this.country = name.country.name;
	} else {
		models.Country.call( this, name, id, createdAt, updatedAt );
		country = country || {};
		this.country = country.name;
	}
}

function save() {
	var country = this.country;
	
	if ( country ) {
		this.country = {
			"__type": "Pointer",
			"className": "Country",
			"objectId": country.objectId
		};
	}
	
	var url = URL + this.constructor.name,
		deferred = $.Deferred();
	
	if ( this.objectId ) {
		url += "/" + this.objectId;
	}
	
	$.ajax({
		method: this.objectId ? "PUT" : "POST",
		url: url,
		data: JSON.stringify( { name: this.name, country: this.country } ),
		headers: PARSE_DOT_COM_HEADER,
		context: this
	})
	.done(function( data ) {
		// Save important data so we can sync later
		if ( !this.objectId ) {
			this.objectId = data.objectId;
		}
		this.sync( "include=country" ).done( deferred.resolve ).fail( deferred.reject );
	})
	.fail( deferred.reject );
	
	return deferred.promise();
}

Town.prototype = {
	remove: models.Country.prototype.remove,
	sync: models.Country.prototype.sync,
	save: save,
	constructor: Town
};

Town.loadAll = models.Country.loadAll;

models.Town = Town;

}( models ));