function solve(input){
    let arr = []
    input.forEach(element => {
        let info = element.split(' ');
        if(info[0] === 'add'){
            arr.push(info[1]);
        }
        else if(info[0] === 'remove'){
            let index = arr.indexOf(info[1]);
            arr.splice(index, 1);
        }
        else if(info[0] === 'print')
        {
            console.log(arr.join(','));
        }
        
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);