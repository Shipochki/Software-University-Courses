function dayInMonth(month, year)
{
    console.log(new Date(year, month, 0).getDate())
}

dayInMonth(1, 2012);