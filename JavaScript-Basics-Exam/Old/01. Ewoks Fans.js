function get(arr) {
    var fansDate = new Date(1973, 05, 25);

    var fans = [];
    var haters = [];

    for (var i = 0; i < arr.length; i++) {
        var dateValues = arr[i].split('.');
        var currentDate = new Date(dateValues[2], dateValues[1] - 1, dateValues[0]);
        if (currentDate > new Date(1900, 0, 1) && currentDate < new Date(2015, 0, 1)) {
            if (currentDate >= fansDate) {
                fans.push(currentDate);
            } else {
                haters.push(currentDate);
            }
        }
    }

    fans.sort(function (a, b) {
        return a - b;
    });
    haters.sort(function (a, b) {
        return a - b;
    });

    if (!fans.length && !haters.length) {
        console.log("No result");
    } else {
        if (fans.length) {
            console.log("The biggest fan of ewoks was born on %s", fans[fans.length - 1].toDateString());
        }
        if (haters.length) {
            console.log("The biggest hater of ewoks was born on %s", haters[0].toDateString());
        }
    }
}