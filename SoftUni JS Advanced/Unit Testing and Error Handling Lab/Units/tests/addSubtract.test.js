const { expect } = require('chai');
const { createCalculator } = require('../utils/addSubtract');

describe('createCalculator', () => {

    it('Should return undefined with not correct add input string', () => {
        let text = 'text';

        let creator = createCalculator();

        expect(creator.add(text)).to.be.undefined;
    });

    it('Should return undefined with not correct subtract input string', () => {
        let text = 'text';

        let creator = createCalculator();

        expect(creator.subtract(text)).to.be.undefined;
    });

    it('Should return number with correct add input', () => {
        let num = 5;

        let creator = createCalculator();
        creator.add(num);

        let result = creator.get();

        expect(result).to.be.equal(num);
    });

    it('Should return number with correct subtract input', () => {
        let num = 5;

        let creator = createCalculator();
        creator.add(num);
        creator.subtract(4);

        let result = creator.get();

        expect(result).to.be.equal(1);
    });

});