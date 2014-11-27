/*
    Write a JavaScript function compareChars(arr1, arr2) that
    compares two arrays of chars lexicographically (letter by letter).
    Write JS program charComparer.js that
    invokes your function with the sample input data below
    and prints the output at the console.
*/

function compareChars(arr1, arr2) {
    var len = arr1.length

    if (len != arr2.length) {
        return false;
    }

    for (var i = 0; i < len; i++) {
        if (arr1[i] != arr2[i]) {
            return false;
        }
    }

    return true;
}

function printResult(result) {
    if (result) {
        console.log("Equal");
    } else {
        console.log("Not Equal");
    }
}

printResult(compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
    ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']));

printResult(compareChars(['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']));

printResult(compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
    ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']));