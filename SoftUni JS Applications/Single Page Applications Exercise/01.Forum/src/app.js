import { getPosts } from "./getPosts.js";
import { postContent } from "./postContent.js";

const home = document.querySelector('nav ul li a').href = '././index.html';
const form = document.querySelector('form');

const clear = form.querySelectorAll('button')[0];
clear.addEventListener('click', (e) => {
    e.preventDefault();
    form.reset();
})

const post = form.querySelectorAll('button')[1];
post.addEventListener('click', () => {
    postContent();
});

getPosts();