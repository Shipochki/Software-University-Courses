function record(name, population, treasury)
{
    let city = {
        name: name,
        population: Number(population),
        treasury: Number(treasury),
    };

    return city;
}

console.log(record('Tortuga',
7000,
15000
));

console.log(record('Santo Domingo',
12000,
23500
));