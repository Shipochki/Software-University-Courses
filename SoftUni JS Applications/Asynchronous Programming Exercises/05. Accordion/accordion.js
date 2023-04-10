function solution() {
    const main = document.getElementById('main');

    async function loadPosts() {
        const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

        await fetch(url)
            .then(response => {
                if (response.ok == false) {
                    throw new Error;
                }

                return response.json();
            })
            .then(data => {

                Object.entries(data).forEach(([key, value]) => {
                    let mainDiv = document.createElement('div');
                    mainDiv.className = 'accordion';
                    let divHead = document.createElement('div');
                    divHead.className = 'head';
                    let span = document.createElement('span');
                    span.textContent = value.title;
                    let button = document.createElement('button');
                    button.id = value._id;
                    button.className = 'button';
                    button.textContent = 'MORE';
                    button.addEventListener('click', getMore)

                    divHead.appendChild(span);
                    divHead.appendChild(button);

                    let divExtra = document.createElement('div');
                    divExtra.className = 'extra';
                    let p = document.createElement('p');

                    divExtra.appendChild(p);

                    mainDiv.appendChild(divHead);
                    mainDiv.appendChild(divExtra);
                    main.appendChild(mainDiv);

                })
            })
            .catch(error => {
                console.log(error);
            })
    }

    loadPosts();

    async function getMore(){
        const element = event.target;
        const parrent = element.parentNode.parentNode;
        const p = parrent.querySelectorAll('div p')[0];

        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${element.id}`;
        await fetch(url)
        .then(response => {
            if(response.ok == false){
                throw new Error;
            }

            return response.json();
        })
        .then(data => {
            p.textContent = data.content;
        })
        .catch(error => {
            console.log(error);
        })

        if(parrent.querySelectorAll('div')[1].className == 'extra'){
            parrent.querySelectorAll('div')[1].className = '';
            element.textContent = 'LESS';
        }else{
            parrent.querySelectorAll('div')[1].className = 'extra';
            element.textContent = 'MORE';
        }
    }
}

