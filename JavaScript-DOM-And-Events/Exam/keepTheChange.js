function getTip(arr) {
    var bill = Number(arr[0]);
    var mood = arr[1];
    var tipPercentage;

    switch (mood) {
        case "happy": tipPercentage = 0.1; break;
        case "drunk": tipPercentage = 0.15; break;
        case "married": tipPercentage = 0.0005; break;
        default: tipPercentage = 0.05; break;
    }

    var tip = bill * tipPercentage;
    if (mood == "drunk") {
        var firstDigit = Number(tip.toString()[0]);
        tip = Math.pow(tip, firstDigit);
    }

    console.log(tip.toFixed(2));
}