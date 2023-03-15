function lastK(n, k)
{
    let array = new Array;
    array.push(1);

    for (let i = 1; i < k; i++) {
        array.push(i);
    }

    for (let i = k; i < n; i++) {
        let num = 0;

        for (let j = i - 1; j >= i - k; j--) {
            num += array[j];
        }

        array.push(num);
    }

    return array;
}

lastK(6, 3);
lastK(8, 2);