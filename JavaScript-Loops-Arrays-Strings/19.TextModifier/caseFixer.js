/*
    Write a JavaScript function fixCasing(str) that accepts a text as a parameter.
    The function must change the text in all regions as follows:
⦁	<upcase>text</upcase> to uppercase
⦁	<lowcase>text</lowcase> to lowercase
⦁	<mixcase>text</mixcase> to mixed casing (randomly)
    Write JS program caseFixer.js that invokes your function with
    the sample input data below and prints the output at the console. 
*/

String.prototype.toMixCase = function() {
    var thisAsCharArray = this.toLowerCase().split('');
    for (var i = 0, len = thisAsCharArray.length; i < len; i++) {
        if (Math.round(Math.random())) {
            thisAsCharArray[i] = thisAsCharArray[i].toUpperCase();
        }
    }
    return thisAsCharArray.join('');
}

function fixCasing(str) {
    var upperCaseRegex = /<upcase>(\w+\W?\w+)<\/upcase>/g;
    var lowerCaseRegex = /<lowcase>(\w+\W?\w+)<\/lowcase>/g;
    var mixCaseRegex = /<mixcase>(\w+\W?\w+)<\/mixcase>/g;
    var match;

    // fix upper case
    match = upperCaseRegex.exec(str);
    while (match != null) {
        str = str.replace(match[0], match[1].toUpperCase());
        match = upperCaseRegex.exec(str);
    }

    // fix lower case
    match = lowerCaseRegex.exec(str);
    while (match != null) {
        str = str.replace(match[0], match[1].toLowerCase());
        match = lowerCaseRegex.exec(str);
    }

    // fix mix case
    match = mixCaseRegex.exec(str);
    while (match != null) {
        str = str.replace(match[0], match[1].toMixCase());
        match = mixCaseRegex.exec(str);
    }

    return str;
}

console.log(fixCasing("We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else."));