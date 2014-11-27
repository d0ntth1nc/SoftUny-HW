function printPositions(arr) {
    var stars = [
        arr[0].toLowerCase().split(' '),
        arr[1].toLowerCase().split(' '),
        arr[2].toLowerCase().split(' '),
    ];

    var startPosition = arr[3].split(' ');
    var movesCount = Number(arr[4]);

    for (var i = 0; i <= movesCount; i++) {
        var currentX = Number(startPosition[0]);
        var currentY = Number(startPosition[1]) + i;

        var starsInRange = stars.filter(function (star) {
            var currentStarX = Number(star[1]);
            var currentStarY = Number(star[2]);
            var starName = star[0];

            return currentX >= currentStarX - 1 && currentX <= currentStarX + 1 &&
                currentY >= currentStarY - 1 && currentY <= currentStarY + 1;
        });
        
        if (starsInRange.length) {
            console.log(starsInRange[0][0]);
        } else {
            console.log("space");
        }
    }
}

printPositions([
"    Sirius 3 7           ",
"Alpha-Centauri 7 5       ",
"Gamma-Cygni 10 10        ",
"8 1                      ",
"6                        "
]);