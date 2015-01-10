function get100( arr ) {
	var matrix = [];
	for (var i = 0; i < arr.length; i++) {
		matrix.push( arr[ i ].split( '' ) );
	}

	var jumperPosition = { row: 0, col: 0 };
	for (var i = 0; i < matrix.length; i++) {
		for (var j = 0; j < matrix[ i ].length; j++) {
			if (matrix[ i ][ j ] == 'o') {
			jumperPosition.col = j;
			jumperPosition.row = i;
			break;
			}
		}
	}

	jumperPosition.row++;

	for (; jumperPosition.row < matrix.length; jumperPosition.row++) {
		var leftMoves = 0;
		var rightMoves = 0;
		for (var col = 0; col < matrix[ jumperPosition.row ].length; col++) {
			switch (matrix[ jumperPosition.row ][ col ]) {
				case '<' : leftMoves++; break;
				case '>' : rightMoves++; break;
			}
		};

		jumperPosition.col -= leftMoves;
		jumperPosition.col += rightMoves;

		var curr = matrix[ jumperPosition.row ][ jumperPosition.col ];
		if (curr == "~") {
			console.log( "Drowned in the water like a cat!" );
			console.log( jumperPosition.row + " " + jumperPosition.col );
			break;
		} else if (curr == '_') {
			console.log( "Landed on the ground like a boss!" );
			console.log( jumperPosition.row + " " + jumperPosition.col );
			break;
		} else if (curr == '/' || curr == '\\' || curr == '|') {
			console.log( "Got smacked on the rock like a dog!" );
			console.log( jumperPosition.row + " " + jumperPosition.col );
			break;
		}
	};
}