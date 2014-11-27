/*
    Write a JavaScript function findMaxSequence(arr) that
    finds the maximal sequence of equal elements in
    an array and returns the result as an array.
    If there is more than one sequence with
    the same maximal length, print the rightmost one.
    Write JS program sequenceFinder.js that invokes your
    function with the sample input data below and prints the output at the console.
*/

function findMaxSequence(arr) {
    var currentSequence = [], maxSequence = [];

    currentSequence.push(arr[0]);
    maxSequence.push(arr[0]);
    for (var i = 1; i < arr.length; i++) {
        if (arr[i] === currentSequence[currentSequence.length - 1]) {
            currentSequence.push(arr[i]);
        } else {
            currentSequence = [arr[i]];
        }

        if (currentSequence.length >= maxSequence.length) {
            maxSequence = currentSequence.slice();
        }
    }

    console.log(maxSequence);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);