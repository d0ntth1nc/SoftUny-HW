/*
    Write a JavaScript function findCardFrequency(str) that
    accepts the following parameters: string of several cards (face + suit),
    separated by a space. The function calculates and
    prints at the console the frequency of each card face in
    format "card_face -> frequency". The frequency is
    calculated by the formula appearances / N and is expressed in
    percentages with exactly 2 digits after the decimal point.
    The card faces with their frequency should be printed in
    the order of the card face's first appearance in the input.
    The same card can appear multiple times in the input,
    but its face should be listed only once in the output.
    Write JS program cardFrequencies.js that invokes your
    function with the sample input data below and prints the output at the console.
*/

function findCardFrequency(str) {
    var cards = str.split(' ');
    var cardsCount = cards.length;
    var cardFrequencies = {};

    for (var i = 0; i < cardsCount; i++) {
        var card = cards[i];
        var cardFace = card.substring(0, card.length - 1);
        if (!cardFrequencies[cardFace]) {
            cardFrequencies[cardFace] = 0;
        }
        cardFrequencies[cardFace]++;
    }

    for (var i = 0; i < cardsCount; i++) {
        var card = cards[i];
        var cardFace = card.substring(0, card.length - 1);

        if (cardFrequencies[cardFace]) {
            var appearancePercentage =
            (cardFrequencies[cardFace] / cardsCount * 100).toFixed(2);
            console.log(card + " -> " + appearancePercentage + '%');

            delete cardFrequencies[cardFace];
        }
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
console.log("--------------------------");
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
console.log("--------------------------");
findCardFrequency('10♣ 10♥');