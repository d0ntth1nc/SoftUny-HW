function get100( arr ) {
	for (var i = 0; i < arr.length; i++) {
		var carData = arr[ i ].split( ' ' );
		var model = carData[ 0 ];
		var fuelType = carData[ 1 ];
		var route = carData[ 2 ];
		var weight = Number( carData[ 3 ] );

		var baseConsumption = 10;
		switch (fuelType) {
			case 'gas': baseConsumption *= 1.2; break;
			case 'diesel': baseConsumption *= 0.8; break;
		}
		baseConsumption += 0.01 * weight;

		var totalConsumption;
		switch (route) {
			case '1': totalConsumption = 110 * ( baseConsumption / 100 ); break;
			case '2': totalConsumption = 95 * ( baseConsumption / 100 ); break;
		}

		var snowConsumption = 0.3 * baseConsumption;
		switch (route) {
			case '1': snowConsumption = 10 * ( snowConsumption / 100 ); break;
			case '2': snowConsumption = 30 * ( snowConsumption / 100 ); break;
		}

		totalConsumption += snowConsumption;
		totalConsumption = Math.round( totalConsumption );

		console.log( model + " " + fuelType + " " + route + " " + totalConsumption );
	} 
}