const apiUrl = 'https://localhost:44397/api/DoneerMail';
let Verzendbtn = document.getElementById("submit");
Verzendbtn.addEventListener('click' , verstuur )
function validateResponse(response) {
    console.log(response)
    if (!response.ok) {
        console.log(' a problem:');
        throw Error(response.statusText); // (2)
    }
    else{
        console.log('succes')
        return response;
    }
}
function readResponseAsJSON(response) {
    return response.json(); // (1)
}
function logError(error) {
    console.log('Looks like there was a problem:', error);
}
function getEmail(){
    let mail = document.getElementById('DBT-email').value
    return  JSON.stringify({sender_email: mail})



}


function verstuur() {
    let mailDoneerder = getEmail()
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    fetch(apiUrl, {
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: mailDoneerder

    })
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logResult) // (5)
        .catch(logError); // (6)
}
