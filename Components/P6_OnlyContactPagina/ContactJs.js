const apiUrl = 'https://localhost:44397/api/ContactPageByMail';
let Verzendbtn = document.getElementById("submit");
Verzendbtn.addEventListener('click' , GegevensVerzamelen )
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
function GegevensVerzamelen(){
    let sender_voornaam = document.getElementById('klantFirstNameFromContactPage').value;
    let sender_achternaam = document.getElementById('klantSurNameFromContactPage').value;
    let sender_email = document.getElementById('klantEmailFromContactPage').value;
    let sender_gsm = document.getElementById('klantPhoneFromContactPage').value;
    let sender_klantNR = document.getElementById('klantKlantNmrFromContactPage').value;
    let sender_bericht = document.getElementById('klantOrderNmrFromContactPage').value;



    let ingevuldegegevens = {
        sender_voornaam : sender_voornaam,
        sender_achternaam : sender_achternaam,
        sender_email : sender_email,
        sender_gsm : sender_gsm,
        sender_klantNr : sender_klantNR,
        sender_bericht : sender_bericht,
    }
    let ingevuldegegevens_string = JSON.stringify(ingevuldegegevens)
    verstuur(ingevuldegegevens_string)
}
function verstuur(ingevuldegegevens_string) {
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    fetch(apiUrl, {
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: ingevuldegegevens_string

    })
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logResult) // (5)
        .catch(logError); // (6)
}


