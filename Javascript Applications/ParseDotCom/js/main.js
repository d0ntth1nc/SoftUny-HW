"use strict";
(function( $ ) {

function onRowDeletion( e, row ) {
	$( row )
		.data( "entry" )
		.remove()
		.done(function() {
			$( row ).remove();
			noty({
				text: "Entry removed!",
				timeout: 1000
			});
		})
		.fail( showError );
}

function parseData( data ) {
	var rowsData = [];
		
	for ( var i = 0, len = data.length; i < len; i++ ) {
		var model = data[ i ];
		var fieldsData = [];
		
		fieldsData.push( model.objectId );
		fieldsData.push( model.name );
		
		if ( model.country ) {
			fieldsData.push( model.country );
		}
		
		fieldsData.push( new Date( model.createdAt ).toLocaleString() );
		fieldsData.push( new Date( model.updatedAt ).toLocaleString() );
		
		rowsData[ i ] = fieldsData;
	}
	
	return rowsData;
}

function showError( err ) {
	noty({
		text: err.message,
		timeout: 1000
	});
};

var $countriesTable, $townsTable;
$(function() {
	$countriesTable = $( "#countries-table" )
		.dynamicTable()
		.addHeader( [ "#", "Name", "Created", "Last updated" ] )
		.setEditableColumns( [ 1 ] )
		.on( "row-deletion", onRowDeletion )
		.on( "row-updated", function( e, row ) {
			row = $( row );
			var country = row.data( "entry" );
			country.name = row.find( "td:nth-child(2)" ).text();
			
			country
				.save()
				.done(function() {
					var data = parseData( [ country ] );
					$countriesTable.updateRow( row, data[ 0 ], country );
				})
				.fail( showError );
		})
		.on( "add-row", function( e ) {
			var country = new models.Country();
			$countriesTable.addRows( [ new Array( 4 ) ], [ country ] );
		})
		.on( "click", "tr", function( e ) {
			var entry = $( e.currentTarget ).data( "entry" );
			$townsTable.filter( entry.name );
		});
		
	$townsTable = $( "#towns-table" )
		.dynamicTable()
		.addHeader( [ "#", "Name", "Country", "Created", "Last updated" ] )
		.setEditableColumns( [ 1, 2 ] )
		.on( "row-deletion", onRowDeletion )
		.on( "row-updated", function( e, row ) {
			row = $( row );
			var town = row.data( "entry" );
			town.name = row.find( "td:nth-child(2)" ).text();
			town.country = row.find( "td:nth-child(3)" ).text();
			
			town
				.save()
				.done(function() {
					var data = parseData( [ town ] );
					$townsTable.updateRow( row, data[ 0 ], town );
				})
				.fail( showError );
		})
		.on( "add-row", function( e ) {
			var town = new models.Town();
			$townsTable.addRows( [ new Array( 5 ) ], [ town ] );
		});
});

models
	.Country
	.loadAll()
	.done(function( data ) {
		$(function() {
			$countriesTable.addRows( parseData( data ), data );
		});
	})
	.fail( showError );
	
models
	.Town
	.loadAll()
	.done(function( data ) {
		$(function() {
			$townsTable.addRows( parseData( data ), data );
		});
	})
	.fail( showError );

}( $ ));