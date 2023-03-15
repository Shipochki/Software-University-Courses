function sort(array)
{
    array = array.sort((a, b) =>
    {
        if(a.length !== b.length)
        {
            return a.length - b.length;
        }
        else
        {
            return a.localeCompare(b);
        }
    })

    console.log(array.join('\n'));
}

sort(['alpha', 
'beta', 
'gamma']
)
sort(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
)