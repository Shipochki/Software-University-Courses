function calcFruit(type, grams, price)
{
    let weight = grams * 0.001;
    let sumPrice = weight * price;
    console.log(`I need $${sumPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${type}.`);
}

calcFruit('orange', 2500, 1.80);
calcFruit('apple', 1563, 2.35);