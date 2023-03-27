const { expect } = require('chai');
const { lookupChar } = require('../utils/charLookup');

describe('lookupChar', () => {

    it('should return undefined with not valid string input', () => {
        let num = 5;
        let index = 1;

        let result = lookupChar(num, index);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined with not valid index input', () => {
        let text = "text";
        let text2 = 'text2';

        let result = lookupChar(text, text2);

        expect(result).to.be.equal(undefined);
    });

    it('should return Incorrect index with float index input', () => {
        let text = "text";
        let index = 5.4;

        let result = lookupChar(text, index);

        expect(result).to.be.equal(undefined);
    });

    it('should return Incorrect index with negative index input', () => {
        let text = "text";
        let index = -1;

        let result = lookupChar(text, index);
        let expected = 'Incorrect index';

        expect(result).to.be.equal(expected);
    });

    it('should return Incorrect index with index bigger than text length input', () => {
        let text = "text";
        let index = 5;

        let result = lookupChar(text, index);
        let expected = 'Incorrect index';

        expect(result).to.be.equal(expected);
    });

    it('should return Incorrect index with index equal to text length input', () => {
        let text = "text";
        let index = 4;

        let result = lookupChar(text, index);
        let expected = 'Incorrect index';

        expect(result).to.be.equal(expected);
    });

    it('should return correct char at index with valid input', () => {
        let text = "text";
        let index = 1;

        let result = lookupChar(text, index);
        let expected = 'e';

        expect(result).to.be.equal(expected);
    });
});