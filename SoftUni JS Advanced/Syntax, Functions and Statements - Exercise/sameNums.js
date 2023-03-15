function isSameNums(input)
{
    let array = String(input);
    let first = array[0];
    let result = true;
    let sum = 0;

    for (let i = 0; i < array.length; i++) {
        
        if(array[i] !== first)
        {
            result = false;
        }

        sum += Number(array[i]);
    }

    console.log(result);
    console.log(sum);
}

isSameNums(2222222);
isSameNums(1234);