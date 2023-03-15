function sort(array)
{
    let arr = array.sort((a, b) => a.localeCompare(b));
    for (let i = 0; i < array.length; i++) {
        console.log(`${i + 1}.${arr[i]}`)
    }
}

sort(["John", "Bob", "Christina", "Ema"]);