function heroicToJson(array)
{
    let objects = [];
    
    array.forEach(element => {
        let info = element.split(' / ');
        objects.push({
            name: info[0],
            level: Number(info[1]),
            items: info[2] ? info[2].split(', ') : [],
        })
    });

    return JSON.stringify(objects);
}

console.log(heroicToJson(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));