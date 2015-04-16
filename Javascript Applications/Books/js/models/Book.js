"use strict";
var models = models || {};

(function( models ) {

function Book( title, author, isbn, tags ) {
	models.ParseObject.call( this, arguments[ 0 ] );
	
	if ( typeof title === "string" ) {
		this.title = title;
		this.author = author;
		this.isbn = isbn;
	}
	
	this.tags = this.tags || tags || [];
}

Book.loadAll = models.ParseObject.loadAll;
Book.prototype = Object.create( models.ParseObject.prototype );
Book.prototype.constructor = Book;
models.Book = Book;

}( models ));