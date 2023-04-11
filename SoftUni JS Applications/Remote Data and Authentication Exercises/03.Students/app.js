function init(){
    loadStudents();

    const submit = document.getElementById('submit');
    submit.addEventListener('click', createStudent)
}

async function loadStudents(){
    url = 'http://localhost:3030/jsonstore/collections/students';

    await fetch(url)
    .then(response => {
        if(response.ok == false){
            throw new Error;
        }

        return response.json();
    })
    .then(data => {
        const table = document.getElementById('results');
        const tbody = table.querySelectorAll('tbody')[0];

        Object.entries(data).forEach(([key, value]) => {
            const tr = document.createElement('tr');
            const firstName = document.createElement('td');
            firstName.textContent = `${value.firstName}`;
            const lastName = document.createElement('td');
            lastName.textContent = `${value.lastName}`;
            const facultyNumber = document.createElement('td');
            facultyNumber.textContent = `${value.facultyNumber}`;
            const grade = document.createElement('td');
            grade.textContent = `${value.grade}`;

            tr.appendChild(firstName);
            tr.appendChild(lastName);
            tr.appendChild(facultyNumber);
            tr.appendChild(grade);
            tbody.appendChild(tr);
        })
    })
    .catch(error => {
        console.log(error);
    })
}

async function createStudent(){
    url = 'http://localhost:3030/jsonstore/collections/students';
    const firstName = document.getElementsByName('firstName')[0].value;
    const lastName = document.getElementsByName('lastName')[0].value;
    const facultyNumber = document.getElementsByName('facultyNumber')[0].value;
    const grade = document.getElementsByName('grade')[0].value;

    const data = {
        firstName: firstName,
        lastName: lastName,
        facultyNumber: facultyNumber,
        grade: grade
    }

    await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(data)
    })

    loadStudents();
}

init();