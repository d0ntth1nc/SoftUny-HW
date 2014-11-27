/*
    Write a JavaScript function findMostFreqNum(arr) that
    finds the most frequent number in an array.
    If multiple numbers appear the same maximal number of times,
    print the leftmost of them.
    Write JS program numberFinder.js that
    invokes your function with the sample input data below
    and prints the output at the console. 
*/

function findMostFreqNum(arr) {
    var numbers = {};

    for (var i = 0, len = arr.length; i < len; i++) {
        if (numbers[arr[i]]) {
            numbers[arr[i]]++;
        } else {
            numbers[arr[i]] = 1;
        }
    }

    printLeftMostMostFrequentNumber(numbers);
}

function printLeftMostMostFrequentNumber(numbersDictionary) {
    var freqCount = [];
    for (var key in numbersDictionary) {
        freqCount.push(numbersDictionary[key]);
    }

    freqCount.sort();
    var mostFrequentAppearTimes = freqCount[freqCount.length - 1];
    for (var key in numbersDictionary) {
        if (numbersDictionary[key] == mostFrequentAppearTimes) {
            console.log(key + " (" + mostFrequentAppearTimes + " times)");
            return;
        }
    }
}

findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);