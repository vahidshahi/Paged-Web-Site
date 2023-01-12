/* deze Fetch (Bankkaart) gaat naar de    ----- Niet in gebruik   */

/* deze Fetch (Bestelling) gaat naar de BestellingController
 *  --- maakt de bestelling aan an stuurd de bestelNr terug  */

/* deze Fetch (BestelItems)  gaat naar de BestelItemsController slaat de boeken op geet niks terug*/

/* deze Fetch (MailSturen)   gaat naar de ResBevestiging  en stuurt een mail naar de klant */

const apiUrl = 'https://localhost:44397/api/';
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}

let insertBoek;
let isJuist = false
let btnCheckout = document.querySelector('#btnProceedCheckout');
btnCheckout.addEventListener("click", KaartGegevens)
function KaartGegevens()
{
    BestellingPlaatsen()

    let btnJa = document.getElementById('radioBtnJa');
    let btnNee = document.getElementById('radioBtnNee');
    let klantId = JSON.parse(localStorage.getItem('klant'));
    let kaartHouder = document.getElementById('inputNaamOpKaart').value;
    let vervalMaand = document.getElementById('inputVervalMaand').value;
    let creditKaartNummer = parseInt(document.getElementById('inputKaartNummer').value);
    let vervalJaar = document.getElementById('inputVervalJaar').value;

    if(btnJa.checked)
    {
        const messageHeaders = new Headers({ // (1)
            'Content-Type': 'application/json'
        });
        let bankKaart = {
            klantId : klantId.KlantId,
            kaartHouderNaam : kaartHouder,
            vervalMaand : vervalMaand,
            creditKaartNr : creditKaartNummer,
            vervalJaar : parseInt(vervalJaar)
        }
        fetch(apiUrl + 'BankKaart', {
            method: 'POST',
            headers: messageHeaders,
            body: JSON.stringify(bankKaart),
        })
            .then(function validateResponse(response) {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response;
            }).then(response => {
            console.log(response);
            return response.text();
        })
            .then(data => {
                console.log('Success:', data);
                BestellingPlaatsen()

            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
    else if(btnNee.checked)
    {
        BestellingPlaatsen()
    }

}
function BestellingPlaatsen()
{

    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    let klantItem = JSON.parse(localStorage.getItem('klant'));
    let klantId;
    klantId = parseInt(klantItem.KlantId);
    let klantInfo = {
        klantId : klantId
    }
    fetch(apiUrl + 'Bestelling', {
        method: 'POST',
        headers: messageHeaders,
        body: JSON.stringify(klantInfo)

    })
        .then(function validateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(function readResponseAsText(response){
            return response.text();
        })
        .then(function logResult(BestellingNr){
            localStorage.setItem('BestellingNr', BestellingNr);
            ItemsOpslaan();
        })
        .catch(function logError(error){
            console.log(error);
        });

}
function ItemsOpslaan() {
    let boekenArray = JSON.parse(localStorage.getItem('boekenInWinkelWagen'));
    let bestellingNr = JSON.parse(localStorage.getItem('BestellingNr'));
    insertBoek = boekenArray[0]
    console.log(boekenArray[0])


    let date = new Date()
    let jaar = date.getFullYear();
    let maand = date.getMonth();
    let dag = date.getDate();
    console.log(date)
    console.log(jaar)
    console.log(maand)
    console.log(dag)
    let dateVandaag = jaar + "-" + (maand + 1) + "-" + dag;
    let datePlusEenMaand = jaar + "-" + (maand + 2) + "-" + dag;
    console.log((insertBoek))


    if (insertBoek.dateSelectOne !== undefined)
    {
        let dateSelectOneD = new Date(insertBoek.dateSelectOne)
        // als de gebruiker EEN datums heeft gekozen
        let dateSelectOnejaar = dateSelectOneD.getFullYear();
        let dateSelectOnemaand = dateSelectOneD.getMonth();
        let dateSelectOnedag = dateSelectOneD.getDate();
        insertBoek.BestellingDatum = dateSelectOnejaar + "-" + (dateSelectOnemaand + 1) + "-" + dateSelectOnedag;
        let dateSelectTwo = new Date(insertBoek.dateSelectTwo);
        let dateSelectTwojaar = dateSelectTwo.getFullYear();
        let dateSelectTwomaand = dateSelectTwo.getMonth();
        let dateSelectTwodag = dateSelectTwo.getDate();
        insertBoek.VerwachteReturnDatum = dateSelectTwojaar + "-" + (dateSelectTwomaand + 1) + "-" + dateSelectTwodag;
        }

    else{// als de gebruiker GEEN datums heeft gekozen

        insertBoek.BestellingDatum = dateVandaag;
        insertBoek.VerwachteReturnDatum = datePlusEenMaand;

    }

    let boek = {
            bestellingNr: bestellingNr,
            ean: insertBoek.EAN,
            verwachteReturnDatum: insertBoek.VerwachteReturnDatum,
            bestellingsDatum : insertBoek.BestellingDatum
        }
    console.log(boek)

    postBoekToBackend(boek)
}
function postBoekToBackend(boek){
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    fetch(apiUrl + 'BestelItems', {  //BestelItems
        method: 'POST',
        body: JSON.stringify(boek),
        headers: messageHeaders
    })
        .then(function validateResponse(response) {
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(function readResponseAsText(response) {
            return response.text();
        })
        .then(logResult)
        .catch(function logError(error) {
            console.log(error);
        });
}
function logResult(){
    let boekenArray = JSON.parse(localStorage.getItem('boekenInWinkelWagen'));
    boekenArray.shift()
    let boekenArray_sting = JSON.stringify(boekenArray)
    localStorage.setItem('boekenInWinkelWagen', boekenArray_sting);

    checkBoekenArray()


}
function checkBoekenArray(){
    let boekenArray = JSON.parse(localStorage.getItem('boekenInWinkelWagen'));
    if(boekenArray.length !== 0) {
        ItemsOpslaan()
    }
    else{
        // allen boeken zijn toegevoegd   einde
        //alert('alle boeken zijn opgeslagen')
        MailSturen()
    }
}


function MailSturen()
{
    /* Klant gegevens */

    let klant = JSON.parse(localStorage.getItem('klant'));
    let email = klant.Emailadres;
    let bestellingNr = JSON.parse(localStorage.getItem('BestellingNr'));

    /* Klant wil zijn gegevens opslaan of niet */

    let facturatieAdres =
        {
            email : email,
            bestellingNr : bestellingNr
        };
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    return fetch(apiUrl + 'ResBevestiging', {
        method: 'POST',
        body: JSON.stringify(facturatieAdres),
        headers: messageHeaders
    })
        .then(function validateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(function readResponseAsText(response){
            return response.text();
        })
        .then(function logResult(result){
            console.log(result);
            window.location.assign('Confirmatie.html');
        })
        .catch(function logError(error){
            console.log(error);
        });
}