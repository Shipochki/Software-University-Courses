function processOdd(array)
{
    let newArray = new Array;

    for (let i = 0; i < array.length; i++) {
        let element = array[i];
        if(i % 2 !== 0)
        {
            newArray.push(element * 2);
        }
    }

    return newArray.reverse();
}

console.log(processOdd([10, 15, 20, 25]));
console.log(processOdd([3, 0, 10, 4, 7, 3]));