function lockedProfile() {
    let main = document.getElementById('main');

    let url = 'http://localhost:3030/jsonstore/advanced/profiles';
    fetch(url)
        .then(response => {
            if (response.ok == false) {
                throw new Error;
            }

            return response.json();
        })
        .then(data => {
            let count = 1;
            Object.entries(data).forEach(([key, value]) => {

                if (count === 1) {
                    document.getElementsByName('user1Username')[0].value = `${value.username}`;
                    document.getElementsByName('user1Email')[0].value = `${value.email}`;
                    document.getElementsByClassName('user1Username')[0].classList.add('hiddenInfo')
                    document.getElementsByClassName('user1Username')[0].classList.add('user1Username');
                    document.getElementsByTagName('button')[0].addEventListener('click', showMore);
                    document.getElementsByTagName('button')[0].name = `user1Username`;
                    document.getElementsByName('user1Age')[0].value = `${value.age}`;
                }
                else {
                    let mainDiv = document.createElement('div');
                    mainDiv.className = 'profile';
                    let img = document.createElement('img');
                    img.src = './iconProfile2.png';
                    img.className = 'userIcon';
                    let firstLabel = document.createElement('label');
                    firstLabel.textContent = 'Lock';
                    let firstInput = document.createElement('input');
                    firstInput.type = 'radio';
                    firstInput.name = `user${count}Locked`;
                    firstInput.value = 'lock';
                    firstInput.checked;
                    let secondLable = document.createElement('label');
                    secondLable.textContent = 'Unlock';
                    let secondInput = document.createElement('input');
                    secondInput.type = 'radio';
                    secondInput.name = `user${count}Locked`;
                    secondInput.value = 'unlock';
                    let br = document.createElement('br');
                    let hr = document.createElement('hr');
                    let thirdLable = document.createElement('label');
                    thirdLable.textContent = 'Username';
                    let thirdInput = document.createElement('input');
                    thirdInput.type = 'text';
                    thirdInput.name = `user${count}Username`;
                    thirdInput.value = `${value.username}`;
                    thirdInput.disabled = 'true';
                    thirdInput.readOnly = 'true';

                    let inDiv = document.createElement('div');
                    inDiv.classList.add(`user${count}Username`);                    
                    inDiv.classList.add(`hiddenInfo`);
                    let forthLable = document.createElement('label');
                    forthLable.textContent = 'Email:';
                    let forthInput = document.createElement('input');
                    forthInput.type = 'email';
                    forthInput.name = `user${count}Email`;
                    forthInput.value = `${value.email}`;
                    forthInput.disabled = 'true';
                    forthInput.readOnly = 'true';
                    let fiveLable = document.createElement('label');
                    fiveLable.textContent = 'Age:';
                    let fiveInput = document.createElement('input');
                    fiveInput.type = 'number';
                    fiveInput.name = `user${count}Age`;
                    fiveInput.value = `${value.age}`;
                    fiveInput.disabled = 'email';
                    fiveInput.readOnly = 'true';

                    inDiv.appendChild(hr);
                    inDiv.appendChild(forthLable);
                    inDiv.appendChild(forthInput);
                    inDiv.appendChild(fiveLable);
                    inDiv.appendChild(fiveInput);

                    let button = document.createElement('button');
                    button.textContent = 'Show more';
                    button.name = `user${count}Username`;
                    button.addEventListener('click', showMore)

                    mainDiv.appendChild(img);
                    mainDiv.appendChild(firstLabel);
                    mainDiv.appendChild(firstInput);
                    mainDiv.appendChild(secondLable);
                    mainDiv.appendChild(secondInput);
                    mainDiv.appendChild(br);
                    mainDiv.appendChild(hr);
                    mainDiv.appendChild(thirdLable);
                    mainDiv.appendChild(thirdInput);
                    mainDiv.appendChild(inDiv);
                    mainDiv.appendChild(button);

                    main.appendChild(mainDiv);
                }
                count++;

                function showMore(){
                    let element = event.target;
                    let parentClass = element.parentNode.querySelectorAll('div')[0].classList[0];
                    let currentdiv = element.parentNode.querySelectorAll('div')[0];
                    let isUnlocked = element.parentNode.querySelectorAll('input')[1].checked;
                    if(element.name == parentClass){
                        if(isUnlocked && element.textContent !== 'Hide it'){
                            currentdiv.classList.remove('hiddenInfo');
                            element.textContent = 'Hide it';
                        }else if(isUnlocked && element.textContent == 'Hide it'){
                            element.textContent = 'Show more';
                            currentdiv.classList.add('hiddenInfo');
                        }
                    }
                }
            })
        })
}