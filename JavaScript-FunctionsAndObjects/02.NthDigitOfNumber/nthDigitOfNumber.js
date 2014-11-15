/*
    Write a JavaScript function findNthDigit(arr) that
    accepts as a parameter an array of two numbers num and
    n and returns the n-th digit of
    given decimal number num counted from right to left.
    Return undefined when the number does not have n-th digit.
    Write a JS program nthDigitOfNumber.js that invokes your
    function with the sample input data below and prints the output at the console.
*/

function findNthDigit(arr) {
    var num = Number(arr[0]);
    var n = arr[1].toString().match(/\d+/g).join('');

    return n[n.length - num];
}

function printResult(arr) {
    var result = findNthDigit(arr);
    if (result) {
        console.log(result);
    } else {
        console.log("The number doesn't have %d digits", arr[0]);
    }
}

printResult([1, 6]);
printResult([2, -55]);
printResult([6, 923456]);
printResult([3, 1451.78]);
printResult([6, 888.88]);

