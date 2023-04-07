function attachEvents() {
    const btnLoad = document.getElementById('btnLoadPosts');
    const btnView = document.getElementById('btnViewPost');

    btnLoad.addEventListener('click', loadPosts);
    btnView.addEventListener('click', viewPosts);

    const posts = [];
    async function loadPosts(){
        const url = `http://localhost:3030/jsonstore/blog/posts`;

        fetch(url)
        .then(respones => {
            if(respones.ok == false){
                throw new Error();
            }

            return respones.json();
        })
        .then(data => {
            const currentPosts = document.getElementById('posts');
            currentPosts.innerHTML = '';

            Object.entries(data).forEach(([key, value]) => {
                const optionElement = document.createElement('option');
                optionElement.value = key;
                optionElement.textContent = value.title;
                currentPosts.appendChild(optionElement);
                posts.push({title: value.title, body: value.body});
            });
        })
        .catch(error => {
            console.log(error);
        })
    }

    async function viewPosts(){
        const url = `http://localhost:3030/jsonstore/blog/comments`;

        fetch(url)
        .then(respones => {
            if(respones.ok == false){
                throw new Error();
            }

            return respones.json();
        })
        .then(data => {
            const selectedElement = document.getElementById('posts');

            const comments = Object.values(data).filter(el => el.postId === selectedElement.value);
            
            const postTitle = document.getElementById('post-title');
            postTitle.textContent = selectedElement.selectedOptions[0].textContent;

            const po = posts.filter(p => p.title === selectedElement.selectedOptions[0].textContent);
            
            const postBody = document.getElementById('post-body');
            postBody.innerHTML = `${po[0].body}`;

            const postComments = document.getElementById('post-comments');
            postComments.innerHTML = '';

            comments.forEach(el => {
                const liElement = document.createElement('li');
                liElement.textContent = el.text;
                postComments.appendChild(liElement);
            })
        })
        .catch(error => {
            console.log(error);
        })
    }
}

attachEvents();