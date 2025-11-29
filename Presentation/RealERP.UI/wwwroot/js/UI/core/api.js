export async function apiRequest(url, method = "GET", body = null) {
    const options = {
        method: method,
        headers: {  
            "Content-Type": "application/json"
        }
    };

    if (body != null) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(url, options);

    if (!response.ok) {
        throw new Error(`API request failed with status ${response.status}`);
    }
    let data = await response.json();
   

    return data;
}
