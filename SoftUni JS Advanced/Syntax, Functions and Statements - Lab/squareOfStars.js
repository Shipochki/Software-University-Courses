function sqare(size)
{
    let result = '';
    for (let i = 0; i < size; i++) {
       for (let j = 0; j < size; j++) {
            result += '* ';
       }
       console.log(result);
       result = '';
    }
}

sqare(1);
sqare(2);
sqare(5);
sqare(7);