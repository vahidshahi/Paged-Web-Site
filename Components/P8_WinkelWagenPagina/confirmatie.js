BestellingGegevens()

let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout');
loggedInUserCheck();
function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    console.log(user)
    let userArray = JSON.parse(user);
    console.log(userArray);
    if (user){

        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        pKlant.textContent = "Hi, " + userArray.Voornaam;
        btnLogin.style.display = "none";
        btnSignOut.style.display = "inline-block";
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


function BestellingGegevens()
{
    let klant =  JSON.parse(localStorage.getItem('klant'));
    let bestellingNr = JSON.parse((localStorage.getItem('BestellingNr')));
    let content = document.getElementsByClassName('content')[0];
    let date = new Date();

    let bestelDatum;
    let dd = date.getDate();
    let mm = date.getMonth() + 1 //January is 0!
    let yyyy = date.getFullYear();
    bestelDatum = mm + '/' + dd + '/' + yyyy;
    content.innerHTML = `
    <div>
    <img src="Done.png" alt="Done">
    <h4>Je bestelling succevol geplaatst ${klant.Voornaam} ${klant.Achternaam}</h4>
    <p>Jouw bestelling ${bestellingNr} op ${bestelDatum}</p>
    <p>Bedankt voor je bestelling</p>  
    </div>
    <div>
    <h4>Bezorgadres</h4>
     <p>${klant.Voornaam} ${klant.Achternaam}</p>
     <p>${klant.Straatnaam} ${klant.Huisnr} ${klant.Huisnr}</p>
     <p>${klant.postcode} ${klant.gemeente}</p>
     <a id="doorgaan" href="../P1_OnlyStartPagina/OnlyStartPagina_1.html">Doorgaan</a>

    </div>
    `

    let adres = document.getElementById('adres');

}

const btnDoorgaan = document.getElementById('doorgaan');
btnDoorgaan.addEventListener('click',function (){
    localStorage.removeItem('BestellingNr')
    localStorage.removeItem('factuurNr')
    localStorage.removeItem('cardNumbers');
    localStorage.removeItem('boekNaarProductPage')
    localStorage.removeItem('boekenInWinkelWagen')
    localStorage.removeItem('facturatie')
})
function FacturatieAdres()
{
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });

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


