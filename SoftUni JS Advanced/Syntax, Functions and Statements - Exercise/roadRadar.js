function roadRadar(num, zone)
{
    let kmhZone = 130;
    let kmh = Number(num);
    let status = 'speeding';
    let result;

    if(zone === 'interstate')
    {
        kmhZone = 90;
    }
    else if(zone === 'city')
    {
        kmhZone = 50;
    }
    else if(zone === 'residential')
    {
        kmhZone = 20;
    }

    if(kmh <= kmhZone)
    {
        result = `Driving ${kmh} km/h in a ${kmhZone} zone`;
    }
    else
    {
        let speeding = kmh - kmhZone;
        if(speeding > 40)
        {
            status = 'reckless driving'
        }
        else if(speeding > 20)
        {
            status = 'excessive speeding'
        }

        result = `The speed is ${speeding} km/h faster than the allowed speed of ${kmhZone} - ${status}`
    }

    console.log(result);
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');