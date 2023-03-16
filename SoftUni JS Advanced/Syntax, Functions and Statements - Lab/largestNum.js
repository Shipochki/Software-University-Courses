function largestNum(num1, num2, num3)
{
    let num = num1;
    if(num2 > num1 && num2 > num3)
    {
        num = num2;
    }
    else if(num3 > num1 && num3 > num2)
    {
        num = num3;
    }

    console.log(`The largest number is ${num}.`)
}

largestNum(5, -3, 16);
largestNum(-3, -5, -22.5);