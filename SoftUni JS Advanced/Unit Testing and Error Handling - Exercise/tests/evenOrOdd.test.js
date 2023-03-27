const { expect, assert } = require('chai');
const { isOddOrEven } = require('../utils/evenOrOdd');

describe('isOddOrEven', () => {

    it('should return string even with even length input', () => {
        let text = "text";

        let result = isOddOrEven(text);
        let expected = 'even';

        expect(result).to.be.equal(expected);
    });

    it('should return string odd with odd length input', () => {
        let text = "text1";

        let result = isOddOrEven(text);
        let expected = 'odd';

        expect(result).to.be.equal(expected);
    });

    it('should return undefined with number input', () => {
        let number = 5;

        let result = isOddOrEven(number);

        expect(result).to.be.equal(undefined);
    });
});