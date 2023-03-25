function playingCarts(face, suit){
    let correctFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    if(!correctFaces.includes(face)){
        throw new Error;
    }

    let correctSuit = ['S', 'H', 'D', 'C'];

    if(!correctSuit.includes(suit)){
        throw new Error;
    }

    let result = `${face}`;
    if(suit === 'S'){
        result += '\u2660';
    }
    else if(suit === 'H'){
        result += '\u2665';
    }
    else if(suit === 'D'){
        result += '\u2666';
    }
    else{
        result += '\u2663';
    }

    return result;
}

module.exports = { playingCarts };