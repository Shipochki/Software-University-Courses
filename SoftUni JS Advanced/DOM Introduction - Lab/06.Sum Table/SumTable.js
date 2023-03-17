function sumTable() {
    let products = document.querySelectorAll('tbody tr td');
    let sum = 0;

    for (let i = 1; i < products.length - 1; i+=2) {
        let element = products[i].innerText;
        sum += Number(element);
    }

    let result = products[products.length - 1];
    result.innerText = sum; 
}