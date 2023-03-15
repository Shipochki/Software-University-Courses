function sort(array)
{
    array = array.sort((a, b) => a - b);
    let firstHalf = array.slice(0, array.length / 2);
    let secondHalf = array.slice(array.length / 2, array.length).reverse();
    let newArr = [];
    for (let i = 0; i < firstHalf.length; i++) {
        newArr.push(firstHalf[i]);
        newArr.push(secondHalf[i]);
    }

    return newArr;
}

console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));