const { expect } = require('chai');
const { sum } = require('../utils/app');

describe('sum', () => {

    it('should return correct result with array of numbers', () => {
        let arr = [1, 2, 3];

        let result = sum(arr, -1, 10);

        expect(result).to.be.equal(6);
    });

    it('should return Nan if input is not an array', () => {
        let array = "Text";

        let result = sum(array, 0, 3);

        expect(result).to.be.NaN;
    });

    it('should calculate correct result with array of mixed types', () => {
        let array = [true, 2, '3'];

        let result = sum(array, -2, 156);

        expect(result).to.be.equal(6);
    });
});
