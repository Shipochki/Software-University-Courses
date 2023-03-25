const { expect } = require('chai');
const { isSymmetric } = require('../utils/checkSymmetry');

describe('isSymmetric', () => {

    it('Should return false with input string', () => {
       let text = 'Text';

       let result = isSymmetric(text);

       expect(result).to.be.false;
    });

    it('Should return false with correct input', () => {
        let arr = [1, 2, 3];

        let result = isSymmetric(arr);

        expect(result).to.be.false;
    });

    it('Should return false with empty input', () => {
        let arr = [];

        let result = isSymmetric(arr);

        expect(result).to.be.true;
    });


    it('Should return true with correct input', () => {
        let arr = [1, 2, 1];

        let result = isSymmetric(arr);

        expect(result).to.be.true;
    });

    
});