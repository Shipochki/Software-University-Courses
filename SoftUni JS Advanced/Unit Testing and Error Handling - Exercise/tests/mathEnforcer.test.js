const { expect } = require('chai');
const { mathEnforcer } = require('../utils/mathEnforcer');

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return correct result with number input', () => {
            let num = 5;

            let result = mathEnforcer.addFive(num);

            expect(result).to.be.equal(10);
        });

        it('should return undefined with invalid input', () => {
            let text = 'text';

            let result = mathEnforcer.addFive(text);

            expect(result).to.be.equal(undefined);
        });
    });

    describe('subtractTen', () => {
        it('should return correct result with number input', () => {
            let num = 10;

            let result = mathEnforcer.subtractTen(num);

            expect(result).to.be.equal(0);
        });

        it('should return undefined with invalid input', () => {
            let text = 'text';

            let result = mathEnforcer.subtractTen(text);

            expect(result).to.be.equal(undefined);
        });
    });

    describe('sum', () => {
        it('should return correct result with number input', () => {
            let num1 = 5;
            let num2 = 5;

            let result = mathEnforcer.sum(num1, num2);

            expect(result).to.be.equal(10);
        });

        it('should return undefined with first invalid input', () => {
            let text = 'text';

            let result = mathEnforcer.sum(text, 5);

            expect(result).to.be.equal(undefined);
        });

        it('should return undefined with second invalid input', () => {
            let text = 'text';

            let result = mathEnforcer.sum(5, text);

            expect(result).to.be.equal(undefined);
        });
    });
});