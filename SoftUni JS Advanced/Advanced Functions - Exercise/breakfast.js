function solution() {
    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        }
    }

    let amounts = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    return (input) => {
        let data = input.split(' ');
        let command = data[0];
        let type = data[1];
        let amount = Number(data[2]);
        if (command === 'restock') {
            amounts[type] += amount;
            return "Success";
        }
        else if (command === 'prepare') {
            let obj = recipes[type];
            let keys = Object.keys(obj);
            let values = Object.values(obj);

            for (let i = 0; i < keys.length; i++) {
                let key = keys[i];
                let value = values[i];
                if (amounts[key] < value) {
                    return `Error: not enough ${key} in stock`;
                }
            }

            for (let i = 0; i < keys.length; i++) {
                let key = keys[i];
                let value = values[i];
                amounts[key] -= value;
            }

            return "Success";
        }
        else if (command === 'report') {
            let result = '';
            let keys = Object.keys(amounts);
            let values = Object.values(amounts);

            for (let i = 0; i < keys.length; i++) {
                let key = keys[i];
                let value = values[i];

                result += `${key}=${value} `;
            }

            return result.trimEnd();
        }
    }
}

let manager = solution();
console.log(manager("prepare turkey 1")); // Success 
console.log(manager("restock protein 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("report"));
