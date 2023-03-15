function diagonalSums(matrix)
{
    let rightSum = 0;
    let leftSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        leftSum += matrix[row][row];
        rightSum += matrix[row][matrix.length - row - 1];
    }

    console.log(`${leftSum} ${rightSum}`);
}

diagonalSums([[20, 40],
    [10, 60]]
   );
diagonalSums([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   );