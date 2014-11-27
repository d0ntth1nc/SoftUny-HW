/*
    Write a JavaScript function findMaxSequence(arr) that
    finds the maximal increasing sequence in an array of numbers and
    returns the result as an array.
    If there is no increasing sequence the function returns 'no'.
    Write JS program maxSequenceFinder.js that
    invokes your function with the sample input data below and prints the output at the console.
*/

function findMaxSequence(arr) {
    var currentSequence = [], maxSequence = [];

    currentSequence.push(arr[0]);
    for (var i = 1; i < arr.length; i++) {
        if (arr[i] > currentSequence[currentSequence.length - 1]) {
            currentSequence.push(arr[i]);
        } else {
            currentSequence = [arr[i]];
        }

        if (currentSequence.length > maxSequence.length) {
            maxSequence = currentSequence.slice();
        }
    }

    if (maxSequence.length > 1) {
        console.log(maxSequence);
    } else {
        console.log("no");
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);