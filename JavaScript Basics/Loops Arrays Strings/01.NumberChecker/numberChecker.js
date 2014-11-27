/*
    Write a JavaScript function printNumbers(number) that
    accepts as parameter an integer number.
    The function finds all integer numbers from 1 to n that are
    not divisible by 4 or by 5.
    Write a JS program numberChecker.js that
    invokes your function with the sample input data below and
    prints the output at the console.
*/

function printNumbers(number) {
    var sequence = [];

    for (var i = 0; i <= number; i++) {
        if (i % 5 && i % 4) {
            sequence.push(i);
        }
    }

    if (sequence.length) {
        console.log(sequence);
    } else {
        console.log("no");
    }
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);