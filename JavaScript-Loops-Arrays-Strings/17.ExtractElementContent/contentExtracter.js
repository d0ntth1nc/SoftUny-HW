/*
    Write a JavaScript function extractContent(str) that
    extracts the text content from given HTML fragment (given as string).
    The function should return anything that is in a tag, without the tags.
    Write JS program contentExtracter.js that invokes your
    function with the sample input data below and prints the output at the console. 
*/

function extractContent(str) {
    var regex = /\>(\w+)<\//g;

    var match = regex.exec(str);
    var result = "";
    while (match != null) {
        result += match[1];
        match = regex.exec(str);
    }

    console.log(result);
}

extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>");