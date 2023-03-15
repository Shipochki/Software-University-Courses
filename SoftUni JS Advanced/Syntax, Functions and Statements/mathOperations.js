function mathOperations(num1, num2, argument)
{
    let result = 0;
    if(argument === '+')
    {
        result = num1 + num2;
    }
    else if(argument === '-')
    {
        result = num1 - num2;
    }
    else if(argument === '*')
    {
        result = num1 * num2;
    }
    else if(argument === '/')
    {
        result = num1 / num2;
    }
    else if(argument === '%')
    {
        result = num1 % num2;
    }
    else if(argument === '**')
    {
        result = num1 ** num2;
    }

    console.log(result);
}

mathOperations(5, 6, '+')
mathOperations(3, 5.5, '*')

