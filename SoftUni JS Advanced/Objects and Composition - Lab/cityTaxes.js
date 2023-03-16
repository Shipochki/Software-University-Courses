function cityTaxes(name, population, treasury)
{
    let city = {
        name: name,
        population: Number(population),
        treasury: Number(treasury),
        taxRate: 10,
        collectTaxes: function()
        {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth: function(percentage)
        {
            this.population += this.population * (percentage * 0.01);
        },
        applyRecession: function(percentage)
        {
            this.treasury -= this.treasury * (percentage * 0.01);
        }
    };

    return city;
}


const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
