const apiUrl = 'https://localhost:44397/api/';

window.addEventListener('error', function (e) {e.preventDefault();}, false);
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}
let incorrectEOfP = document.getElementById('incorrectEmailOrPassword');
const btnAanmelden = document.getElementById('btnAanmelden');
let isGevuld;
let emailVeld = document.getElementById('emailAdres').value;
let wachtwoordVeld = document.getElementById('wachtwoordLogin');
wachtwoordVeld.onkeydown = function (){
    incorrectEOfP.style.display = "none";
}
document.getElementById('incorrectEmailOrPassword').style.display = "none";
if(emailVeld === " ")
{
    isGevuld = false
}
else if(wachtwoordVeld.value === " ")
{
    isGevuld = false;
}
btnAanmelden.addEventListener("click", KlantInloggen);
    function KlantInloggen(event) {
        if (isGevuld === false) {
            alert('Email of wachtwoord veld is leeg.');
        } else {
            event.preventDefault()
            const messageHeaders = new Headers({ // (1)
                'Content-Type': 'application/json'
            });
            let email = document.getElementById('emailAdres').value;
            let wachtwoord = document.getElementById('wachtwoordLogin').value;

            let loginGegevens = {
                emailAdres: email,
                wachtwoord: wachtwoord,
            }
            return fetch(apiUrl + 'Login', {
                method: 'POST', // or 'PUT'
                headers: messageHeaders,
                body: JSON.stringify(loginGegevens)
            }).then(function validateResponse(response) {
                if (!response.ok) { // (1)
                    throw Error(response.statusText); // (2)
                }
                return response;
            }).then(response => {
                return response.json();
            })
                .then(klant => {
                    console.log(klant)
                    if (klant !== 0) {
                        alert("Ingelogd");
                        SaveToLocalStorage(klant[0]);
                        setTimeout(function () {
                             window.history.back();
                            //window.location.href = '../P1_OnlyStartPagina/OnlyStartPagina_1.html'
                        }, 3000)
                    }
                     else {
                        alert("Email of wachtwoord is niet juist");
                        DisplayMessage()
                    }
                })
                .catch((error) => {
                    console.log(error);
                    //alert(error + " er is een probleem is de server.");
                })

        }
    }


function DisplayMessage()
{
    incorrectEOfP.style.display = 'block';
 }
function SaveToLocalStorage(klantInfo){
        let klantInfo_string = JSON.stringify(klantInfo)
        localStorage.setItem( 'klant', klantInfo_string);
}



 /*
 const messageHeaders = new Headers({ // (1)
                            'Content-Type': 'application/json'
                        });
                        email = document.getElementById('emailAdres').value;
                        return  fetch(apiUrl + 'klanten', {
                            method: 'POST', // or 'PUT'
                            headers: messageHeaders,
                            body: JSON.stringify({
                                emailAdres: email
                            })
                        }).then(function validateResponse(response) {
                            if (!response.ok) { // (1)
                                throw Error(response.statusText); // (2)
                            }
                            return response;
                        }).then(response => {
                            return response.text();
                        }).then(klant => {
                            f
                        }).catch(error =>{
                            console.log(error);
                        })
  */

