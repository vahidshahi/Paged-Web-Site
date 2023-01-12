const apiUrl = 'https://localhost:44397/api/';
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}



let btnCheckout = document.getElementById('btnProceedCheckout');

btnCheckout.addEventListener("click", BevestigBestelling)

function BevestigBestelling() {
    ItemsOpslaan()
    SaveToLocalStorage();

}
function SaveToLocalStorage() {

    let bestellingNr = JSON.parse(localStorage.getItem('BestellingNr'));
    let naam = document.getElementById('inputVoornaam').value;
    let voornaam = document.getElementById('inputNaam').value;
    let emailBijFacturatie = document.getElementById('inputEmail').value;
    let adres = document.getElementById('inputAdres').value;
    let woonplaats = document.getElementById('inputWoonplaats').value;
    let state = document.getElementById('inputState').value;
    let postcode = document.getElementById('inputPostcode').value;
    let kaartNummer = document.getElementById('inputKaartNummer').value;
    let naamOpKaart = document.getElementById('inputNaamOpKaart').value;
    let vervalMaand = document.getElementById('inputVervalMaand').value;
    let vervaljaar = document.getElementById('inputVervalJaar').value;
    let kaartGegevens = {
        naamOpKaart : naamOpKaart,
        kaartNummer : kaartNummer,
        vervalMaand : vervalMaand,
        vervaljaar : vervaljaar
    }
    localStorage.setItem('KaartGegevens', JSON.stringify(kaartGegevens));

}

function BestellingPlaatsen()
{

    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    let klantItem = JSON.parse(localStorage.getItem('klant'));
    let klantId = klantItem[0].KlantId;
    let klantInfo = {
        klantId : klantId
    }
    fetch(apiUrl + 'Orders', {
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
function ItemsOpslaan()
{

    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    let boekenArray = JSON.parse(localStorage.getItem('boekenInWinkelWagen'));
    let bestellingNr = JSON.parse(localStorage.getItem('BestellingNr'));
    let verwachteReturns = JSON.parse(localStorage.getItem('boekDatums'));
    let verwachteReturnDatum = verwachteReturn[0].dateSelectTwo;
    if(verwachteReturnDatum === null)
    {
        verwachteReturnDatum = new Date();
    }
    for (let i = 0;i < boekenArray.length; i++)
    {
        let boek = {
            BestellingNr :  bestellingNr,
            EAN : boekenArray[i].EAN,
            ReturnDatum : verwachteReturns[i].dateSelectOne,
            VerwachteReturnDatum : verwachteReturns[i].dateSelectTwo
        }
      fetch(apiUrl + 'BestelItems', {
            method: 'POST',
            body: JSON.stringify(boek),
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
                BevestigingEmail();
            })
            .catch(function logError(error){
                console.log(error);
            });
    }
}

function BevestigingEmail()
{
    /* Klant gegevens */

    let btnJa = document.getElementById('radioBtnJa');
    let btnNee = document.getElementById('radioBtnNee');
    let klant = JSON.parse(localStorage.getItem('klant'));
    let email = klant[0].Emailadres;
    let bestellingNr = JSON.parse(localStorage.getItem('BestellingNr'));
    let naam = klant[0].Achternaam;
    let voornaam = klant[0].Voornaam;
    let adres = klant[0].adres;
    let kaart = JSON.parse(localStorage.getItem('KaartGegevens'));
    let kaartNummer = kaart.kaartNummer;
    /* Klant wil zijn gegevens opslaan of niet */

    let facturatieAdres =
        {
            email : email,
            bestellingNr : bestellingNr,
            naam: naam,
            voornaam : voornaam,
            adres: adres,
            kaartNummer: kaartNummer
        };
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    return fetch(apiUrl + 'OrderBevestigingMail', {
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
            if(btnJa.checked)
            {

                // bestelling is geplaats
            }
            //else je bestelling is geplaatst maar worden bankkaart gegevens opslaan


        })
        .catch(function logError(error){
            console.log(error);
        });
}
function BestellingMetKaartGegevensOpslaan()
{

    /* Kaart gegevens*/
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    let klantItem = JSON.parse(localStorage.getItem('klant'));
    let klantId = klantItem[0].KlantId;
    let naamKaartHouder = document.getElementById('inputNaamOpKaart');
    let kaartNummer = document.getElementById('inputKaartNummer');
    let vervalMaand = document.getElementById('inputVervalMaand');
    let vervalJaar = document.getElementById('inputVervalJaar');


    let kaartGegevens = {
        kaartNummer : kaartNummer,
        KlantId : klantId,
        KaartHouderNaam : naamKaartHouder,
        vervalJaar : vervalJaar,
        vervalMaand : vervalMaand
    }

    return fetch(apiUrl + '', {
        method: 'POST',
        body: JSON.stringify(kaartGegevens),
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
        })
        .catch(function logError(error){
            console.log(error);
        });

}
