function previusDay(year, month, day)
{
    let date = new Date(year, month - 1, day - 1)

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

previusDay(2016, 9, 30);
previusDay(2015, 5, 10);