function notify(message) {
  let notif = document.getElementById('notification');

  if (notif.style.display === 'block') {
    notif.style.display = 'none';
    return;
  }

  notif.addEventListener('click', () => {
    notif.style.display = 'none';
  })
  
  notif.textContent = message;
  notif.style.display = 'block';
}