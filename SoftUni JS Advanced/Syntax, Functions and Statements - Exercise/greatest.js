function gratest(num1, num2)
{
    let gratestNum = 0;

    let smallest = Number(num1);

    if(num2 < num1)
    {
        smallest = num2;
    }

    for (let i = 1; i <= smallest; i++) {
        if(Number(num1) % i == 0 && Number(num2) % i == 0)
        {
            gratestNum = i;
        }
    }

    console.log(gratestNum);
}

gratest(15, 5);
gratest(2154, 458);