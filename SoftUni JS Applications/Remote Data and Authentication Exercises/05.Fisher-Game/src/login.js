const loginForm = document.querySelector('form');
loginForm.addEventListener('submit', userLogin);
document.getElementById('user').style.display = 'none';

async function userLogin(e) {
    e.preventDeafult();
    const formData = new FormData(e.target);

    const email = formData.get('email');
    const password = formData.get('password');

    try {
        const url = 'http://localhost:3030/users/login'
        const res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email,
                password,
            }),
        });

        if(!res.ok){
            const error = await res.json();
            throw new Error(error.message);
        }

        const data = await res.json();
        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToke,
        };
        localStorage.setItem('userData', JSON.stringify(userData));
        window.location = ('./index.html');
    } catch (error) {
        document.querySelector('form').reset();
        alert(error.message);
    }
}