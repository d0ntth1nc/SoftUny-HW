"use strict";
var models = models || {};

(function( models ) {

function Town( name, country ) {
	models.Country.call( this, name );
	this.country = country;
}

Town.prototype = Object.create( models.Country.prototype );
Town.prototype.constructor = Town;
Town.loadAll = models.Country.loadAll;

models.Town = Town;

}( models ));