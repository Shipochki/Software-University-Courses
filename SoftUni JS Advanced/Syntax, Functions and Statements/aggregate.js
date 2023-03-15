function aggregate(arr)
{
    let result1 = 0;
    let result2 = 0;
    let result3 = '';
    arr.forEach(element => {
        result1 += Number(element);
        result2 += 1 / Number(element);
        result3 += element;
    });

    console.log(result1);
    console.log(result2);
    console.log(result3);
}

aggregate([1, 2, 3]);
aggregate([2, 4, 8, 16]);