function sumOfNum(num1, num2)
{
    let start = Number(num1);
    let end = Number(num2);

    let result = 0;
    for(let i = start; i <= end; i++)
    {
        result += i;
    }

    console.log(result);
}

sumOfNum('1', '5');
sumOfNum('-8', '20');