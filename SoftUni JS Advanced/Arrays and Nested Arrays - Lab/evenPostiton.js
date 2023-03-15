function evenPostion(array)
{
    let evens = new Array;

    for (let i = 0; i < array.length; i++) {
        if(i % 2 === 0)
        {
            evens.push(array[i]);
        }
    }

    console.log(evens.join(' '));
}

evenPostion(['20', '30', '40', '50', '60']);
evenPostion(['5', '10']);