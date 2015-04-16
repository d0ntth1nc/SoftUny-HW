"use strict";
(function( $ ) {

var INPUT_TEMPLATE = "<input type='text'></input>"
	
function editRow( $row ) {
	if ( $row.hasClass( "edit" ) ) {
		return;
	}
	
	$row
		.addClass( "edit" )
		.find( "td[data-editable]" )
		.each(function( index, column ) {
			column = $( column );
			var text = column.text(), modelKey = column.attr( "data-model-key" );
			
			column.empty();
			
			$( INPUT_TEMPLATE )
				.val( text )
				.attr( "data-model-key", modelKey )
				.appendTo( column );
		});
	
}

function deleteRow( $row ) {
	var entry = $row.data( "entry" ),
		self = this;
	
	if ( entry ) {
		entry
			.remove()
			.done(function() {
				$row.remove();
				self.trigger( "row-deleted" );
			})
			.fail(function( err ) {
				self.trigger( "error", err );
			});
	} else {
		$row.remove();
	}
}

function saveRow( $row ) {
	var entry = $row.data( "entry" ),
		self = this;
	
	$row
		.find( "input[data-model-key]" )
		.each(function( index, input ) {
			input = $( input );
			var key = input.attr( "data-model-key" );
			entry[ key ] = input.val().trim();
		});
		
	entry
		.save()
		.done(function() {
			$row
				.removeClass( "edit" )
				.find( "td[data-model-key]" )
				.each(function( index, column ) {
					column = $( column );
					var key = column.attr( "data-model-key" );
					column
						.empty()
						.text( entry[ key] );
				});
			
			self.trigger( "row-updated" );
		})
		.fail(function( err ) {
			self.trigger( "error", err );
		});
}

function createRow( $template, entry ) {
	var $row = $template
		.clone()
		.removeClass( "hidden" )
		.data( "entry", entry );
	
	$row.find( "td[data-model-key]" ).each(function( i, column ) {
		column = $( column );
		var key = column.attr( "data-model-key" );
		column.text( entry[ key ] || "undefined" );
	});
	
	this.trigger( "row-added", $row );
	
	return $row;
}
	
$.fn.ajaxTable = $.fn.ajaxTable || function( Model ) {
	var
		$viewTemplate = this.find( "tr[data-template]" ),
		$modelFields = $viewTemplate.find( "td[data-model-key]" ),
		$tbody = this.find( "tbody" ),
		$table = this;
	
	this.on( "click", "button", function( e ) {
		var $button = $( this ),
		    $row = $button.closest( "tr" );
		
		switch ( $button.attr( "data-role" ) ) {
		case "add-row":
			createRow
				.call( $table, $viewTemplate, new Model() )
				.appendTo( $tbody );
			break;
		case "edit":
			editRow( $row );
			break;
		case "delete":
			deleteRow.call( $table, $row );
			break;
		case "save":
			saveRow.call( $table, $row );
			break;
		}
	});
	
	Model.loadAll().done(function( entries ) {
		var docFragment = $( document.createDocumentFragment() );
		
		entries.forEach(function( entry ) {
			createRow
				.call( $table, $viewTemplate, entry )
				.appendTo( docFragment );
		});
		
		docFragment.appendTo( $tbody );
	});
	
	return this;
};

}( $ ));