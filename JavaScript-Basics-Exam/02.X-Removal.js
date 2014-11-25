function get(arr) {
    var output = [];
    for (var i = 0; i < arr.length; i++) {
        output.push(arr[i].split(''));
    }

    for (var i = 0; i < arr.length - 2; i++) {
        for (var j = 0; j < arr[i].length - 2; j++) {
            if (arr[i].length <= j + 2 || arr[i + 2].length <= j + 2 ||
                arr[i + 1].length <= j + 1) {
                continue;
            }
            var a = arr[i][j].toLowerCase();
            var b = arr[i + 2][j].toLowerCase();
            var c = arr[i + 1][j + 1].toLowerCase();
            var d = arr[i][j + 2].toLowerCase();
            var e = arr[i + 2][j + 2].toLowerCase();
            if (a == b && b == c && c == d && d == e) {
                output[i][j] = '';
                output[i + 2][j] = '';
                output[i + 1][j + 1] = '';
                output[i][j + 2] = '';
                output[i + 2][j + 2] = '';
            }
        }
    }

    for (var i = 0; i < output.length; i++) {
        console.log(output[i].join(''));
    }
}