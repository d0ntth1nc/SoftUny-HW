function getTetrisFigures(input) {
    var gameField = [],
        height = input.length,
        width = input[0].length;

    for (var row = 0; row < height; row++) {
        var rowElements = input[row].split('');

        gameField.push([]);
        for (var col = 0; col < width; col++) {
            gameField[row].push(rowElements[col] == 'o');
        }
    }

    var pieces = {};
    pieces["I"] = 0;
    pieces["L"] = 0;
    pieces["J"] = 0;
    pieces["O"] = 0;
    pieces["Z"] = 0;
    pieces["S"] = 0;
    pieces["T"] = 0;

    for (var col = 0; col < width; col++) {
        for (var row = 0; row < height; row++) {
            // I
            if (row < height - 3) {
                var hasElement =
                    gameField[row][col] &&
                    gameField[row + 1][col] &&
                    gameField[row + 2][col] &&
                    gameField[row + 3][col];
                if (hasElement) pieces["I"]++;
            }
            
            // L and J
            if (row < height - 2) {
                if (col < width - 1) {
                    var hasElement =
                        gameField[row][col] &&
                        gameField[row + 1][col] &&
                        gameField[row + 2][col] &&
                        gameField[row + 2][col + 1];
                    if (hasElement) pieces["L"]++;
                }
                if (col > 0) {
                    var hasElement =
                        gameField[row][col] &&
                        gameField[row + 1][col] &&
                        gameField[row + 2][col] &&
                        gameField[row + 2][col - 1];
                    if (hasElement) pieces["J"]++;
                }
            }

            //O and S
            if (row < height - 1 && col < width - 1) {
                var hasElement =
                    gameField[row][col] &&
                    gameField[row][col + 1] &&
                    gameField[row + 1][col] &&
                    gameField[row + 1][col + 1];
                if (hasElement) pieces["O"]++;

                if (col > 0) {
                    var hasElement =
                        gameField[row][col] &&
                        gameField[row][col + 1] &&
                        gameField[row + 1][col] &&
                        gameField[row + 1][col - 1];
                    if (hasElement) pieces["S"]++;

                    hasElement =
                        gameField[row][col] &&
                        gameField[row][col - 1] &&
                        gameField[row + 1][col] &&
                        gameField[row + 1][col + 1];
                    if (hasElement) pieces["Z"]++;

                    hasElement =
                        gameField[row][col] &&
                        gameField[row][col - 1] &&
                        gameField[row][col + 1] &&
                        gameField[row + 1][col];
                    if (hasElement) pieces["T"]++;
                }
            }
        }
    }

    console.log(JSON.stringify(pieces));
}

getTetrisFigures([
    "--o--o-",
    "--oo-oo",
    "ooo-oo-",
    "-ooooo-",
    "---oo--"
]);