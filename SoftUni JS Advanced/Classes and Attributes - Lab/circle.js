class Circle {
    constructor(r) {
        this.diameter = 2 * r;
    }

    get diameter() { return this._diameter }
    set diameter(value) {
        this._diameter = value;
        this.radius = this._diameter / 2;
    }

    get radius() { return this._radius}
    set radius(value) { this._radius = value }

    get area() { return Math.PI * this.radius * this.radius }

}

let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
