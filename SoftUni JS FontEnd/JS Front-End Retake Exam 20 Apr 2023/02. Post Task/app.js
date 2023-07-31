window.addEventListener("load", solve);

function solve() {
  let button = document.getElementById('publish-btn');
  button.addEventListener('click', (e) => {
    e.preventDefault();

    const title = document.getElementById('task-title');
    const category = document.getElementById('task-category');
    const content = document.getElementById('task-content');

    if(title.value == '' || category.value == '' || content.value == ''){
      return;
    }

    let reviewList = document.getElementById('review-list');

    let li = document.createElement('li');
    li.className = 'rpost';

    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = title.value;
    let p1 = document.createElement('p');
    p1.textContent = `Category: ${category.value}`;
    let p2 = document.createElement('p');
    p2.textContent = `Content: ${content.value}`;

    article.appendChild(h4);
    article.appendChild(p1);
    article.appendChild(p2);
    li.appendChild(article);

    let buttonEdit = document.createElement('button');
    buttonEdit.classList = 'action-btn edit';
    buttonEdit.textContent = 'Edit';
    buttonEdit.addEventListener('click', (e) => {
      const target = e.target.parentNode;

      let targetH4 = target.querySelector('h4');
      title.value = targetH4.textContent;

      let targetP1 = target.querySelectorAll('p')[0];
      category.value = targetP1.textContent.replace('Category: ', '');
      
      let targetP2 = target.querySelectorAll('p')[1];
      content.value = targetP2.textContent.replace('Content: ', '');

      target.remove(e.target);
    })
    let buttonPost = document.createElement('button');
    buttonPost.classList = 'action-btn post';
    buttonPost.textContent = 'Post';
    buttonPost.addEventListener('click', (e) => {
      const target = e.target.parentNode;

      reviewList.removeChild(target);

      target.removeChild(buttonEdit);
      target.removeChild(buttonPost)

      const publishedList = document.getElementById('published-list');

      publishedList.appendChild(target);
    })

    li.appendChild(buttonEdit);
    li.appendChild(buttonPost);

    reviewList.appendChild(li);

    title.value = '';
    category.value = '';
    content.value = '';
  })
}
