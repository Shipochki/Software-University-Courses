function population(array) {
    let towns = [];

    array.forEach(element => {
        let name = element.split(' <-> ')[0];
        let population = element.split(' <-> ')[1]

        if(!towns.some(t => t.name === name))
        {
            let city = {
                name: name,
                population: Number(population),
            };

            towns.push(city);
        }
        else
        {
            towns.find(t => t.name === name)
            .population += Number(population);
        }
    });

    towns.forEach(city => {
        console.log(`${city.name} : ${city.population}`);
    })
}

population(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);
console.log('------')
population(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
);