(function( $ ) {
	'use strict';

var
	ANIMATIONS_DURATION = 700, // 0.7 seconds
	AUTO_SLIDE_INTERVAL = 5000, // 5 seconds
	
	$slideshowContainer = $( '#slideshow' ),
	$slides = $( '#slideshow .slide' ),
	slidesCount = $slides.length,
	containerWidth = $slideshowContainer.width(),
	containerHeight = $slideshowContainer.height(),
	activeIndex = $( '#slideshow .slide.active' ).index( '.slide' ),
	slideShowInterval,
	isSlideActive = false;

$slideshowContainer.on( 'click', 'button', function() {
	if ( isSlideActive ) {
		return;
	}
	
	var
		$this = $( this ),
		$activeSlide = $slides.eq( activeIndex ),
		$nextSlide,
		slideDirection,
		nextSlideStartPos;
	
	// Make decision for the slide directions and update the active slide index
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
		// Other button is clicked? Ok, i'm outta here.
		return;
	}
	
	// Mark the slideshow active and stop the automatic run
	isSlideActive = true;
	
	if ( slideShowInterval ) {
		clearInterval( slideShowInterval );
	}
		
	// Slide out the current active
	slideTo( $activeSlide, slideDirection, function() {
		$( this ).removeClass( 'active' );
	} );
	
	// Slide in the next one
	$nextSlide = $slides
		.eq( activeIndex )
		.css( nextSlideStartPos )
		.addClass( 'active' );
		
	slideTo( $nextSlide, slideDirection, function() {
		// Mark the slide as inactive and start the automatic run again
		isSlideActive = false;
		autoSlide();
	} );
} );

// Simulate left button click to auto slide
autoSlide();

function autoSlide() {
	slideShowInterval = setInterval(function() {
		$( '#slideshow-left-btn' ).trigger( 'click' );
	}, AUTO_SLIDE_INTERVAL );
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
	
