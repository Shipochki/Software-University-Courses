const form = document.getElementById("form");
form.addEventListener("submit", async (e) => {
  e.preventDefault();

  let method = "POST";
  let url = 'http://localhost:3030/jsonstore/tasks';
  if (e.target.id != "") {
    url += `/${e.target.id}`
    method = "PUT";
  }

  const element = document;

  let title = element.getElementById("course-name");
  let type = element.getElementById("course-type");
  let description = element.getElementById("description");
  let teacher = element.getElementById("teacher-name");

  if (
    title.value == "" ||
    type.value == "" ||
    description.value == "" ||
    teacher.value == ""
  )
    return;

  if (type.value != "Long" && type.value != "Medium" && type.value != "Short")
    return;

  let obj = {
    title: title.value,
    type: type.value,
    description: description.value,
    teacher: teacher.value,
    _id: e.target.id
  };

  const response = await fetch(url, {
    method: method, // GET, POST, PUT, DELETE, etc.
    mode: "cors",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(obj),
  });

  title.value = "";
  type.value = "";
  description.value = "";
  teacher.value = "";

  element.getElementById("add-course").removeAttribute("disabled");
  element.getElementById("edit-course").setAttribute("disabled", "");
  element.querySelector("form").removeAttribute("id");
  
  loadButton.click();
});

const loadButton = document.getElementById("load-course");
loadButton.addEventListener("click", async () => {
  const responese = await fetch(`http://localhost:3030/jsonstore/tasks`);
  const data = await responese.json();

  const list = document.getElementById("list");
  list.innerHTML = "";

  const dataList = Object.keys(data);

  for (let i = 0; i < dataList.length; i++) {
    const element = data[dataList[i]];

    let div = document.createElement("div");
    div.className = "container";
    div.id = element["_id"];

    let h2 = document.createElement("h2");
    h2.textContent = element["title"];

    let h3Teacher = document.createElement("h3");
    h3Teacher.textContent = element["teacher"];

    let h3Type = document.createElement("h3");
    h3Type.textContent = element["type"];

    let h4 = document.createElement("h4");
    h4.textContent = element["description"];

    let buttonEdit = document.createElement("button");
    buttonEdit.textContent = "Edit Course";
    buttonEdit.className = "edit-btn";
    buttonEdit.addEventListener("click", (e) => {
      const currentElement = e.target.parentNode;
      const h2 = currentElement.querySelector("h2").textContent;
      const h3_1 = currentElement.querySelectorAll("h3")[0].textContent;
      const h3_2 = currentElement.querySelectorAll("h3")[1].textContent;
      const h4 = currentElement.querySelector("h4").textContent;
      const element = document;

      element.getElementById("course-name").value = h2;
      element.getElementById("course-type").value = h3_2;
      element.getElementById("description").value = h4;
      element.getElementById("teacher-name").value = h3_1;
      element.getElementById("add-course").setAttribute("disabled", "");
      element.getElementById("edit-course").removeAttribute("disabled");
      element.querySelector("form").setAttribute("id", currentElement.id);

      currentElement.remove();
    });

    let buttonFinish = document.createElement("button");
    buttonFinish.textContent = "Finish Course";
    buttonFinish.className = "finish-btn";
    buttonFinish.addEventListener('click', async (e) => {
        const response = await fetch(`http://localhost:3030/jsonstore/tasks/${e.target.parentNode.id}`, {
            method: `DELETE`, // GET, POST, PUT, DELETE, etc.
            mode: "cors",
            headers: {
              "Content-Type": "application/json",
            },
          });
          loadButton.click();
    })

    div.appendChild(h2);
    div.appendChild(h3Teacher);
    div.appendChild(h3Type);
    div.appendChild(h4);
    div.appendChild(buttonEdit);
    div.appendChild(buttonFinish);

    list.appendChild(div);
  }
});