function nums(array)
{
    let SortedArray = new Array;

    for (let i = 0; i < array.length; i++) {
        let element = array[i];
        if(element < 0)
        {
            SortedArray.unshift(element);
        }
        else
        {
            SortedArray.push(element);
        }
    }

    console.log(SortedArray.join('\n'));
}

nums([7, -2, 8, 9]);
nums([3, -2, 0, -1]);