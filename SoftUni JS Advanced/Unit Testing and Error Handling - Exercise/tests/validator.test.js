const { expect, assert } = require('chai');
const { validator } = require('../utils/requestValidator');

describe('validator', () => {

    it('should return same object with correct input object', () => {
        let obj = {
            method: 'GET',
            uri: 'svn.public.catalog',
            version: 'HTTP/1.1',
            message: ''
        }

        let result = validator(obj);

        expect(result).to.be.equal(obj);
    });

    it('should throw error because invalid method', () => {
        let obj = {
            method: 'OPTIONS',
            uri: 'git.master',
            version: 'HTTP/1.1',
            message: '-recursive'
        }

        expect(() => validator(obj)).to.throw(Error).which.has.property('message', 'Invalid request header: Invalid Method');
    });
});