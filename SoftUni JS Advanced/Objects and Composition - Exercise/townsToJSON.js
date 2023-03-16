function townsToJSON(array)
{
    let objects = [];
    for (let index = 1; index < array.length; index++) {
        let info = array[index].slice(2, array[index].length - 2);
        info = info.split(' | ')
        objects.push({
            Town: info[0],
            Latitude: Number(Number(info[1]).toFixed(2)),
            Longitude: Number(Number(info[2]).toFixed(2))
        })
    };

    return JSON.stringify(objects);
}

console.log(townsToJSON(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
))