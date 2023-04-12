import { getPosts } from "./getPosts.js";
import { postContent } from "./postContent.js";

const form = document.querySelector('form');

const clear = form.querySelectorAll('button')[0];
clear.addEventListener('click', () => clearInputs)

const post = form.querySelectorAll('button')[1];
post.addEventListener('click', () => { 
        postContent();
    });

getPosts();