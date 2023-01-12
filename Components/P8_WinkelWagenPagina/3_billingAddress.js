AutomatischInvullen()
/*deze fetch gaat naar de FacturatieController
* Insert Factuur   --->   stuurt INT terug   FactuurNR
* WORD HIERNA GEBRUIKT IN ??    */

const apiUrl = 'https://localhost:44397/api/';
let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout')
let isloggedIn = false
loggedInUserCheck();

function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    let userArray = JSON.parse(user);
    if (user){
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        let name
        name = userArray.Voornaam;  if(name === undefined){name = userArray.Voornaam}
        pKlant.textContent = "Hi, " + name;
        btnLogin.style.display = "none";
        btnSignOut.style.display = "inline-block";
        isloggedIn = true;

    }
    else {
        document.getElementById("naamVanKlant").style.display = "none";
    }


}

btnSignOut.addEventListener('click', Logout)
function Logout(){
    localStorage.clear();
    btnSignOut.style.display = "none";
    btnLogin.style.display = "inline-block";
    document.getElementById('maakAccount2').style.display = "block";
}
let klantNaamHover = document.getElementById('naamVanKlant');
klantNaamHover.onclick = function (){
    document.getElementById('account').style.display = "flex";
}
let account = document.getElementById('account')
account.onmouseleave = function (){
    document.getElementById('account').style.display = "none";

}


function AutomatischInvullen(){
    let klant = JSON.parse(localStorage.getItem('klant'));
    // console.log(klant[].Voornaam)
    // het moet hier value zijn omdat het een inputBox is
    document.getElementById('inputVoornaam').value = klant.Voornaam;
    document.getElementById('inputNaam').value = klant.Achternaam;
    document.getElementById('inputEmail').value = klant.Emailadres;
    document.getElementById('inputAdres').value = klant.Straatnaam + klant.Huisnr;
    document.getElementById('inputWoonplaats').value = klant.gemeente;
    document.getElementById('inputPostcode').value = klant.postcode;

}
/*
document.getElementById('btnDoorgaan').addEventListener('click', openPagina)

function openPagina() {
    if(isloggedIn === true){
        window.location.assign('4_Payment.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
    }
}
*/



BoekenOpWinkelPagina()
updateCartTotaal()
function BoekenOpWinkelPagina()
{
    let boekenWinkelWagen = JSON.parse(localStorage.getItem('boekenInWinkelWagen'));
    console.log(boekenWinkelWagen);
    boekenWinkelWagen.forEach(boek =>
    {
        let producten = document.getElementById('producten');
            producten.innerHTML += `
            <div class="product" >
            <button class="btn-remove" data-remove-button-target=${boek.EAN}><img src="remove%20(1).png" alt="Icon remove"></button>
            <img class="bookImage" src="../../DataAssets/${boek.SourceImg}" alt="">
            <div class="title">${boek.Titel}</div>
            <div class="price" >€ ${boek.HuurPrijs}</div>
           </div>
            `
    })
}

let removedItems = document.getElementsByClassName('btn-remove');
if (removedItems)
{
    RemoveItems();
}
function RemoveItems()
{
    for (let i = 0; i < removedItems.length; i++)
    {
        let button = removedItems[i];
        button.addEventListener('click', function (){
            document.getElementsByClassName('product')[0].remove();
            updateCartTotaal()
        })

    }
}

function updateCartTotaal()
{
    let kartItemContainer = document.getElementsByClassName('producten-container')[0];
    let cartRows = kartItemContainer.getElementsByClassName('product')
    let totaal = 0;
    for (let i = 0; i < cartRows.length; i++)
    {
        let cartRow = cartRows[i];
        let priceBoek = cartRow.getElementsByClassName('price')[0];
        let price = parseFloat(priceBoek.innerText.replace('€', ''))
        totaal += price;
    }


    document.querySelector('div.product_total > p').textContent = '€ ' + totaal;

}



let boeken_string = localStorage.getItem('boekenInWinkelWagen')
let boeken = JSON.parse(boeken_string)
const removeButton = document.querySelectorAll('[data-remove-button-target]')
removeButton.forEach(button => {
    button.addEventListener('click', () => {
        const ean = button.dataset.removeButtonTarget
        eanVanBoek = boeken.filter(boek => {
            return boek.EAN === ean;

        })
        for (let i=0;i<boeken.length;i++){
            if (ean===boeken[i].EAN){
                boeken.splice(i,1)

                localStorage.setItem('boekenInWinkelWagen',JSON.stringify(boeken))
                let productsNumbers = parseInt(localStorage.getItem('cardNumbers'));
                localStorage.setItem('cardNumbers', JSON.stringify(productsNumbers - 1));
                if (productsNumbers===0){

                    document.getElementById('emptyCart').style.display="block";

                }

            }
        }
        removeItems()
        updateCartTotaal()
    })
})


/* Doorgaan met adres gegevens opslaan en boeken opslaan in localstorage */

let btnDoorgaan = document.getElementById('btnDoorgaan');
btnDoorgaan.addEventListener('click', SaveData);
function SaveData()
{
    let klant = JSON.parse(localStorage.getItem('klant'))
    let voornaam = document.getElementById('inputVoornaam').value;
    let achternaam = document.getElementById('inputNaam').value;
    let email = document.getElementById('inputEmail').value;
    let straat = document.getElementById('inputAdres').value;
    let woonplaats = document.getElementById('inputWoonplaats').value;
    let postcode = document.getElementById('inputPostcode').value;
    //let klantId
    //klantId = klant.klantId;  if(klantId === undefined){klantId = klant.klantId}
    let facturatieAdres = {
        klantId : klant.KlantId,
        voornaam : voornaam,
        achternaam : achternaam,
        email : email,
        straat : straat,
        woonplaats : woonplaats,
        postcode : postcode
    }
    if(voornaam === "" || achternaam === "" || email === "" || straat === "" || woonplaats === "" || postcode === "")
    {
        document.getElementById('legeVelden').style.display = "block";

    }
    else {
        localStorage.setItem('facturatie', JSON.stringify(facturatieAdres));
        SaveToDatabase();
    }


}
let velden = document.getElementsByClassName('velden');
for (let i = 0; i <velden.length; i++)
{
    velden[i].addEventListener('click' , function OpFocus(){
        document.getElementById('legeVelden').style.display = "none";
    })
}

function SaveToDatabase(){

    let klant = JSON.parse(localStorage.getItem('klant'))
    let voornaam = document.getElementById('inputVoornaam').value;
    let achternaam = document.getElementById('inputNaam').value;
    let email = document.getElementById('inputEmail').value;
    let straat = document.getElementById('inputAdres').value;
    let woonplaats = document.getElementById('inputWoonplaats').value;


    let facturatieAdres = {
        klantId : klant.KlantId,
        voornaam : voornaam,
        achternaam : achternaam,
        email : email,
        straat : straat,
        woonplaats : woonplaats,
    }

    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    })
    return fetch(apiUrl + 'Facturatie', {
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
            localStorage.setItem('factuurNr', result);
            setTimeout(function () {
                window.location.replace('4_Payment.html');
            }, 3000)

          })
        .catch(function logError(error){
            console.log(error);
        });
}


const btnAnnuleren = document.getElementById('btnAnnuleren')
btnAnnuleren.addEventListener('click', CancelOrder)
function CancelOrder(){
    let isExecuted = confirm("Weet je zeker dat je de bestelling wilt annuleren?");
    if (isExecuted){
        localStorage.removeItem('boekenInWinkelWagen');
        localStorage.removeItem('cardNumbers')
        window.location.replace( "../P1_OnlyStartPagina/OnlyStartPagina_1.html")


    }
}












