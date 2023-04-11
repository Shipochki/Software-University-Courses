function attachEvents() {
    const load = document.getElementById('btnLoad');
    load.addEventListener('click', loadPhones)
    const create = document.getElementById('btnCreate');
    create.addEventListener('click', createContact);
}

async function loadPhones(){
    const url = 'http://localhost:3030/jsonstore/phonebook';

    fetch(url)
    .then(response => {
        if(response.ok == false){
            throw new Error
        }

        return response.json();
    })
    .then(data => {
        const ul = document.getElementById('phonebook');
        ul.innerHTML = '';
        Object.entries(data).forEach(([key, value]) => {
            const li = document.createElement('li');
            const button = document.createElement('button');
            button.addEventListener('click', deletePhone);
            button.textContent = 'Delete';
            button.id = value._id;
            li.textContent = `${value.person}: ${value.phone}`
            li.appendChild(button);
            ul.appendChild(li);
        })
    })
    .catch(error => {
        console.log(error);
    })
}

async function createContact(){
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const name = document.getElementById('person').value;
    const phone = document.getElementById('phone').value;

    const data = {
        person: name,
        phone: phone
    }

    fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(data)
    });
}

async function deletePhone(){
    const id = event.target.id;
    const url = `http://localhost:3030/jsonstore/phonebook/${id}`;

    fetch(url, {
        method: 'delete',
    });
}

attachEvents();