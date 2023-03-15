function validity(x1, y1, x2, y2)
{
    let isValid;

    let second = Math.sqrt(Math.pow((x2 - x1), 2));
    if(Number.isInteger(second))
    {
        isValid = 'valid';
    }
    else
    {
        isValid = 'invalid';
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${isValid}`);    

    let third = Math.sqrt(Math.pow((y2 - y1), 2));
    if(Number.isInteger(third))
    {
        isValid = 'valid';
    }
    else
    {
        isValid = 'invalid';
    }

    console.log(`{${x2}, ${y2}} to {0, 0} is ${isValid}`)

    let first = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));
    if(Number.isInteger(first))
    {
        isValid = 'valid';
    }
    else
    {
        isValid = 'invalid';
    }
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid}`)
}

validity(3, 0, 0, 4);
validity(2, 1, 1, 1);