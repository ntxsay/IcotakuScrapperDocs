const scrapAnimeFromUrlBtn = document.querySelector('#scrap_anime_from_url_playground .run-playground-btn');

/**
 * Retourne les informations d'un anime à partir de son URL
 */
scrapAnimeFromUrlBtn.addEventListener('click', async () => {
    const resultContainer = document.querySelector('#scrap_anime_from_url_playground .playground-results');
    

    const runningAlert = document.querySelector('#scrap_anime_from_url_playground .alert-container');
    if (runningAlert && runningAlert.classList.contains('hidden'))
        runningAlert.classList.remove('hidden');

    try {
        
        const url = document.querySelector('#scrap_anime_from_url_playground input[type=url]').value;
        const response = await fetch(`/ScrapSheetByUrl?url=${url}`);
        const data = await response.json();
        console.log(data);

        resultContainer.innerHTML = '';
        
        const ul = document.createElement('ul');
        ul.classList.add('list-group');
        
        for (const key in data) {
            const li = document.createElement('li');
            li.classList.add('list-group-item');
            li.innerHTML = `<strong>${key}</strong>: ${data[key]}`;
            ul.appendChild(li);
        }
        
        resultContainer.appendChild(ul);
        
    } catch (error) {
        console.error(error);
    }
});