/*
    Write a JavaScript function lastDigitAsText(number) that
    returns the last digit of given integer as an English word.
    Write a JS program lastDigitOfNumber.js that invokes your function with
    the sample input data below and prints the output at the console. 
*/

function lastDigitAsText(number) {
    var lastDigit = Math.abs(Number(number)) % 10;
    switch (lastDigit) {
        case 1: return "One";
        case 2: return "Two";
        case 3: return "Three";
        case 4: return "Four";
        case 5: return "Five";
        case 6: return "Six";
        case 7: return "Seven";
        case 8: return "Eight";
        case 9: return "Nine";
        case 0: return "Zero";
    }
}

console.log(lastDigitAsText(6));
console.log(lastDigitAsText(-55));
console.log(lastDigitAsText(133));
console.log(lastDigitAsText(14567));