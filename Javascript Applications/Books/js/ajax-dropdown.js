"use strict";

(function( $ ) {
	
function createListItem( value ) {
	var $li = $( document.createElement( "li" ) ),
		$span = $( document.createElement( "span" ) )
			.text( value ),
		$deleteButton = $( document.createElement( "button" ) )
			.addClass( "delete-btn" ),
		$editButton = $( document.createElement( "button" ) )
			.addClass( "edit-btn" ),
		$saveButton = $( document.createElement( "button" ) )
			.addClass( "save-btn" );
		
	return $li
		.append( $span )
		.append( $deleteButton )
		.append( $editButton )
		.append( $saveButton );
}

$.fn.ajaxDropdown = $.fn.ajaxDropdown || function( entry ) {
	var $dropdown = this,
		modelKey = this.attr( "data-model-target-key" ),
		$dropdownMenu = this.find( ".dropdown-menu" ),
		$divider = this.find( ".divider" ),
		$input = this.find( "input" ),
		$dropdownToggleLink = this.find( "a" ),
		isMenuVisible = false;
		
	function deleteEntry( $li ) {
		var index = $li.index();
				
		entry[ modelKey ] = entry[ modelKey ].filter(function( val, i ) {
			return i !== index;
		});
		
		entry
			.save()
			.done(function() {
				$li.remove();
				$dropdown.trigger( "entry-removed" );
			})
			.fail(function( err ) {
				$dropdown.trigger( "error", err );
			});
	}
		
	function editEntry( $li ) {
		if ( $li.hasClass( "edit" ) ) {
			return;
		}
		
		$li.addClass( "edit" );
		var $span = $li.find( "span" );
		var text = $span.text();
		
		$( "<input type='text'></input>" )
			.val( text )
			.appendTo( $span.empty() );
	}
	
	function saveEntry( $li ) {
		var $input = $li.find( "input" ),
			value = $input.val().trim(),
			index = $li.index();
			
		if ( value ) {
			entry[ modelKey ][ index ] = value;
			entry
				.save()
				.done(function() {
					$li
						.find( "span" )
						.empty()
						.text( value )
						.removeClass( "edit" );
					$dropdown.trigger( "entry-saved" );
				})
				.fail(function( err ) {
					$dropdown.trigger( "error", err );
				});
		}
	}
	
	entry[ modelKey ].forEach(function( value ) {
		createListItem( value ).insertBefore( $divider );
	});
	
	return this
		.on( "click", "a", function( e ) {
			e.stopPropagation();
			e.preventDefault();
			
			if ( isMenuVisible ) {
				$dropdownMenu.hide();
				isMenuVisible = false;
			} else {
				$dropdownMenu.show();
				isMenuVisible = true;
			}
		})
		.on( "click", "button", function( e ) {
			var $btn = $( this );
			
			if ( $btn.hasClass( "delete-btn" ) ) {
				deleteEntry( $btn.parent() );
				
			} else if ( $btn.hasClass( "edit-btn" ) ) {
				editEntry( $btn.parent() );
				
			} else if ( $btn.hasClass( "save-btn" ) ) {
				saveEntry( $btn.parent() );
				
			} else {
				if ( $btn.attr( "data-role" ) === "hide" ) {
					$dropdownToggleLink.trigger( "click" );
					return;
				}
				
				var tagName = $input.val().trim();
			
				if ( tagName ) {
					entry[ modelKey ].push( tagName );
					
					entry
						.save()
						.done(function(){
							$input.val( "" );
							createListItem( tagName ).insertBefore( $divider );
							$dropdown.trigger( "entry-saved" );
						})
						.fail(function( err ) {
							$dropdown.trigger( "error", err );
						});
				}
			}
		});
}

}( $ ));