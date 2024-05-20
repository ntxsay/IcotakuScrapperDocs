window.addEventListener('DOMContentLoaded', (event) => {
    // Load any languages you need
    hljs.highlightAll();
});

document.getElementById('toggle-theme-btn').addEventListener('click', function () {
    const body = document.body;
    body.classList.toggle('dark-theme');
    localStorage.setItem('theme', body.classList.contains('dark-theme') ? 'dark' : 'light');
});