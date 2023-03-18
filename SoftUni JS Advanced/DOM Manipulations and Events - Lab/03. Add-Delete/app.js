function addItem() {
    let text = document.getElementById('newItemText').value;
    let ul = document.getElementById('items');

    if(text.length === 0) return;

    let li = document.createElement('li');
    li.textContent = text;

    let remove = document.createElement('a');
    let linkText = document.createTextNode('[Delete]')

    remove.appendChild(linkText);
    remove.href = '#';
    remove.addEventListener("click", deleteItem);

    li.appendChild(remove);
    ul.appendChild(li)

    function deleteItem(){
        li.remove();
    }
}