function rotate(array, times)
{
    let newArray = array;
    for (let i = 0; i < times; i++) {
        let last = newArray.pop();
        newArray.unshift(last);
    }

    console.log(newArray.join(' '))
}

rotate(['1', 
'2', 
'3', 
'4'], 
2
);
rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);