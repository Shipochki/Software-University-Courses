function sort(array)
{
    let cities = [];

    array.forEach(element => {
        let info = element.split(' | ');
        let townName = info[0];
        let productName = info[1];
        let price = Number(info[2]);

        if(cities.some(c => c.productName === productName))
        {
           let city = cities.find(c => c.productName === productName);
            if(city.price > price)
            {
                city.townName = townName;
                city.price = price;
            }
            
        }
        else
        {
            cities.push({
                townName: townName,
                productName: productName,
                price: price
            });
        }
    });

    cities.forEach(city =>{
        console.log(`${city.productName} -> ${city.price} (${city.townName})`);
    })
}

sort(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);
