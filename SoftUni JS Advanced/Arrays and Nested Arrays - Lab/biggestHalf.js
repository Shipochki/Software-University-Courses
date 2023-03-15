function biggestHalf(array)
{
    let halfArr = array.sort((a ,b) => a - b).slice(array.length / 2);

    return halfArr;
}

console.log(biggestHalf([4, 7, 2, 5]));
console.log(biggestHalf([3, 19, 14, 7, 2, 19, 6]));