class Stringer {
    constructor(text, initalLength) {
        this.initalString = text;
        this.initalLength = Number(initalLength);
    }

    get initalString() { return this._initalString; }
    set initalString(value) { this._initalString = value; }

    get initalLength() { return this._initalLength; }
    set initalLength(value) { this._initalLength = value; }

    decrease(length) {
        if (this.initalLength - length > 0) {
            this.initalLength -= length;
        }
        else{
            this.initalLength = 0;
        }

    }

    increase(length) {
        if (this.initalLength + length <= this.initalString.length) {
            this.initalLength += length;
        }
        else{
            this.initalLength = this.initalLength.length;
        }
    }

    toString() {
        if (this.initalLength === 0) {
            return '...';
        }
        else {
            let result = this.initalString.slice(0, this.initalLength);

            if(result !== this.initalString){
               result += '...';
            }

            return result;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
