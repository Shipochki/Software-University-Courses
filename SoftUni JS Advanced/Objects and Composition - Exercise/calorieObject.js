function calorieObject(array)
{
    let result = [];
    for (let i = 0; i < array.length - 1; i += 2) {
        let name = array[i];
        let calorie = array[i + 1]
        result.push(`${name}: ${calorie}`)
    }
    console.log(`{ ${result.join(', ')} }`);
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);