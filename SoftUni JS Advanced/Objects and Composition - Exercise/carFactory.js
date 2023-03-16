function factory(obj) {
    let car = {
        model: obj.model,
        engine: {
            power: 0,
            volume: 0,
        },
        carriage: {
            type: obj.carriage,
            color: obj.color,
        },
        wheels: []
    };

    if (obj.power <= 90) {
        car.engine.power = 90;
        car.engine.volume = 1800;
    }
    else if (obj.power <= 120) {
        car.engine.power = 120;
        car.engine.volume = 2400;
    }
    else if (obj.power >= 200) {
        car.engine.power = 200;
        car.engine.volume = 3500;
    }

    if(obj.wheelsize % 2 === 0)
    {
        obj.wheelsize --;
    }

    car.wheels = [obj.wheelsize, 
            obj.wheelsize,
            obj.wheelsize,
            obj.wheelsize];

    return car;
}

console.log(factory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));