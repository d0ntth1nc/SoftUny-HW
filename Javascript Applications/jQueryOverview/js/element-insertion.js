(function( $ ) {
'use strict';

var $ul = $( 'ul' ),
	i = 0, len = 5;
	
for ( ; i < len; i++ ) {
	$ul.append( $( '<li>' ).text( i ) );
}

$( 'li:first-child' ).before( $( '<li>' ).text( 'added before the first li' ) );
$( 'li:last-child' ).after( $( '<li>' ).text( 'added after the last li' ) );

$( 'li:nth-child(odd)' ).after( $( '<li>' ).text( 'added after every odd li' ) );
}( $ ));