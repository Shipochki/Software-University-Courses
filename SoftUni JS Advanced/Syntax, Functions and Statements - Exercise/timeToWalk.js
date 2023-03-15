function timeToWalk(steps, length, kmh)
{
    let distance = (steps * length);
    let breaks = Math.floor(distance / 500);
    let time = ((distance * 0.001) / kmh) * 60;
    let hours = time / 60;
    let minutes = Math.floor(time + breaks);
    let seconds = time * 60 % 60;
    hours = hours.toFixed(0);
    minutes = minutes.toFixed(0);
    seconds = seconds.toFixed(0);

    if(hours < 10)
    {
        hours = `0${hours}`;
    }

    if(minutes < 10)
    {
        minutes = `0${minutes}`;
    }

    if(seconds < 10)
    {
        seconds = `0${seconds}`;
    }

    console.log(`${hours}:${minutes}:${seconds}`);
}

timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);