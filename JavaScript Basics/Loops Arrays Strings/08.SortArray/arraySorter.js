/*
    Sorting an array means to arrange its elements in increasing order.
    Write a JavaScript function sortArray(arr) to sort an array.
    Use the "selection sort" algorithm: find the smallest element,
    move it at the first position, find the smallest from the rest,
    move it at the second position, etc.
    Write JS program arraySorter.js that
    invokes your function with the sample input data below
    and prints the output at the console.
*/

function sortArray(arr) {
    var i, j, swap, len = arr.length;

    for (i = 0; i < len; i++) {
        for (j = i + 1; j < len; j++) {
            if (arr[j] < arr[i]) {
                swap = arr[i];
                arr[i] = arr[j];
                arr[j] = swap;
            }
        }
    }
}

var arr1 = [5, 4, 3, 2, 1];
var arr2 = [12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3];

sortArray(arr1);
sortArray(arr2);

console.log(arr1);
console.log(arr2);