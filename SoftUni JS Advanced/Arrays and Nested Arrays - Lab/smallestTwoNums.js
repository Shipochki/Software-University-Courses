function smallestTwo(array)
{
    let smallest = array.sort(function(a, b){return a - b}).slice(0,2);

    console.log(smallest.join());
}

smallestTwo([30, 15, 50, 5]);
smallestTwo([3, 0, 10, 4, 7, 3]);