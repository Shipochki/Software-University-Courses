function deleteByEmail() {
    let email = document.getElementsByName('email')[0].value;
    let people = document.querySelectorAll('tbody tr');
    let finded;
    let isFinded = false;
    for (let i = 0; i < people.length; i++) {
        let person = people[i];
        if (person.children[1].textContent === email) {
            finded = person;
            isFinded = true;
            break;
        }
    }

    let result = document.getElementById('result');

    if (isFinded) {
        finded.parentNode.removeChild(finded);
        isFinded = false;        
        result.textContent = 'Deleted.';
    }
    else {
        result.textContent = 'Not found.';

    }
}