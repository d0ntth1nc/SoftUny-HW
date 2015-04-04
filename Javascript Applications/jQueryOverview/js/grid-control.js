(function( $ ) {
'use strict';

function makeRow( values, columnHTMLType ) {
	var $newRow = $( '<tr>' ),
		i = 0, len = values.length;
		
	for ( ; i < len; i++ ) {
		$( columnHTMLType )
			.text( values[ i ] )
			.appendTo( $newRow );
	}
	
	return $newRow;
}

$.fn.grid = function() {
	this.addHeader = function( values ) {
		var $newRow = makeRow( values, '<th>' );
		
		this
			.find( 'thead' )
			.empty()
			.append( $newRow );
			
		return this;
	};
	
	this.addRow = function( values ) {
		var $newRow = makeRow( values, '<td>' );
		
		this
			.find( 'tbody' )
			.append( $newRow );
			
		return this;
	};
	
	return this
		.empty()
		.append( '<tbody>' )
		.append( '<thead>' );
};
}( $ ));

//Test

$( '#myGrid' )
	.grid()
	.addHeader( [ 'First Name', 'Last Name', 'Age' ] )
	.addRow( [ 'Bay', 'Ivan', 50 ] )
	.addRow( [ 'Kaka', 'Penka', 26 ] );
