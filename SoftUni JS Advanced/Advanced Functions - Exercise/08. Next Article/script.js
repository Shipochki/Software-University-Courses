function getArticleGenerator(articles) {
    let content = document.getElementById('content');

    return function showNext() {
        if (!articles.length) {
            return
        }

        let article = articles.shift();
        let element = document.createElement('article');
        element.textContent = article;
        content.appendChild(element);
    }
}
