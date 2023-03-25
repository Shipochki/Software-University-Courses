function printDeckOfCards(cards) {

    function playingCards(face, suit) {
        let correctFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let correctSuit = ['S', 'H', 'D', 'C'];

        if (!correctFaces.includes(face) ||
            !correctSuit.includes(suit)) {
            return `Invalid card: ${face}${suit}`;
        }


        let result = `${face}`;
        if (suit === 'S') {
            result += '\u2660';
        }
        else if (suit === 'H') {
            result += '\u2665';
        }
        else if (suit === 'D') {
            result += '\u2666';
        }
        else {
            result += '\u2663';
        }

        return result;
    }

    let deck = [];
    for (let i = 0; i < cards.length; i++) {
        let card = cards[i];
        let result = '';
        if(card.length === 3){
            result = playingCards(`${card[0]}${card[1]}`, card[2]);
        }
        else{
            result = playingCards(card[0], card[1]);
        }

        if(result === `Invalid card: ${card}`){
            console.log(result);
            return;
        }

        deck.push(result);
    }

    console.log(deck.join(' '));
}

module.exports = { printDeckOfCards };