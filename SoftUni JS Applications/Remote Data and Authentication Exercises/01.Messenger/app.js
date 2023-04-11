function attachEvents() {
    const send = document.getElementById('submit');
    send.addEventListener('click', addMessage)
    const get = document.getElementById('refresh');
    get.addEventListener('click', getMessages)
}

async function addMessage() {
    const url = `http://localhost:3030/jsonstore/messenger`;
    const name = document.getElementsByName('author')[0].value;
    const message = document.getElementsByName('content')[0].value;

    const obj = {
        author: name,
        content: message,
    }
    await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(obj),
    });

    getMessages();
}

async function getMessages() {
    const url = `http://localhost:3030/jsonstore/messenger`;
    const textarea = document.getElementById('messages');
    textarea.textContent = '';
    await fetch(url)
        .then(response => {
            if (response.ok == false) {
                throw new Error
            }

            return response.json();
        })
        .then(data => {

            Object.entries(data).forEach(([key, value]) => {
                const name = value.author;
                const message = value.content;

                textarea.textContent += `${name}: ${message} \n`
            });
        })
}

attachEvents();