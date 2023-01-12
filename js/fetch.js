const apiUrl = 'https://localhost:44397/api/';

// test van Hassan

window.onload = function (){
    fetchJSON();
    postRequest();
}

/*
Fetch JSON
(1) The global fetch() method starts the process of fetching a resource from the network, returning a promise which
    is fulfilled once the response is available.
    docs: https://developer.mozilla.org/en-US/docs/Web/API/fetch
(2) Indien we meerdere asynchrone operaties na elkaar willen uitvoeren gaan we promises moeten chainen.
    Dit doen we door de .then()'s achter elkaar te plaatsen (chainen).
(3) Eens de promise die we terugkregen van de fetch() methode resolved (async operatie is voltooid) gaan we het resultaat
    daarvan doorgeven naar de validateResponse() functie.
(4) Indien de response 'ok' was geven we het resultaat van de fetch() functie door naar de readResponseAsJSON() functie.
    Indien de response niet 'ok' was zouden we in de catch() terechtkomen omdat we een error throwen in de validateResponse() functie.
(5) De JSON data is in de vorige functie omgezet naar een Javascript object. Nu kan je er dus mee gaan doen wat je wilt.
    In het voorbeeld hier wordt het object simpelweg in de console getoond.
(6) Indien in één van de vorige promise chains een error wordt gegooid (thrown) komt die error terecht in de catch block.
*/
function fetchJSON() {
    fetch(apiUrl + 'Students') // (1) (2)
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logResult) // (5)
        .catch(logError); // (6)
}

// Helper functions
/*
(1) Controleer of de response positief is. docs: https://developer.mozilla.org/en-US/docs/Web/API/Response/ok
(2) Als de response niet ok is gooien we een error message.
    docs: https://developer.mozilla.org/en-US/docs/Web/API/Response/statusText
*/
function validateResponse(response) {
 console.log(response)
    if (!response.ok) { // (1)
        throw Error(response.statusText); // (2)
    }
    return response;
}

/*
(1) The json() method of the Response interface takes a Response stream and reads it to completion.
    ! It returns a promise ! which resolves with the result of parsing the body text as JSON.
    Note that despite the method being named json(), the result is not JSON but is instead the result of taking JSON
    as input and parsing it to produce a JavaScript object.
    docs: https://developer.mozilla.org/en-US/docs/Web/API/Response/json
*/
function readResponseAsJSON(response) {
    return response.json(); // (1)
}

function logResult(result) {
   // bericht "je bent ingelogd"
}

function logError(error) {
    console.log('Looks like there was a problem:', error);
}

/* POST JSON
NOTE: Never send unencrypted user credentials in production!
Extra info: https://developer.mozilla.org/en-US/docs/Web/API/fetch
(1) Request header info: https://developer.mozilla.org/en-US/docs/Glossary/Request_header
*/
// test van Hassan
const voornaam = document.querySelector('#voornaam').value;
const achternaam = document.querySelector('#achternaam').value;
const email_adres = document.querySelector('#email').value;
const wachtwoord = document.querySelector('#wachtwoord').value;

function postRequest() {
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    // test Hassan
    const clientInfo = {voornaam: voornaam, achternaam: achternaam, email: email_adres, wachtwoord: wachtwoord}


   // const query = "INSERT INTO client_info(client_id, voor_naam, achter_naam, user_wachtwoord, emailadres) VALUES(voornaam + ',' + achternaam + ',' +wachtwoord + ',' + email_adres)"
    fetch(apiUrl + 'client_info', {
        method: 'POST',
        body: JSON.stringify(clientInfo),
        headers: messageHeaders
    })
        .then(validateResponse)
        .then(readResponseAsText)
        .then(logResult)
        .catch(logError);
}

/*
(1) The text() method of the Response interface takes a Response stream and reads it to completion.
! It returns a promise ! that resolves with a String.
 docs: https://developer.mozilla.org/en-US/docs/Web/API/Response/text
 */
    function readResponseAsText(response) {
        return response.text(); // (1)
    }

