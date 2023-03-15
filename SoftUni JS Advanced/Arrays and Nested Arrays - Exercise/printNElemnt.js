function print(array, n)
{
    let newArray = new Array;

    for (let i = 0; i < array.length; i += n) {
        newArray.push(array[i]);
    }

    return newArray;
}