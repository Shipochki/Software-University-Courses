function rectangle(width, height, color)
{
    let firstLeter = color.charAt(0).toUpperCase();
    let fixedColor = firstLeter + color.slice(1);
    return {
        width: width,
        height: height,
        color: fixedColor,
        calcArea()
        {
            return this.height * this.width;
        }
    }
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
