const darkHightlightCssRef = 'lib/highlight/styles/dark.css';
const lightHightlightCssRef = 'lib/highlight/styles/default.css';
window.loadAllHighlight = () => {
    hljs.highlightAll();
};

window.toggleTheme = () =>{
    const body = document.body;
    body.classList.toggle('dark-theme');
    const isDarkTheme = body.classList.contains('dark-theme');
    localStorage.setItem('theme', isDarkTheme ? 'dark' : 'light');

    const cssElement = document.getElementById('highlightThemeCss');
    cssElement.setAttribute("href", isDarkTheme
        ? darkHightlightCssRef
        : lightHightlightCssRef);
};