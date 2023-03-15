function pieceofPie(array, string1, string2)
{
    let start = array.indexOf(string1);
    let end = array.indexOf(string2);
    
    return array.slice(start, end + 1);
}

console.log(pieceofPie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));
console.log('----------');
console.log(pieceofPie(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));