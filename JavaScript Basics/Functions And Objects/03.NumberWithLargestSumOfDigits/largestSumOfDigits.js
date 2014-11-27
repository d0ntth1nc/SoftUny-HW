/*
    Write a JavaScript function findLargestBySumOfDigits(arr) that
    accepts as a parameter an array of numbers or/and strings and
    returns the element with the largest sum of its digits.
    The function should take a variable number of arguments.
    It should return undefined when 0 arguments are passed or
    when some of the arguments is not an integer number.
    Write a JS program largestSumOfDigits.js that invokes your
    function with the sample input data below and prints its output at the console. 
*/

function findLargestBySumOfDigits(arr) {
    var largestBySumOfDigits, maxSum = -1;

    for (var i = 0; i < arr.length; i++) {
        var number = Math.abs(Number(arr[i]));
        if (!isInt(number)) {
            return undefined;
        }

        var currentSum = 0;
        while (number > 0) {
            currentSum += number % 10;
            number = Math.floor(number / 10);
        }

        if (currentSum == Math.max(currentSum, maxSum)) {
            maxSum = currentSum;
            largestBySumOfDigits = arr[i];
        }
    }

    return largestBySumOfDigits;
}

function isInt(n) {
    return n % 1 === 0;
}

console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));