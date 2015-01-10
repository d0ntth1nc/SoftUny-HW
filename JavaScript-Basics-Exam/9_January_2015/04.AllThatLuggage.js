function get100( arrStr ) {
	var ppl = {};
	var pattern = /(.*?)\.*\*\.*(.*?)\.*\*\.*(true|false)\.*\*\.*(true|false)\.*\*\.*(true|false)\.*\*\.*(.*?)\.*\*\.*(.*)/;
	var orderBy = arrStr[ arrStr.length - 1 ];
	for (var i = 0, len = arrStr.length; i < len - 1; i++) {
		var str = arrStr[ i ];
		var elements = pattern.exec( str );
		var name = elements[ 1 ];
		var luggage = elements[ 2 ];
		var isFood = elements[ 3 ];
		var isDrink = elements[ 4 ];
		var isFragile = elements[ 5 ];
		var weight = elements[ 6 ];
		var transferedWith = elements[ 7 ];

		if (!ppl[ name ]) {
			ppl[ name ] = [];
		}

		var type = '';
		if (isFood == 'true') {
			type = 'food';
		} else if (isDrink =='true') {
			type = 'drink';
		} else {
			type = 'other';
		}

		isFragile = isFragile == 'true' ? true : false;

		ppl[name].push( {
			kg: Number( weight ), fragile: isFragile, type: type, transferredWith: transferedWith, name: luggage
		} );
	}

	var sortedPpl = {};
	for (var name in ppl) {
		var luggages = ppl[ name ];
		if (orderBy == 'weight') {
			luggages.sort(function( a, b ) {
				return a.kg - b.kg;
			});
		} else if (orderBy == 'luggage name') {
			luggages.sort(function( a, b ) {
				return a.name.localeCompare( b.name );
			});
		}
		sortedPpl[ name ] = {};
		for (var i = 0, len = luggages.length; i < len; i++) {
			var lugg = luggages[ i ];
			sortedPpl[ name ][ lugg.name ] = lugg;
			delete lugg.name;
		}
	}
	console.log( JSON.stringify( sortedPpl ) );
}