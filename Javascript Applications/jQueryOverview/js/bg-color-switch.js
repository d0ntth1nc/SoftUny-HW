'use strict';

function paint() {
	var _class = $( '#classInput' ).val(),
		color = $( '#colorInput' ).val();
		
	$( '.' + _class )
		.css( { backgroundColor: color } );
}