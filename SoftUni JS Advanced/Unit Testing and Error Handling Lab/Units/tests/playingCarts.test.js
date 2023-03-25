const { expect } = require('chai');
const { playingCarts } = require('../utils/playingCats');


describe('playingCarts', () => {

    it('should return corret result with string', () => {
        let expected = 'A♠';

        let result = playingCarts('A', 'S');

        expect(result).to.be.equal(expected);
    });

    it('should return error', () => {
        expect(() => playingCarts('A', 'g')).to.throw();
    });
});