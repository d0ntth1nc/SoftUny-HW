"use strict";
(function( $ ) {
	
String.prototype.startsWith = function( string ) {
	var i = 0, len = this.length, strLen = string.length;
	
	for ( ; i < len && i < strLen; i++ ) {
		if ( this[ i ] !== string[ i ] ) {
			return false;
		}
	}
	
	return true;
};

function onRowDeletion( e, row ) {
	row = $( row );
	var entry = row.data( "entry" );
	
	if ( entry ) {
		entry
			.remove()
			.done(function() {
				row.remove();
				noty({
					text: entry.constructor.name + " removed!",
					timeout: 1000
				});
			})
			.fail( showError );
	} else {
		row.remove();
	}
}

function showError( err ) {
	noty({
		text: err.message,
		timeout: 1000
	});
};

function onRowUpdated( e, row ) {
	$( row )
		.data( "entry" )
		.save()
		.done(function() {
			$( row ).closest( "table" ).trigger( "data-updated", row );
		})
		.fail( showError );
}

function initAutoComplete( e ) {
	if ( $( e.currentTarget ).attr( "data-editable" ) == "country" ) {
		var countries = $countriesTable.data( "countries" ).map(function( country ) {
			return { value: country.name, data: "" };
		});
		
		$( e.target ).autocomplete({
			lookup: countries
		});
	}
}

var $countriesTable, $townsTable;

$(function() {
	$countriesTable = $( "#countries-table" )
		.dynamicTable()
		.addHeader( [ "#", "Name", "Created", "Last updated" ] )
		.data( "countries", [] )
		.data( "model", { "objectId": false, "name": true, "createdAt": false, "updatedAt": false } )
		.on( "row-deletion", onRowDeletion )
		.on( "row-updated", function ( e, row ) {
			$( row )
				.data( "entry" )
				.save()
				.done(function() {
					$countriesTable.trigger( "data-updated", row );
				})
				.fail( showError );
		})
		.on( "add-row", function( e ) {
			var country = new models.Country();
			
			$countriesTable
				.addRows( [ country ] )
				.data( "countries" )
				.push( country );
		})
		.on( "click", "tr", function( e ) {
			var entry = $( e.currentTarget ).data( "entry" );
			$townsTable.filter( entry.name );
		});
		
	$townsTable = $( "#towns-table" )
		.dynamicTable()
		.addHeader( [ "#", "Name", "Country", "Created", "Last updated" ] )
		.data( "towns", [] )
		.data( "model", { "objectId": false, "name": true, "country": true, "createdAt": false, "updatedAt": false } )
		.on( "focus", "td", initAutoComplete )
		.on( "row-deletion", onRowDeletion )
		.on( "row-updated", function( e, row ) {
			var town = $( row ).data( "entry" ),
				countries = $countriesTable.data( "countries" ).filter( function( country ) {
					return country.name === town.country;
				});
			town.country = countries[ 0 ];
			town
				.save()
				.done(function() {
					$townsTable.trigger( "data-updated", row );
				})
				.fail( showError );
		})
		.on( "add-row", function( e ) {
			var town = new models.Town();
			
			$townsTable
				.addRows( [ town ] )
				.data( "towns" )
				.push( town );
		});
});

models
	.Country
	.loadAll()
	.done(function( countries ) {
		$(function() {
			$countriesTable
				.addRows( countries )
				.data( "countries", countries );
		});
	})
	.fail( showError );
	
models
	.Town
	.loadAll( "include=country" )
	.done(function( data ) {
		$(function() {
			$townsTable
				.addRows( data )
				.data( "towns", data );
		});
	})
	.fail( showError );

}( $ ));