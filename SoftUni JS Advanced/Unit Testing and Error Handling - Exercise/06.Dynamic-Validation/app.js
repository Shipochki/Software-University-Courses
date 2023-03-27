function validate() {
    let email = document.getElementById('email');
    
    email.addEventListener('blur', function(e) {
        if(!e.target.value.includes('@') && e.target.value != '')
        {
            e.target.classList.add('error');
        }
        else
        {
            e.target.classList.remove('error');
        }
    })
}