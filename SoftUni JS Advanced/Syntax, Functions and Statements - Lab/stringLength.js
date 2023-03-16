function stringLength(string1, string2, string3)
{
    let sum = 0;
    sum += string1.length;
    sum += string2.length;
    sum += string3.length;

    console.log(sum);
    console.log(Math.floor(sum / 3));
}

stringLength('chocolate', 'ice cream', 'cake');
stringLength('pasta', '5', '22.3');