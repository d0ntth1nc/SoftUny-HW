/*
    Write a JavaScript function sumTwoHugeNumbers(value) that
    accepts as parameter an array containing the two numbers.
    The input numbers are represented as strings.
    You are not allowed to use external libraries.
    The result should be printed on the console. 
*/

function sumTwoHugeNumbers(value) {
    var biggerNumberLength = Math.max(value[0].length, value[1].length);
    var biggerNumber = value[0].length == biggerNumberLength ? value[0] : value[1];
    var smallerNumber = biggerNumber == value[0] ? value[1] : value[0];

    biggerNumber = biggerNumber.split('').reverse();
    smallerNumber = smallerNumber.split('').reverse();

    var result = [];
    var inMind = false;
    for (var i = 0; i < biggerNumber.length; i++) {
        var currentNum = inMind ? 1 : 0;

        currentNum += Number(biggerNumber[i]);
        if (i < smallerNumber.length) {
            currentNum += Number(smallerNumber[i]);
        }

        if (currentNum > 9) {
            inMind = true;
            currentNum %= 10;
        } else {
            inMind = false;
        }

        result.push(currentNum);
    }

    return result.reverse().join('');
}

var testPassed = true;

var result = sumTwoHugeNumbers(['155', '65']);
if (result != "220") {
    testPassed = false;
}

result = sumTwoHugeNumbers(['123456789', '123456789']);
if (result != "246913578") {
    testPassed = false;
}

result = sumTwoHugeNumbers(['887987345974539', '4582796427862587']);
if (result != "5470783773837126") {
    testPassed = false;
}

result = sumTwoHugeNumbers(['347135713985789531798031509832579382573195807', '817651358763158761358796358971685973163314321']);
if (result != "164787072748948293156827868804265355736510128") {
    testPassed = false;
}

console.log("Test passed? -> " + testPassed);