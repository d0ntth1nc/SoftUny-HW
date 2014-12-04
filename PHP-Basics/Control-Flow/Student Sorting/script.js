'use strict';

Element.prototype.remove = function() {
    this.parentNode.removeChild( this );
};

var template = document.getElementById( 'inputTemplate' ).innerHTML;

function addRow() {
    var newRow = document.createElement( 'div' );
    newRow.setAttribute( 'class', 'form-row' );
    newRow.innerHTML = template;
    document.querySelector( 'form' )
        .insertBefore( newRow, document.querySelector( '.form-row:last-child' ) );
}

function removeRow( caller ) {
    caller.parentNode.parentNode.remove();
}