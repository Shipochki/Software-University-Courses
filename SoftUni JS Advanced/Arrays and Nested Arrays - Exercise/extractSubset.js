function extract(inputArr)
{
    let arr = [inputArr.shift()];
    for (let i = 0; i < inputArr.length; i++) {
        if(inputArr[i] >= arr[arr.length - 1])
        {
            arr.push(inputArr[i]);
        }
    }

    return arr;
}

console.log(extract([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));
console.log(extract([1,
    2,
    3,
    4]
));
console.log(extract([20,
    3,
    2,
    15,
    6,
    1]
));