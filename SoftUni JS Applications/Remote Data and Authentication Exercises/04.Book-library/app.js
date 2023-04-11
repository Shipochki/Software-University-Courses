function init() {
    const load = document.getElementById('loadBooks');
    load.addEventListener('click', loadBooks);
    const form = document.querySelectorAll('form')[0];
    const h3 = form.querySelectorAll('h3')[0];
    h3.textContent = 'FORM';
    const create = form.querySelectorAll('button')[0];
    create.removeEventListener('click', editBook)
    create.addEventListener('click', createBook)
    create.textContent = 'Submit';
}

async function createBook() {
    url = 'http://localhost:3030/jsonstore/collections/books';

    const title = document.getElementsByName('title')[0].value;
    const author = document.getElementsByName('author')[0].value;

    const data = {
        title: title,
        author: author
    }

    await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(data)
    })
}

async function loadBooks() {
    url = 'http://localhost:3030/jsonstore/collections/books';

    await fetch(url)
        .then(response => {
            if (response.ok == false) {
                throw new Error;
            }

            return response.json();
        })
        .then(data => {
            const tbody = document.querySelectorAll('tbody')[0];
            tbody.innerHTML = '';

            Object.entries(data).forEach(([key, value]) => {
                const tr = document.createElement('tr');

                const title = document.createElement('td');
                title.textContent = `${value.title}`;

                const author = document.createElement('td');
                author.textContent = `${value.author}`;

                const buttons = document.createElement('td');
                const editBtn = document.createElement('button');
                editBtn.addEventListener('click', editBook);
                editBtn.textContent = 'Edit';
                editBtn.id = key;
                const deleteBtn = document.createElement('button');
                deleteBtn.addEventListener('click', deleteBook);
                deleteBtn.textContent = 'Delete';
                deleteBtn.id = key;

                buttons.appendChild(editBtn);
                buttons.appendChild(deleteBtn);

                tr.appendChild(title);
                tr.appendChild(author);
                tr.appendChild(buttons);

                tbody.appendChild(tr);
            })
        })
        .catch(error => {
            console.log(error);
        })
}

async function editBook() {
    const id = event.target.id;
    url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    const form = document.querySelectorAll('form')[0];
    const h3 = form.querySelectorAll('h3')[0];
    h3.textContent = 'Edit FORM';
    const button = form.querySelectorAll('button')[0];
    button.removeEventListener('click', createBook);
    button.textContent = 'Save';

    const current = await getBook(url);

    document.getElementsByName('title')[0].value = current.title;
    document.getElementsByName('author')[0].value = current.author;

    button.addEventListener('click', () => {
        const title = document.getElementsByName('title')[0].value;
        const author = document.getElementsByName('author')[0].value;

        const data = {
            author: author,
            title: title,
        }

        fetch(url, {
            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data)
        });
    })
}

async function deleteBook() {
    const id = event.target.id;
    url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    fetch(url, {
        method: 'delete'
    })
}

async function getBook(url) {
    let result = {
        author: null,
        title: null,
    };
    await fetch(url)
        .then(response => {
            if (response.ok == false) {
                throw new Error;
            }
            return response.json();
        })
        .then(data => {
            Object.entries(data).forEach(([key, value]) => {
                result[key] = value;
            })
        })

    return result;
}


init();