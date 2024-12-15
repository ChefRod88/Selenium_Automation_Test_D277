document.getElementById('submit').addEventListener('click', function (e) {
    const email = document.getElementById('email').value;
    const confirmEmail = document.getElementById('confirm-email').value;
    if (email !== confirmEmail) {
        e.preventDefault();
        alert('Email addresses do not match!');
    }
});
