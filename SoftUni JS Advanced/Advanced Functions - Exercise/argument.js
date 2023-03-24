function solve(...parms){
    let counts = [];

    for (let i = 0; i < parms.length; i++) {
        let type = typeof parms[i];
        let element = parms[i];
        console.log(`${type}: ${element}`);
        if(!counts.find(o => o.type === type)){
            counts.push({
                type: type,
                value: 0,
            });
        }

        let obj = counts.find(o => o.type === type);
        obj.value++;
    }

    counts.sort((a ,b) => b.value - a.value);

    for (let i = 0; i < counts.length; i++) {
        let element = counts[i];
        console.log(`${element.type} = ${element.value}`);
    }
}

solve({ name: 'bob'}, 3.333, 9.999);