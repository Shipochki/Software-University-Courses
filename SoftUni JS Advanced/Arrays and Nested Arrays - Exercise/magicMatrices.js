function magic(matrix)
{
    let sum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            sum += matrix[row][col];
        }
        break;
    }

    let result = true;

    for (let row = 0; row < matrix.length; row++) {
        let currentCol = 0;
        let currentRow = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            currentCol += matrix[row][col];
            currentRow += matrix[col][row]
        }

        if(currentCol !== sum || currentRow !== sum)
        {
            result = false;
        }
    }

    console.log(result);
}

magic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );
magic([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   );
magic([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   );