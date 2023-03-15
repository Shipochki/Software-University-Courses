function cooking(num, ...args)
{
    let currentNum = Number(num);

    for (let i = 0; i < args.length; i++) {
        let comand = args[i];
        if(comand === 'chop')
        {
            currentNum /= 2;
        }
        else if(comand === 'dice')
        {
            currentNum = Math.sqrt(currentNum);
        }
        else if(comand === 'spice')
        {
            currentNum++;
        }
        else if(comand === 'bake')
        {
            currentNum *= 3;
        }
        else if(comand === 'fillet')
        {
            currentNum -= currentNum * 0.2;
        }

        console.log(currentNum);
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log('--------')
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');