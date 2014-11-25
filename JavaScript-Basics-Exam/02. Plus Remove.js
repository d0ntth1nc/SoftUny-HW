function get(arr) {
    var output = [];

    for (var i = 0; i < arr.length; i++) {
        var row = arr[i];
        output.push(row.split(''));
    }

    for (var row = 0; row < arr.length - 2; row++) {
        for (var col = 1; col < arr[row].length; col++) {
            if (col + 1 < arr[row + 1].length && col < arr[row + 2].length) {
                var a = arr[row][col].toLowerCase();
                var b = arr[row + 1][col - 1].toLowerCase();
                var c = arr[row + 1][col].toLowerCase();
                var d = arr[row + 1][col + 1].toLowerCase();
                var e = arr[row + 2][col].toLowerCase();
                if (a === b && b === c && c === d && d === e) {
                    output[row][col] = '';
                    output[row + 1][col - 1] = '';
                    output[row + 1][col] = '';
                    output[row + 1][col + 1] = '';
                    output[row + 2][col] = '';
                }
            }
        }
    }

    for (var i = 0; i < output.length; i++) {
        console.log(output[i].join(''));
    }
}