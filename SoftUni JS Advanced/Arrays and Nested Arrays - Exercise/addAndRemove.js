function operations(commands) {
    let num = 1;
    let array = new Array;

    commands.forEach(command => {
        if (command === 'add') {
            array.push(num);
        }
        else if (command === 'remove') {
            array.pop();
        }
        num++;
    });

    if (array.length !== 0) {
        console.log(array.join(`\n`))
    }
    else
    {
        console.log('Empty');
    }
}

operations(['add',
    'add',
    'add',
    'add']
);
operations(['add',
    'add',
    'remove',
    'add',
    'add']
);
operations(['remove',
    'remove',
    'remove']
);