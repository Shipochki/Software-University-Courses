const { expect } = require('chai');
const { printDeckOfCards } = require('../utils/printDeckOfCards');

describe('printDeckOfCards', () => {

    it('Should return correct result with string', () => {

        let array = ['AS', '10D', 'KH', '2C'];

        let result = printDeckOfCards(array);
        let expected = 'A♠ 10♦ K♥ 2♣';

        expect(result).to.be.equal(expected);
    })

    it('Should return invalid result with string', () => {

        let array = ['5S', '3D', 'QD', '1C'];

        let result = printDeckOfCards(array);
        let expected = 'Invalid card: 1C';

        expect(result).to.be.equal(expected);
    });
});