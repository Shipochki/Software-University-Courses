function colorize() {
    let texts = document.querySelectorAll('table tr');

    for (let i = 1; i < texts.length; i++) {
        if (i % 2 === 1) {
            texts[i].style.background = 'teal';
        }

    }
}