"use strict";
var models = models || {};

(function( models ) {

var
	PARSE_DOT_COM_HEADER = {
		"X-Parse-Application-Id": "UucnOhHWKvI7reaJdeDgy5soLhWm96Nu4jZSrNc7",
		"X-Parse-REST-API-Key": "5ntRNlqRapavThJZ9Vj5ITZqlVjTJ6INe0Hcowjo"
	},
	URL = "https://api.parse.com/1/classes/";
	
function ParseObject( serverResponse ) {
	if ( typeof serverResponse == "object" ) {
		var keys = Object.keys( serverResponse ),
			self = this;
			
		keys.forEach(function( key ) {
			if ( key === "objectId" ) {
				self.id = serverResponse[ key ];
			} else if ( key === "createdAt" || key === "updatedAt" ) {
				self[ key ] = new Date( serverResponse[ key ] )
					.toLocaleString();
			} else {
				self[ key ] = serverResponse[ key ];
			}
		});
		
		if ( !this.updatedAt ) {
			this.updatedAt = this.createdAt;
		}
		
		this._existsOnServer = true;
	} else {
		this._existsOnServer = false;
	}
}

function save() {
	var url = URL + this.constructor.name,
		deferred = $.Deferred(),
		data = {};
		
	Object
		.keys( this )
		.forEach($.proxy(function( key ) {
			if ( this.hasOwnProperty( key ) &&
					key !== "_existsOnServer" &&
					key !== "id" &&
					key !== "updatedAt" &&
					key !== "createdAt" ) {
				data[ key ] = this[ key ];
			}
		}, this ));

	$.ajax({
		method: this._existsOnServer ? "PUT" : "POST",
		url: this._existsOnServer ? url + "/" + this.id : url,
		data: JSON.stringify( data ),
		headers: PARSE_DOT_COM_HEADER,
		context: this
	})
	.done(function( response ) {
		this.constructor.call( this, response );
		deferred.resolveWith( this );
	})
	.fail( $.proxy( deferred.reject, this ) );
	
	return deferred.promise();
}

function remove() {
	var deferred = $.Deferred();
	
	if ( this._existsOnServer ) {
		$.ajax({
			method: "DELETE",
			url: URL + this.constructor.name + "/" + this.id,
			headers: PARSE_DOT_COM_HEADER
		})
		.done( $.proxy( deferred.resolve, this ) )
		.fail( $.proxy( deferred.reject, this ) );
	} else {
		deferred.resolveWith( this );
	}
	
	return deferred.promise();
}

ParseObject.prototype = {
	save: save,
	remove: remove,
	constructor: ParseObject
}

ParseObject.loadAll = function( params ) {
	var deferred = $.Deferred();
	
	$.ajax({
		method: "GET",
		url: URL + this.name,
		headers: PARSE_DOT_COM_HEADER,
		data: params,
		context: this
	})
	.done(function( response ) {
		var Constructor = this,
			countries = response.results.map(function( country ) {
				return new Constructor( country );
			});
		
		deferred.resolve( countries );
	})
	.fail( $.proxy( deferred.reject, this ) );
	
	return deferred.promise();
};

models.ParseObject = ParseObject;

}( models ));