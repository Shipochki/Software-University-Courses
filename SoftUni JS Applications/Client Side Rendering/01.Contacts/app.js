import { contacts } from "./contacts.js";

const main = document.getElementById('contacts');

contacts.forEach(contact => {
    main.innerHTML += ` 
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${contact.name}</h2>
            <button class="detailsBtn">Details</button>
            <div class="details" id="${contact.id}">
                <p>Phone number: ${contact.phoneNumber}</p>
                <p>Email: ${contact.email}m</p>
            </div>
        </div>
    </div>
    `
})

const buttons = document.querySelectorAll('button');
buttons.forEach(last => {
    last.addEventListener('click', (e) => {
    const parent = e.target.parentNode;
    const div = parent.querySelector('div');
    if (div.style.display == 'block') {
        div.style.display = 'none';
    } else {
        div.style.display = 'block';

    }
});
})

