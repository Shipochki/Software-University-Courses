const container = document.getElementsByClassName('topic-container')[0];
const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export function getPosts(){
    posts();
}

async function posts() {
    try {
        const responese = await fetch(url);

        if (responese.ok == false) {
            throw new Error('Error');
        }

        const data = await responese.json();

        Object.entries(data).forEach(([key, value]) => {
            const divWrapper = document.createElement('div');
            divWrapper.className = 'topic-name-wrapper';

            const divName = document.createElement('div');
            divName.className = 'topic-name';

            const a = document.createElement('a');
            a.href = '#';
            a.className = 'normal';
            const h2 = document.createElement('h2');
            h2.textContent = `${value.topicName}`;

            a.appendChild(h2);
            divName.appendChild(a);

            const divCoumns = document.createElement('div');
            divCoumns.className = 'columns';
            const div = document.createElement('div');
            const p = document.createElement('p');
            p.textContent = 'Date: ';
            const time = document.createElement('time');
            time.textContent = `${value.date}`;
            p.appendChild(time);
            div.appendChild(p);

            const div2 = document.createElement('div');
            div2.className = 'nick-name';
            const p2 = document.createElement('p');
            p2.textContent = 'Username: ';
            const span = document.createElement('span');
            span.textContent = `${value.username}`;
            p2.appendChild(span);
            div2.appendChild(p2);
            div.appendChild(div2);

            divCoumns.appendChild(div);

            divName.appendChild(divCoumns);

            divWrapper.appendChild(divName);

            container.appendChild(divWrapper);
        })
    } catch (error) {
        console.log(error)
    }
}