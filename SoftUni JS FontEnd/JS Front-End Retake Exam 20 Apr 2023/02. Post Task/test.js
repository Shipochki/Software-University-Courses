document.body.innerHTML =`
 <div id="main-container">
      <div id="left-container">

        <div id="newPost" class="container">

          <form class="newPostContent">
            <h1>Add New Task</h1>
            <input type="text" placeholder="Enter title here" id="task-title" />

            <input type="text" placeholder="Enter category here" id="task-category" />

            <textarea placeholder="Add content..." id="task-content"></textarea>

            <button type="button" id="publish-btn">Publish</button>
          </form>
        </div>
      </div>

      <div id="middle-container">

        <div id="relatedPosts" class="container">

          <div class="bar title-bar">
            <h2>Task for review:</h2>
          </div>


          <ul id="review-list">

          </ul>

        </div>
        <div id="published-container">
          <div class="container">
            <div class="bar title-bar">
              <h2>Uploaded Task:</h2>
            </div>

            <ul id="published-list">

            </ul>
          </div>
        </div>
        <script src="./app.js"></script>
`
result();
const createPost = {
        title: () => document.getElementById("task-title"),
        category: () => document.getElementById("task-category"),
        content: () => document.getElementById("task-content"),
        addBtn: () => document.getElementById("publish-btn")
    }

  createPost.title().value = "Exam completion"
  createPost.category().value = "Exam"
  createPost.content().value = "On the 06.04.2022 there will be exam that includes this problem"

  createPost.addBtn().click();
  expect((document.querySelector(".rpost>article>h4")).textContent).to.equal('Exam completion', 'Post title is invalid.');
  expect((document.querySelectorAll(".rpost>article>p"))[0].textContent).to.equal('Category: Exam', 'Post category is invalid.');
  expect((document.querySelectorAll(".rpost>article>p"))[1].textContent).to.equal('Content: On the 06.04.2022 there will be exam that includes this problem', 'Post content is invalid');

