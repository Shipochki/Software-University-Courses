const { expect } = require('chai');
const { rgbToHexColor } = require('../utils/rgbToHex');

describe('rgbToHexColor', () => {

    it('should return undefined with not corret input red', () => {
        let red = -5;
        let green = 240;
        let blue = 58;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return undefined with not corret input green', () => {
        let red = 50;
        let green = -10;
        let blue = 58;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return undefined with not corret input blue', () => {
        let red = 90;
        let green = 240;
        let blue = 300;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return undefined with not corret input type red', () => {
        let red = 'text';
        let green = 240;
        let blue = 58;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return undefined with not corret input type green', () => {
        let red = 50;
        let green = 'text';
        let blue = 58;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return undefined with not corret input type blue', () => {
        let red = 90;
        let green = 240;
        let blue = 'text';

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    });

    it('should return string with correct input', () => {
        let red = 255;
        let green = 108;
        let blue = 182;

        let result = rgbToHexColor(red, green, blue);
        let expected = '#FF6CB6';

        expect(result).to.be.equal(expected);
    });

});