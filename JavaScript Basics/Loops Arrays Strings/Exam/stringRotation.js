function stringRotation(arr){
    var degrees = Number(arr[0].match(/\d+/)[0]);

    var maxWidth = 0;
    for (var i = 1, len = arr.length; i < len; i++) {
        maxWidth = Math.max(maxWidth, arr[i].length);
    }

    var matrix = [];
    for (var row = 1, len = arr.length; row < len; row++) {
        matrix.push([]);

        var string = arr[row], stringLength = string.length;
        for (var col = 0; col < maxWidth; col++) {
            var char = col >= stringLength ? ' ' : string[col];
            matrix[row - 1].push(char);
        }
    }

    while (degrees >= 360) {
        degrees = degrees - 360;
    }

    while (degrees > 0) {
        matrix = rotateTo90Degrees(matrix);
        degrees -= 90;
    }

    for (var i = 0; i < matrix.length; i++) {
        console.log(matrix[i].join(''));
    }

    function rotateTo90Degrees(matrix) {
        var newMatrix = [];

        for (var col = 0; col < maxWidth; col++) {
            newMatrix.push([]);

            for (var row = matrix.length - 1; row >= 0 ; row--) {
                newMatrix[col].push(matrix[row][col]);
            }
        }

        return newMatrix;
    }
}

stringRotation(["Rotate(180)", "hello", "softuni", "exam"]);