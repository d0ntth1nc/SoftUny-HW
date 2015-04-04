(function( $ ) {
'use strict';

var jsonString = '[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]';

function createTable( jsonString ) {
	var $table = $( '<table>' ),
		$thead = $( '<thead>' ).appendTo( $table ),
		$tbody = $( '<tbody>' ).appendTo( $table ),
		data = JSON.parse( jsonString );
		
	// Creating table header
	var $theadRow = $( '<tr>' )
		.appendTo( $thead );
	
	// We expect all objects in the array to have same properties
	// Use the first one as pattern
	for ( var prop in data[ 0 ] ) {
		$( '<th>' )
			.text( prop )
			.appendTo( $theadRow );
	}
	
	// Creating table body
	var i = 0, len = data.length;
	
	for ( ; i < len; i++ ) {
		var $tr = $( '<tr>' )
			.appendTo( $tbody );
		
		for ( var prop in data[ i ] ) {
			$( '<td>' )
				.text( data[ i ][ prop ] )
				.appendTo( $tr );
		}
	}
	
	return $table;
}

var table = createTable( jsonString );
$( 'body' ).append( table );

}( $ ));