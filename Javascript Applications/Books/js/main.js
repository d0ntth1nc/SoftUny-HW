"use strict";
(function( $ ) {
	
$( "#books-table" )
	.ajaxTable( models.Book )
	.on( "row-added", function( e, row ) {
		row = $( row );
		row
			.find( ".dropdown" )
			.ajaxDropdown( row.data( "entry" ) )
			.on( "entry-removed", function() {
				noty({
					text: "Tag deleted",
					timeout: 1000
				});
			})
			.on( "entry-saved", function() {
				noty({
					text: "Tag saved succesfully",
					timeout: 1000
				});
			});
	})
	.on( "row-updated", function() {
		noty({
			text: "Book saved successfully",
			timeout: 1000
		});
	})
	.on( "row-deleted", function() {
		noty({
			text: "Book deleted successfully",
			timeout: 1000
		});
	})
	.on( "error", function( e, err ) {
		noty({
			text: err.message,
			timeout: 1000
		});
	});

}( $ ));