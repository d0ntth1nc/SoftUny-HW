/*
    Write a JavaScript function findPalindromes(str) that
    extracts from a given text all palindromes,
    e.g. "ABBA", "lamal", "exe".
    Write JS program palindromesExtract.js that
    invokes your function with the sample input data below
    and prints the output at the console.
*/

function findPalindromes(str) {
    var palindromes = [];
    var words = str.split(/\W+/);

    for (var i = 0; i < words.length; i++) {
        var word = words[i].toLowerCase();
        var isPalindrome = true;

        if (word == '') continue;

        for (var j = 0, len = word.length; j < len / 2; j++) {
            if (word[j] != word[len - 1 - j]) {
                isPalindrome = false;
            }
        }

        if (isPalindrome) {
            palindromes.push(word);
        }
    }

    return palindromes;
}

console.log(findPalindromes('There is a man, his name was Bob.'));