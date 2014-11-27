/*
    Write a JavaScript function createArray() that
    allocates array of 20 integers and
    initializes each element by its index multiplied by 5.
    Write JS program arrayBuilder.js that invokes your
    function and prints the output at the console.
*/

function createArray() {
    var array = [], len = 20, multiplyer = 5;
    for (var i = 0; i < len; i++) {
        array.push(i * multiplyer);
    }

    return array;
}

console.log(createArray().join(' '));