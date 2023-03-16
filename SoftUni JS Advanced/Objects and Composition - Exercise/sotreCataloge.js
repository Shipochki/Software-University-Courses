function cataloge(array)
{
    array = array.sort((a, b) => a.localeCompare(b));
    let currentLetter;
    array.forEach(element => {
        let info = element.split(' : ');
        if(currentLetter !== info[0][0])
        {
            currentLetter = info[0][0];
            console.log(currentLetter);
        }
        console.log(`  ${info[0]}: ${info[1]}`)
    });
}

cataloge(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);

cataloge(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']
);