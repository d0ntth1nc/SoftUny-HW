/*
    Write a JavaScript function findMostFreqWord(str) that
    finds the most frequent word in a text and prints it,
    as well as how many times it appears in format "word -> count".
    Consider any non-letter character as a word separator.
    Ignore the character casing.
    If several words have the same maximal frequency,
    print all of them in alphabetical order.
    Write JS program frequentWord.js that invokes your
    function with the sample input data below and prints the output at the console. 
*/

function findMostFreqWord(str) {
    var words = str.toLowerCase().split(/\W+/);
    var wordsOccurences = {};

    for (var i = 0, len = words.length; i < len; i++) {
        if (!wordsOccurences[words[i]]) {
            wordsOccurences[words[i]] = 0;
        }
        wordsOccurences[words[i]]++;
    }

    var wordsAppearances = [];
    for (var key in wordsOccurences) {
        wordsAppearances.push(wordsOccurences[key]);
    }
    wordsAppearances.sort();

    var mostFreqWordAppearancesCount = wordsAppearances[wordsAppearances.length - 1];
    var sortedWords = [];
    for (var key in wordsOccurences) {
        if (wordsOccurences[key] == mostFreqWordAppearancesCount) {
            sortedWords.push(key);
        }
    }

    sortedWords.sort();
    for (var i = 0, len = sortedWords.length; i < len; i++) {
        console.log(sortedWords[i] + " -> " + mostFreqWordAppearancesCount + " times");
    }
}

console.log("--------------------------");
findMostFreqWord('in the middle of the night');
console.log("--------------------------");
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
console.log("--------------------------");
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');
console.log("--------------------------");