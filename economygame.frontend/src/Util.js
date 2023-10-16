export const httpPost = (endpoint, urlSearchParams, body) => {
    const parmsString = (typeof (urlSearchParams) != 'undefined' && urlSearchParams !== null) ? '?' + urlSearchParams.toString() : '';
    return fetch(endpoint + parmsString), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: body
    }
}