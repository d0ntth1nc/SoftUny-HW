(function( $ ) {
	'use strict';

var
	ANIMATIONS_DURATION = 700,
	$slideshowContainer = $( '#slideshow' ),
	$slides = $( '#slideshow .slide' ),
	slidesCount = $slides.length,
	containerWidth = $slideshowContainer.width(),
	containerHeight = $slideshowContainer.height(),
	activeIndex = $( '#slideshow .slide.active' ).index( '.active' ),
	slideShowInterval;
	
// Allow buttons to be clicked
$( '#slideshow button' ).data( 'canClick', true );

$slideshowContainer.on( 'click', 'button', function() {
	var $this = $( this );
	
	if ( !$this.data( 'canClick' ) ) {
		return;
	}
	
	// Stop the automatic slide
	if ( slideShowInterval ) {
		clearInterval( slideShowInterval );
	}
	
	// Disallow this button to be clicked
	$this.data( 'canClick', false );
	
	var
		$activeSlide = $slides.eq( activeIndex ),
		$nextSlide,
		slideDirection,
		nextSlideStartPos;
		
	if ( $this.is( '#slideshow-right-btn' ) ) {
		slideDirection = 'toRight';
		nextSlideStartPos = { left: containerWidth * -1 };
		
		if ( --activeIndex < 0 ) {
			activeIndex = slidesCount - 1;
		}
	} else if ( $this.is( '#slideshow-left-btn' ) ) {
		slideDirection = 'toLeft';
		nextSlideStartPos = { left: containerWidth };
		
		if ( ++activeIndex >= slidesCount ) {
			activeIndex = 0;
		}
	} else {
		return;
	}
	
	// Slide out current active
	slideTo( $activeSlide, slideDirection, function() {
		$( this ).removeClass( 'active' );
	} );
	
	// Slide in current active
	$nextSlide = $slides
		.eq( activeIndex )
		.css( nextSlideStartPos )
		.addClass( 'active' );
		
	slideTo( $nextSlide, slideDirection, function() {
		// Allow this button to be clicked
		$this.data( 'canClick', true );
		
		// Start the automatic slide again
		autoSlide();
	} );
} );

// Simulate left button click to automatticaly change every 5 seconds
autoSlide();

function autoSlide() {
	slideShowInterval = setInterval(function() {
		$( '#slideshow-left-btn' ).trigger( 'click' );
	}, 5000 );
}

function slideTo( $slide, direction, callback ) {
	var
		slideFromPosition = $slide.position(),
		slideToPosition = {};
	
	switch( direction ) {
		case 'toTop':
			slideToPosition.top = slideFromPosition.top - containerHeight;
			break;
		case 'toBottom':
			slideToPosition.top = slideFromPosition.top + containerHeight;
			break;
		case 'toRight':
			slideToPosition.left = slideFromPosition.left + containerWidth;
			break;
		case 'toLeft':
			slideToPosition.left = slideFromPosition.left - containerWidth;
			break;
		default:
			throw Error( 'Invalid direction!' );
	}
	
	$slide.animate( slideToPosition, ANIMATIONS_DURATION, callback );
}
}( $ ));
	
