/*
    Write a JavaScript function displayProperties() that
    displays all the properties of the "document" object in
    alphabetical order. Write a JS program docProperties.js that
    invokes your function with the sample input data below
    and prints the output at the console.
*/

(function displayProperties() {
    var sortedProperties = Object.keys(document).sort(function (a, b) {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });
    for (var i = 0, len = sortedProperties.length; i < len; i++) {
        console.log(sortedProperties[i]);
    }
}());