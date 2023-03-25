function sum(array, input1, input2) {
    let result = 0;

    if (!Array.isArray(array)) {
        return NaN;
    }

    if (input1 < 0) {
        input1 = 0;
    }

    if (input2 > array.length - 1) {
        input2 = array.length - 1;
    }

    for (let i = input1; i <= input2; i++) {
        result += Number(array[i]);
    }

    return result;
}

module.exports = { sum };
