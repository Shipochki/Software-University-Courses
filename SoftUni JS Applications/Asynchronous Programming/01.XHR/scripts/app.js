let httpRequest = null;

function loadRepos() {
    let url = 'https://api.github.com/users/testnakov/repos';

    httpRequest = new XMLHttpRequest();

    httpRequest.addEventListener('readystatechange', display);
    httpRequest.open('GET', url);
    httpRequest.send();
}

function display() {
    if (httpRequest.readyState == 4 && httpRequest.status == 200) {
        let res = document.getElementById('res').textContent = httpRequest.responseText;
    }
}