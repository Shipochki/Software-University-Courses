function solution(n) {
    let number = Number(n);
    return function (num) {
       let res = number + Number(num);
       return res;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
