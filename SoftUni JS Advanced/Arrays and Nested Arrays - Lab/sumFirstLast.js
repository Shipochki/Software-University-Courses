function sum(array)
{
    let sum = Number(array[0]) + Number(array[array.length - 1]);
    return sum;
}

console.log(sum(['20', '30', '40']));
console.log(sum(['5', '10']));