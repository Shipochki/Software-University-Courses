const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
const container = document.getElementsByClassName('container')[0];

export function allComment(e) {
    e.preventDefault()
    const id = e.target.parentNode.id;
    comments(id);
}

async function comments(id) {
    try {
        const responese = await fetch(url);

        if (responese.ok == false) {
            throw new Error('Error');
        }

        const data = await responese.json();

        const post = data[id];
        if(post != undefined){
            document.querySelector('main').style.display = 'none';
            const divContent = document.createElement('div');
            divContent.className = 'theme-content';
            const divTheme = document.createElement('div');
            divTheme.className = 'theme-title';
            const divWrapper = document.createElement('div');
            divWrapper.className = 'theme-name-wrapper';
            const divName = document.createElement('div');
            divName.className = 'theme-name';
            const h2 = document.createElement('h2');
            h2.textContent = `${post.topicName}`;

            divName.appendChild(h2);
            divWrapper.appendChild(divName);
            divTheme.appendChild(divWrapper);
            divContent.appendChild(divTheme);
            container.appendChild(divContent);

            const divComents = document.createElement('div');
            divComents.className = 'comment';
            const divHeader = document.createElement('div');
            divHeader.className = 'header';
            const img = document.createElement('img');
            img.src = './static/profile.png';
            img.alt = 'avatar';
            divHeader.appendChild(img);            
            
            const p = document.createElement('p');
            const span = document.createElement('span');
            span.textContent = `${post.username}`;
            p.appendChild(span);
            p.textContent += ' posted on ';
            const time = document.createElement('time');
            time.textContent = `${post.date}`;
            p.appendChild(time);
            divHeader.appendChild(p);

            const pContent = document.createElement('p');
            pContent.className = 'post-content';
            pContent.textContent = `${post.postText}`
            divHeader.appendChild(pContent);

            divComents.appendChild(divHeader);
            container.appendChild(divComents);
        }
    } catch (error) {
        console.log(error)
    }
}