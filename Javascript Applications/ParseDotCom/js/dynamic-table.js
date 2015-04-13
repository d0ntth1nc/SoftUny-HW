"use strict";
(function( $ ) {

var
	TOOLBOX_TEMPLATE =
		"<button data-role='delete' class='btn btn-danger'>Delete</button>" +
		"<button data-role='edit' class='btn btn-info'>Edit</button>"+
		"<button data-role='save' class='btn btn-success'>Save</button>",
		
	INPUT_TEMPLATE = "<input type='text' class='form-control'>",
	FOOTER_TEMPLATE =
		"<tr><td class='text-center' colspan='1'>" +
		"<button data-role='add' class='btn btn-primary'>New row</button>" +
		"<button data-role='clear-filters' class='btn btn-primary'>Clear filters</button>" +
		"</td></tr>";

function editRow( $row, editableColumns ) {
	var $columns = $row.find( "td" );
	
	for ( var i = 0, len = editableColumns.length; i < len; i++ ) {
		var $column = $columns.eq( editableColumns[ i ] ),
			textValue = $column.text();
		
		if ( $column.is( ":not(:has(input))" ) ) {
			$column
				.empty()
				.append( $( INPUT_TEMPLATE ).val( textValue ) );
		}
	}
}

function saveRow( $row ) {
	$row
		.find( "input" )
		.each(function( index, element ) {
			element = $( element );
			var value = element.val();
			
			element
				.parent()
				.empty()
				.text( value );
		});
}

function makeRow( data, isHeader ) {
	var $row = $( document.createElement( "tr" ) );
	
	for ( var i = 0, len = data.length; i < len; i++ ) {
		if ( isHeader ) {
			$( document.createElement( "th" ) )
				.text( data[ i ] )
				.appendTo( $row );
		} else {
			$( document.createElement( "td" ) )
				.text( data[ i ] )
				.appendTo( $row );
		}
	}
	
	// Adding the last column
	if ( isHeader ) {
		$( document.createElement( "th" ) )
			.text( "Tools" )
			.appendTo( $row );
	} else {
		$( document.createElement( "td" ) )
			.html( TOOLBOX_TEMPLATE )
			.appendTo( $row );
	}
	
	return $row;
}

$.fn.dynamicTable = $.fn.dynamicTable || function() {
	var
		$table = this,
		editableColumns = [],
		garbageValues = [];
	
	this
		.empty()
		.append( document.createElement( "tbody" ) )
		.append( document.createElement( "thead" ) )
		.append( $( document.createElement( "tfoot" ) ).html( FOOTER_TEMPLATE ) );
	
	this.on( "click", "button", function( e ) {
		e.stopPropagation();
		
		var $btn = $( e.target ),
			$row = $btn.closest( "tr" );
			
		switch( $btn.data( "role" ) ) {
			case "delete":
				$table.trigger( "row-deletion", $row );
				break;
			case "edit":
				editRow( $row, editableColumns );
				break;
			case "save":
				saveRow( $row );
				$table.trigger( "row-updated", $row );
				break;
			case "add":
				$table.trigger( "add-row" );
				break;
			case "clear-filters":
				$table.find( "tbody tr" ).show();
				break;
			default:
				throw Error( "Invalid button role!" );
		}
	});
	
	this.addHeader = function( headerValues ) {
		garbageValues = headerValues;
		
		this
			.find( "tfoot td" )
				.attr( "colspan", headerValues.length + 1 ) // Including the extra cell for the toolbox
			.end()
			.find( "thead" )
				.empty()
				.append( makeRow( headerValues, true ) );
			
		return this;
	};
	
	this.addRows = function( rowsValues, rowsData ) {
		rowsData = rowsData || [];
		var $docFragment = $( document.createDocumentFragment() );
		
		for ( var i = 0, len = rowsValues.length; i < len; i++ ) {
			makeRow( rowsValues[ i ], false )
				.appendTo( $docFragment )
				.data( "entry", rowsData[ i ] );
		}
		
		this
			.find( "tbody" )
			.append( $docFragment );
	}
	
	this.setEditableColumns = function( _editableColumns_ ) {
		editableColumns = _editableColumns_;
		return this;
	};
	
	this.updateRow = function( row, rowValues, rowData ) {
		var $columns = row.find( "td" ).not( "td:last-child" );
		
		for ( var i = 0; i < $columns.length; i++ ) {
			$columns
				.eq( i )
				.text( rowValues[ i ] );
		}
		
		row.data( "entry", rowData );
		
		return this;
	};
	
	this.filter = function( filter ) {
		this
			.find( "tbody tr" )
				.show()
			.end()
			.find( "tbody tr:not(:contains(" + filter + "))" )
				.hide();
	};
	
	return this;
};
}( $ ));