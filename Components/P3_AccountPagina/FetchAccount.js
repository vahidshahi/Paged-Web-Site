const apiUrlAccount = 'https://localhost:44397/api/account';
const apiUrlKlantenBoeken= 'https://localhost:44397/api/klantenboeken';
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}
const array_maanden_short = [
    "Jan",
    "Feb",
    "Mrt",
    "Apr",
    "Mei",
    "Jun",
    "Jul",
    "Aug",
    "Sep",
    "Okt",
    "Nov",
    "Dec"];
let boekenDieAlTerugZijn = []
let boekenDieDeKlantNuHeeft = []
let indexBoek = "";
let isGevuld = false;
let klantId_int = 0
// INFO VAN DE KLANT OPHALEN
getKlantFromLocalstorge()
function getKlantFromLocalstorge(){
    const klant_string = localStorage.getItem('klant');
    let klant = JSON.parse(klant_string);
    if(klant !== null){
        klantId_int = klant.KlantId;
        if( klantId_int === undefined){
            klantId_int = klant[0].KlantId;
        }

        let gegevens = {
            indicator : 'id',
            KlantId: klantId_int,
        }
        gegevensAanpassen(gegevens)
        boekenVanKantOphalen(gegevens)
    }
    else{
        alert('JE BENT NIET INGELOGD')
    }


}
function gegevensAanpassen(aangepasteGegevens) {
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(apiUrlAccount,{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(aangepasteGegevens),
    })
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logKlantResult) // (5)
        .catch(logError); // (6)*/
}
function validateResponse(response) {
    //console.log(response)
    if (!response.ok) {
        //console.log(' a problem:');
        throw Error(response.statusText); // (2)
    } else {
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
function logKlantResult(result) {
    //console.log(result)
    let klant = result[0]
    //console.log(klant.Voornaam)
    saveToKlantFromLocalstorge(klant)
    setPageInfo(klant)
   // console.log(klant)

}
function saveToKlantFromLocalstorge(klant){
    let klant_sting = JSON.stringify(klant)
    localStorage.setItem( 'klant', klant_sting);
}
function setPageInfo(klant) {
       let wachtwoordlengte = "";
        document.getElementById('DBI-voornaam').innerHTML = `${klant.Voornaam}`;
        document.getElementById('DBI-achternaam').innerHTML = `${klant.Achternaam}`;
        let gbt = new Date(klant.Geboortedatum).toLocaleDateString("nl-BE")

        document.getElementById('DBI-geboortedatum').innerHTML = gbt == null ? "Wat is je geboortedatum? " :`${gbt}`;
        // console.log((klant.Geboortedatum.ToString().ToString(dd-mm-yyyy)))

        document.getElementById('DBI-mailaderes').innerHTML = `${klant.Emailadres}`
        document.getElementById('DBI-straatnaam').innerHTML = klant.Straatnaam == null ? "we hebben je aderes nodig om boeken ste kunnen sturen" :`${klant.Straatnaam}`;
        document.getElementById('DBI-Huis_Nmr').innerHTML =  klant.Huisnr == null ? "":`${klant.Huisnr}`;
        document.getElementById('DBI-busnummer').innerHTML = klant.Busnr == null ? "":`${klant.Busnr}`;
        document.getElementById('DBI-postcode').innerHTML = klant.postcode == null ? "":`${klant.postcode}`;
        document.getElementById('DBI-gemeente').innerHTML = klant.gemeente == null ? "":`${klant.gemeente}`;
        document.getElementById('DBI-extraInfo').innerHTML = klant.ExtraKlantenInfo == null ? "is er iets waar we rekening me moeten houden?" : `${klant.ExtraKlantenInfo}`;
        document.getElementById('DBI-telefoonnummer').innerHTML = klant.Gsmnr == null ? "Wat is je GSM nummer" : `${klant.Gsmnr}`;
        for (let i = 0; i < (klant.Wachtwoord).length; i++) {
            wachtwoordlengte += "*"
        }
        document.getElementById('DBI-wachtwoord').innerHTML = wachtwoordlengte;
}
function getMaand(){
    const array_maanden = [
        "January",
        "February",
        "Maart",
        "April",
        "Mei",
        "Juni",
        "July",
        "Agustus",
        "September",
        "Oktober",
        "November",
        "December"];
   let v =  document.getElementsByName('maanden')[0].value;
    console.log(v)
    console.log(array_maanden[0])
    if(v === array_maanden[0]){ return '01' }
    if(v === array_maanden[1]){ return '02' }
    if(v === array_maanden[2]){ return '03' }
    if(v === array_maanden[3]){ return '04'}
    if(v === array_maanden[4]){ return '05' }
    if(v === array_maanden[5]){ return '06' }
    if(v === array_maanden[6]){ return '07' }
    if(v === array_maanden[7]){ return '08' }
    if(v === array_maanden[8]){ return '09' }
    if(v === array_maanden[9]){ return '10' }
    if(v === array_maanden[10]){ return '11' }
    if(v === array_maanden[11]){ return '22' }



}
const opslaanModalButtons = document.querySelectorAll('[data-save-button-target]')
    opslaanModalButtons.forEach(button => {
        let aangepasteGegevens = {}
        button.addEventListener('click', () => {
            if ('DBT-name' === button.dataset.saveButtonTarget) {
                let txtvoornaam = document.getElementById('DBT-voornaam').value;
                let txtachternaam = document.getElementById('DBT-achternaam').value;
                if( txtvoornaam !== "" && txtachternaam !== ""){
                    isGevuld = true;
                    aangepasteGegevens = {
                        indicator: 'name',
                        KlantId: klantId_int,
                        Voornaam: txtvoornaam,
                        Achternaam: txtachternaam,
                    }
                }
                else{
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }

            }

            else if ('DBT-geboortedatum' === button.dataset.saveButtonTarget) {
                let dag = document.getElementById('DBT-dag').value
                let maand = getMaand();
                let jaar = document.getElementById('DBT-jaar').value
                if( dag !== "" && maand !== "" && jaar !== ""){
                    const gbd = jaar + "-" + maand + "-" + dag  // hier moeten nog aanpassingen aan    optie box
                    console.log(gbd)
                    isGevuld = true;
                    aangepasteGegevens = {
                        indicator: 'gbd',
                        KlantId: klantId_int,
                        Geboortedatum: gbd
                    }
                }
                else {
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }
            }

            else if ('DBT-emailaderes' === button.dataset.saveButtonTarget) {
                let email =  document.getElementById('DBT-email').value
                if (email !== ""){
                    if(email.search("@hotmail") || email.search("@gmail") || email.search("@")){
                        if(email.search(".be") || email.search(".com")){
                            isGevuld = true;
                            aangepasteGegevens = {
                                indicator: 'mail',
                                KlantId: klantId_int,
                                Emailadres: email
                            }
                        }
                    }
                }
                else {
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }
            }

            else if ('DBT-aderes' === button.dataset.saveButtonTarget) {
                 let straatnaam = document.getElementById('DBT-straat').value;
                  let huisnr = document.getElementById('DBT-huisnmr').value;
                   let busnr = document.getElementById('DBT-busnmr').value;
                  let  givenPostcode = document.getElementById('DBT-postcode').value;
                  let  givenGemeente = document.getElementById('DBT-gemeente').value;
                  if(straatnaam !== "" && huisnr !=="" && busnr !== "" && givenPostcode !=="" && givenGemeente !== "" ){
                      isGevuld = true;
                      aangepasteGegevens = {
                          indicator: 'aderes',
                          KlantId: klantId_int,
                          Straatnaam: straatnaam,
                          Huisnr: huisnr,
                          Busnr: busnr,
                          givenPostcode: givenPostcode,
                          givenGemeente: givenGemeente
                      }
                  }
                  else {
                      isGevuld = false;
                      alert('geef eerst een waarde in')
                  }


            }

            else if ('DBT-extraKlantenInfo' === button.dataset.saveButtonTarget) {
                // alert('EXTRAklanteninfo aanpassen')
                let info = document.getElementById('DBT-extraInfo').value
                if(info !== ""){
                    isGevuld = true;
                    aangepasteGegevens = {
                        indicator: 'extraKlantenInfo',
                        KlantId: klantId_int,
                        ExtraKlantenInfo: info
                    }
                }
                else {
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }
            }

            else if ('DBT-gsmnr' === button.dataset.saveButtonTarget){
                let gsmnr = document.getElementById('DBT-gsmnr').value
                if( gsmnr !== ""){
                    if(parseInt(gsmnr.slice(0, 1)) === 0 || gsmnr.slice(0, 1) === '+' ){
                        isGevuld = true;
                        aangepasteGegevens = {
                            indicator: 'gsmnr',
                            KlantId: klantId_int,
                            Gsmnr: gsmnr
                        }
                    }
                    else {
                        isGevuld = false;
                        alert("gelieven een Gsmnr in te geven")
                    }
                }
                else {
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }
            }

            else if ('DBT-wachtwoord' === button.dataset.saveButtonTarget) {
                if(isWachtwoordOkeConstrain === true && isWachtwoordOkeEven === true){
                    isGevuld = true;
                    aangepasteGegevens = {
                        indicator: 'wachtwoord',
                        KlantId: klantId_int,
                        Wachtwoord: document.getElementById('wachtwoord2').value
                    }
                }
                else {
                    isGevuld = false;
                    alert('geef eerst een waarde in')
                }

            }

            if(isGevuld === true){
                gegevensAanpassen(aangepasteGegevens)
                aangepasteGegevens = {};

                let modal = Array.from(document.getElementsByClassName('modalClassActive'))[0]
                let overlay = Array.from(document.getElementsByClassName('overlayClassActive'))[0]
                modal.classList.remove('active')
                modal.classList.remove('modalClassActive')
                overlay.classList.remove('active')
                overlay.classList.remove('overlayClassActive')

            }

        })

    })

//WACHTWOORD CHECK
let isWachtwoordOkeConstrain = false;
let isWachtwoordOkeEven = false;
let myWachtwoord = document.getElementById("wachtwoord");
let mySecondWachtwoord = document.getElementById("wachtwoord2");
let letter = document.getElementById("letter");
let capital = document.getElementById("capital");
let number = document.getElementById("number");
let length = document.getElementById("length");
//let btnRegisteren = document.getElementById('btn_registeren');
// When the user clicks on the password field, show the message box
myWachtwoord.onfocus = function () {
    document.getElementById("message").style.display = "block";
}
myWachtwoord.onblur = function () {
    document.getElementById("message").style.display = "none";
}
// When the user starts to type something inside the password field
myWachtwoord.onkeyup = function () {
    // Validate lowercase letters
    let lowerCaseLetters = /[a-z]/g;
    if (myWachtwoord.value.match(lowerCaseLetters)) {
        letter.classList.remove("invalid");
        letter.classList.add("valid");
        isWachtwoordOkeConstrain = true
    } else {
        letter.classList.remove("valid");
        letter.classList.add("invalid");
        isWachtwoordOkeConstrain = false

    }
    // Validate capital letters
    let upperCaseLetters = /[A-Z]/g;
    if (myWachtwoord.value.match(upperCaseLetters)) {
        capital.classList.remove("invalid");
        capital.classList.add("valid");
        isWachtwoordOkeConstrain = true
    } else {
        capital.classList.remove("valid");
        capital.classList.add("invalid");
        isWachtwoordOkeConstrain = false

    }
    // Validate numbers
    let numbers = /[0-9]/g;
    if (myWachtwoord.value.match(numbers)) {
        number.classList.remove("invalid");
        number.classList.add("valid");
        isWachtwoordOkeConstrain = true
    } else {
        number.classList.remove("valid");
        number.classList.add("invalid");
        isWachtwoordOkeConstrain = false

    }
    // Validate length
    if (myWachtwoord.value.length >= 8) {
        length.classList.remove("invalid");
        length.classList.add("valid");
        isWachtwoordOkeConstrain = true
    } else {
        length.classList.remove("valid");
        length.classList.add("invalid");
        isWachtwoordOkeConstrain = false

    }
}
mySecondWachtwoord.onkeyup = function (){

    myWachtwoord = document.getElementById("wachtwoord").value;
    mySecondWachtwoord = document.getElementById("wachtwoord2").value;

    if(myWachtwoord === mySecondWachtwoord)
    {
        document.getElementById('bevestigWachtwoord').style.display = 'none';
        isWachtwoordOkeEven = true
    }
    else {
        document.getElementById('bevestigWachtwoord').style.display = 'block';
        isWachtwoordOkeEven = false
    }

}


/// BOEKEN VAN DE KLANT OPHALEN
function boekenVanKantOphalen(gegevens) {
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(apiUrlKlantenBoeken,{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(gegevens),
    })
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logBoekenResult) // (5)
        .catch(logError); // (6)*/
}
function logBoekenResult(result) {
   // console.log(result)
    FilterBoekenArray(result)
}
function berekenStausBoek(boek){
    if(boek.ReturnDatum === null){
        indexBoek = "boekenDieDeKlantNuHeeft"
        return indexBoek
    }
    else{
        indexBoek = "boekenDieAlTerugZijn"
        return indexBoek
    }
}

function FilterBoekenArray(boeken){
   // console.log(boeken)
    boeken.forEach(boek => {
       // console.log(boek)
        indexBoek = berekenStausBoek(boek)
        if(indexBoek === "boekenDieAlTerugZijn"){
            boekenDieAlTerugZijn.push(boek)
        }
        else{
            boekenDieDeKlantNuHeeft.push(boek)
        }
    })

    setBoekenDieDeKlantNuHeeftOnPage()
    setBoekenDieAlTerugZijnOnPage()

}
function setBoekenDieDeKlantNuHeeftOnPage(){
   const boekenPlank =  document.getElementById('section-mijn-boeken')
    let inhoud = ''
    //console.log(boekenDieDeKlantNuHeeft.length)
    if(boekenDieDeKlantNuHeeft.length !== 0){
        boekenDieDeKlantNuHeeft.forEach(boek =>{
            let returndate = new Date(boek.VerwachteReturnDatum)
            let d = returndate.getUTCDate();
            let m = array_maanden_short[returndate.getMonth()]
            //console.log(returndate)
           // console.log(d)
            //console.log(m)
            inhoud += `
       <div class="card-row">
            <div class="title-book">${boek.Titel}</div>
            <div class="kalender-day">
            <div class="kMaand">${m}</div>
            <div class="kDag">${d}</div> </div>
          <!--<button>Verleg je huur duur</button>-->
       </div> `})
    }
    else{
        inhoud = `<h3> Je hebt nog geen boeken   </h3>`
    }
    boekenPlank.innerHTML = inhoud



}
function setBoekenDieAlTerugZijnOnPage(){
    const Geschiedenis =  document.getElementById('section-mijn-geschiedenis')
    let inhoud = '';
    //console.log(boekenDieAlTerugZijn.length)
    if(boekenDieAlTerugZijn.length !== 0){
        console.log(boekenDieAlTerugZijn)
        boekenDieAlTerugZijn.forEach(boek =>{
            let dateBest = new Date(boek.BestellingDatum)
            //let dateVerwa= new Date(boek.VerwachteReturnDatum).toLocaleDateString("nl-BE")
            // let dateRetu = new Date(boek.ReturnDatum).toLocaleDateString("nl-BE")
            let d = dateBest.getUTCDate();
            let m = array_maanden_short[dateBest.getMonth()]
            let y = dateBest.getUTCFullYear();
            inhoud += `
         <div class="card-geschiedenis">
             <div class="bestelings-Date">
                                    <div>${d} ${m} ${y}  </div>
                                    <div>Bestelnummer: ${boek.BestellingNr}</div>
                                   </div>
             <div class="product">
                  <img alt="" src="../../DataAssets/${boek.SourceImg}">
                  <div class="flex-column--left">
                   <div class="product__titel">${boek.Titel} </div>
                  <div class="product__auteur">${boek.Auteur} </div>
                 </div>
                 
             </div>
        </div>
`})
    }
    else{
        inhoud = `<h3> er is nog een bestelgeschiedenis  </h3>`
    }

    Geschiedenis.innerHTML = inhoud
}

