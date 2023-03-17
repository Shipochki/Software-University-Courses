function extractText() {
    let texts = document.querySelectorAll('ul li');
    let result = document.getElementById('result');
    debugger;
    let outputText = '';
    for (let i = 0; i < texts.length; i++) {
        let element = texts[i];
        outputText += `${element.textContent}\n`
    }

    result.textContent = outputText;
}