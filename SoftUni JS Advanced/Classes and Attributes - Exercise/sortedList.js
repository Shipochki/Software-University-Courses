class List {
    constructor() {
        this.list = [].sort((a, b) => a - b);
        this.size = this.list.length;
    }

    get list() {
        return this._list;
    }

    set list(value) {
        this._list = value;
    }

    add(element) {
        this.list.push(element);
        this.size = this.list.length;        
    }
    remove(index) {
        if (index > -1 && this.size > 0 && index < this.size) {
            this.list.splice(index, 1);
            this.size = this.list.length;            
        }
    }
    get(index) {
        if (index > -1 && this.size > 0 && index < this.size) {
            return this.list[index];
        }
    }

    get size() {
        return this._size
    }

    set size(value) {
        this._size = value
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
