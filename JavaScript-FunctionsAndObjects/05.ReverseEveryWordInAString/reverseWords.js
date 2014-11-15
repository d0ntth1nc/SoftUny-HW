/*
    Write a JavaScript function reverseWordsInString(str) that
    accepts as a parameter a string and reverses the characters of
    every word in the string but leaves the words in the same order.
    Words are considered to be sequences of characters separated by spaces. 
*/

function reverseWordsInString(str) {
    var words = str.split(' ');
    var result = "";

    for (var i = 0; i < words.length; i++) {
        result += words[i].split('').reverse().join('');
        result += ' ';
    }

    return result;
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString('Life is pretty good, isn’t it?'));