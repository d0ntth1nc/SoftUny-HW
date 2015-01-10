function get100( text ) {
	var pat = /<p>(.*?)<\/p>/g;
	var match = pat.exec( text );
	var res = '';
	while (match) {
		var encrypted = match[ 1 ];
		var replaced = encrypted.replace( /[^a-z0-9]+/g, ' ' );
		var chars = replaced.split( '' );
		for (var i = 0, len = chars.length; i < len; i++) {
			if (chars[ i ].match( /[a-z]/ )) {
				if (chars[ i ] < 'n') {
					var q = chars[ i ].charCodeAt( 0 ) - 97;
					chars[ i ] = String.fromCharCode( q + 110 );
				} else {
					var q = chars[ i ].charCodeAt( 0 ) - 110;
					chars[ i ] = String.fromCharCode( q + 97 );
				}
			}
		}
		res += chars.join( '' );
		match = pat.exec( text );
	}
	console.log( res );
}