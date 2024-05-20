window.selectTabItem = (tabContainerId, tabId) => {
    const tabContainer = document.querySelector(tabContainerId);
    const allTabHeaderItem = Array.from(tabContainer.querySelectorAll('.tab-header >.tab-item'));
    const allTabContentItem = Array.from(tabContainer.querySelectorAll('.tab-content >.tab-item'));
    
    allTabHeaderItem.forEach((tabItem) => {
        if (tabItem.classList.contains('selected') && tabItem.getAttribute("data-tab-id") !== tabId.toString())
            tabItem.classList.remove('selected');
        else {
            if (!tabItem.classList.contains('selected') && tabItem.getAttribute("data-tab-id") === tabId.toString())
                tabItem.classList.add('selected');
        }
    });

    allTabContentItem.forEach((tabItem) => {
        if (tabItem.classList.contains('selected') && tabItem.getAttribute("data-tab-id") !== tabId.toString())
            tabItem.classList.remove('selected');
        else {
            if (!tabItem.classList.contains('selected') && tabItem.getAttribute("data-tab-id") === tabId.toString())
                tabItem.classList.add('selected');
        }
    });
}