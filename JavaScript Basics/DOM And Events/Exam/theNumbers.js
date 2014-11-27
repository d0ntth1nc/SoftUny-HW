function transform(arr) {
    var message = arr[0];
    var pattern = /\d+/g;

    var numbersInHex = [];
    var match = pattern.exec(message);
    while (match != null) {
        var hexNum = Number(match[0]).toString(16);
        numbersInHex.push(hexNum.toUpperCase());

        match = pattern.exec(message);
    }

    var hexNumbers = numbersInHex.map(function (num) {
        var hexArray = ["0x"];

        while (num.length + hexArray.length - 1 < 4) {
            hexArray.push('0');
        }

        return hexArray.join('').concat(num);
    });

    console.log(hexNumbers.join('-'));
}

transform(['5tffwj(//*7837xzc2---34rlxXP%$”.']);