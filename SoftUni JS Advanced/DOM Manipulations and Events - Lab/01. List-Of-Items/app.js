function addItem() {
    let text = document.getElementById('newItemText').value;
    let ul = document.getElementById('items');
    let li = document.createElement('li');
    li.textContent = text;
    ul.appendChild(li);
}