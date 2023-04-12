import { getPosts } from "./getPosts.js";

const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
const form = document.querySelector('form');

export function postContent(){
    create();
}

async function create() {
    const formData = new FormData(form);
    const date = new Date();
    const { topicName, username, postText } = Object.fromEntries(formData.entries());

    try {
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ topicName, username, postText, date })
        });

        if (response.ok == false) {
            const error = response.json();
            throw error;
        }

        form.reset();

        getPosts();
    } catch (error) {
        console.log(error);
    }
}