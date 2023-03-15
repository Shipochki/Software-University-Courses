function circleArea(num)
{
    let inputType = typeof(num);

    if('number' === inputType)
    {
        let result = Math.pow(num, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else
    {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`) 
    }
}

circleArea(5);
circleArea('name');