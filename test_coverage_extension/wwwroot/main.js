function postMessage(message, data) {
    window.chrome.webview.postMessage({ message, data });
}

// Register message handler.
window.chrome.webview.addEventListener("message", handleMessage);
// Indicate that you are ready to receive messages.
postMessage("MessageListenerRegistered");

async function handleMessage(event) {
    const { message, data } = event.data;
    if (message === "RefreshModules") {
        await refreshMktplcModules();
    }
}

async function refreshMktplcModules() {
    let mktplcmodulesResponse = await fetch("./mktplcmodules");
    let mktplcmodules = await mktplcmodulesResponse.json();


    let marketplaceList = document.getElementById("marketplaceList");
    marketplaceList.className = "ga-marketplace-list";

    let marketplaceItemUnorderedList = document.getElementById("marketplaceItems");

    let moduleItems = [];


    for (const mktplcmodule of mktplcmodules.ModuleList) {
       
        let listItem = document.createElement("li");
        // Create a span element and set its text content
        let span = document.createElement("span");
        span.innerText = mktplcmodule.Name + "  |  " + mktplcmodule.AppStoreVersion;

        // Create an anchor (link) element
        // TODO: look at how to make this link open the marketplace item in studio pro
        let link = document.createElement("a");
        link.href = "https://marketplace.mendix.com/link/component/" + mktplcmodule.AppStoreVersion; // Assuming `todo.Link` contains the URL
        link.innerText = "show"; // Set the text for the link

        // Append the span and the link to the listItem
        listItem.appendChild(span);
       // listItem.appendChild(document.createTextNode(" ")); // Add a space between span and link
        //listItem.appendChild(link);

       moduleItems.push(listItem);

    
    }
    marketplaceItemUnorderedList.replaceChildren(...moduleItems);
    
}



async function showDevToolsNow()
{
    postMessage("ShowDevToolsNow");
  
}

document.getElementById("reloadMarketplaceModulesBtn").addEventListener("click", () =>
{
    postMessage("ReloadModules");
});

await refreshMktplcModules();
