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

function editRow( $row ) {
	var $columns = $row.find( "td[data-editable]:not(:has(input))" );
	
	for ( var i = 0, len = $columns.length; i < len; i++ ) {
		var $column = $columns.eq( i ),
			textValue = $column.text();
		
		$( INPUT_TEMPLATE )
			.val( textValue )
			.appendTo( $column.empty() );
	}
}

function saveRow( $row ) {
	var isUpdated = false;
	
	$row
		.find( "input" )
		.each(function( index, input ) {
			isUpdated = true;
			input = $( input );
			
			var value = input.val(),
				$td = input.parent(),
				rowEntry = $row.data( "entry" ),
				modelKey = $td.data( "model-key" );
			
			rowEntry[ modelKey ] = value;
			
			$td.empty().text( value );
		});
	
	if ( isUpdated ) {
		this.trigger( "row-updated", $row );
	}
}

function addRows( rowsData ) {
	var $docFragment = $( document.createDocumentFragment() ),
		model = this.data( "model" ),
		modelKeys = Object.keys( model );
	
	rowsData.forEach(function( entry ) {
		var $row = $( document.createElement( "tr" ) )
			.appendTo( $docFragment )
			.data( "entry", entry );
		
		modelKeys.forEach(function( key ) {
			var $td = $( document.createElement( "td" ) )
				.text( entry[ key ] || "undefined" )
				.appendTo( $row );
				
			if ( model[ key ] === true ) {
				$td
					.attr( "data-editable", key )
					.data( "model-key", key );
			}
		});
		
		$( document.createElement( "td" ) )
			.html( TOOLBOX_TEMPLATE )
			.appendTo( $row );
	});
		
	this
		.find( "tbody" )
		.append( $docFragment );
	
	return this;
}

function createHeader( headerValues ) {
	headerValues.push( "Tools" );
		
	var $headerRow = $( document.createElement( "tr" ) );
	
	headerValues.forEach(function( value ) {
		$( document.createElement( "th" ) )
			.text( value )
			.appendTo( $headerRow );
	});
	
	this
		.find( "tfoot td" )
			.attr( "colspan", headerValues.length )
		.end()
		.find( "thead" )
			.empty()
			.append( $headerRow );
		
	return this;
}

$.fn.dynamicTable = $.fn.dynamicTable || function() {
	var $table = this;
	
	this
		.empty()
		.append( document.createElement( "tbody" ) )
		.append( document.createElement( "thead" ) );
		
	$( document.createElement( "tfoot" ) )
		.html( FOOTER_TEMPLATE )
		.appendTo( this );
	
	this.on( "click", "button", function( e ) {
		e.stopPropagation();
		
		var $btn = $( e.target ),
			$row = $btn.closest( "tr" );
			
		switch( $btn.data( "role" ) ) {
		case "delete":
			$table.trigger( "row-deletion", $row );
			break;
		case "edit":
			editRow( $row );
			break;
		case "save":
			saveRow.call( $table, $row );
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
	
	this.on( "data-updated", function( e, row ) {
		row = $( row );
		
		var model = $table.data( "model" ),
			modelKeys = Object.keys( model ),
			entry = row.data( "entry" ),
			$columns = row.find( "td" );
		
		modelKeys.forEach(function( key, index ) {
			var value = entry[ key ];
			
			$columns.eq( index ).text( value || "undefined" );
		});
	});
	
	this.addHeader = createHeader;
	
	this.addRows = addRows;
	
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