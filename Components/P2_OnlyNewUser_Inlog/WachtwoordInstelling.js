const url = 'https://localhost:44397/api/';
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}
/* Fetch */
let emailadres = document.getElementById('email');
let wachtwoord1 = document.getElementById('wachtwoordEén');
let wachtwoord2 = document.getElementById('wachtwoordTwee');
let isEmailBestaat = false;
let btnDoorgaan = document.getElementById('btnDoorgaan');
let btnWijzigen = document.getElementById('btnWijzigen');
let btnCodeDoorgeven = document.getElementById('btnCodeDoorgeven');
btnDoorgaan.addEventListener('click', CheckMail)
function CheckMail(event)
{
    emailadres = document.getElementById('email').value;
    sessionStorage.setItem('email', emailadres);
    event.preventDefault();
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    let Email = {
        emailadres : emailadres
    }
    return fetch(url + 'Email', {
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(Email)
    })
        .then(function ValidateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(response => {
            return response.text();
        })
        .then(data =>{
           if(data !== "[]")
           {
               document.getElementById('code').style.display = "inline-block";
               document.getElementById('btnDoorgaan').style.display = "none";
               document.getElementById('btnCodeDoorgeven').style.display = "inline-block";
               WachtwoordAangepastMail();
           }
           else {
               alert("Uw email bestaat niet gemaakt.");
           }
        })
        .catch(error =>{
            console.log(error);
        })
}
function WachtwoordAangepastMail()
{
    email = document.getElementById('email').value;
    let Email = {
        EmailAdres : email
    }
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(url + 'Mail',{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(Email)
    })
        .then(function ValidateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(response => {
            return response.text();
        })
        .then(code =>{
            localStorage.setItem('Code', code);

        })
        .catch(error =>{
            console.log(error);
        })
}
btnCodeDoorgeven.addEventListener('click', CheckCode);
function CheckCode(){
    let code = localStorage.getItem('Code');
    console.log(code);
    let inputCode = document.getElementById('code').value;
    if(inputCode === code)
    {
        document.getElementById('wachtwoordWijzigen').style.display = "block";
        document.getElementsByClassName('col-1')[0].style.display = "none";

    }
    else {
        localStorage.removeItem('Code');
        alert("De code is incorrect. Probeer opnieuw");
        inputCode.value = " ";
        location.reload();
    }
}

let letter = document.getElementById("letter");
let capital = document.getElementById("capital");
let number = document.getElementById("number");
let length = document.getElementById("length");

let inputSucceeded = true;
// When the user clicks on the password field, show the message box
wachtwoord1.onclick = function () {
    document.getElementById("message").style.display = "block";
}

// When the user clicks outside of the password field, hide the message box
wachtwoord1.onkeyup = function () {
    document.getElementById("message").style.display = "none";
}


wachtwoord1.onkeyup = function () {
    // Validate lowercase letters
    let lowerCaseLetters = /[a-z]/g;
    if (wachtwoord1.value.match(lowerCaseLetters)) {
        letter.classList.remove("invalid");
        letter.classList.add("valid");
    } else {
        letter.classList.remove("valid");
        letter.classList.add("invalid");
        inputSucceeded = false;
    }
    // Validate capital letters
    let upperCaseLetters = /[A-Z]/g;
    if (wachtwoord1.value.match(upperCaseLetters)) {
        capital.classList.remove("invalid");
        capital.classList.add("valid");
    } else {
        capital.classList.remove("valid");
        capital.classList.add("invalid");
        inputSucceeded = false;
    }
    // Validate numbers
    let numbers = /[0-9]/g;
    if (wachtwoord1.value.match(numbers)) {
        number.classList.remove("invalid");
        number.classList.add("valid");
    } else {
        number.classList.remove("valid");
        number.classList.add("invalid");
        inputSucceeded = false;
    }
// Validate length
    if (wachtwoord1.value.length >= 8) {
        length.classList.remove("invalid");
        length.classList.add("valid");
    } else {
        length.classList.remove("valid");
        length.classList.add("invalid");
        inputSucceeded = false;
    }
}
wachtwoord2.onkeydown = function () {
    document.getElementById('wachtwoordVergelijken').style.display = 'none';
}
wachtwoord2.onkeyup = function (){
    if (wachtwoord1.value !== wachtwoord2.value)
    {
        document.getElementById('wachtwoordVergelijken').style.display = "block"
    }
    else {
        document.getElementById('wachtwoordVergelijken').style.display = "none"

    }
}


btnWijzigen.addEventListener('click', WijzigWachtwoord)
function WijzigWachtwoord(event){
    event.preventDefault()
    wachtwoord2 = document.getElementById('wachtwoordTwee').value;
    let EmailWachtwoord = {
        EmailAdres : email,
        Wachtwoord : wachtwoord2
    }
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(url + 'NieuwWachtwoord',{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(EmailWachtwoord)
    })
        .then(function ValidateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(response => {
            return response.text();
        })
        .then(data =>{
            console.log(data)
            if(data !== "true")
            {
                alert("Uw wachtwoord is niet aangepast")
            }
            else {
                PasswordChangedEmail()
                alert('Uw wachtwoord is aangepast')
                setTimeout(function () {
                    window.location.href = '../P2_OnlyNewUser_Inlog/login.html'
                }, 3000)
            }
        })
        .catch(error =>{
            console.log(error);
        })
}

function PasswordChangedEmail()
{
    let emailadres = sessionStorage.getItem('email');
    let Email = {
        emailadres : emailadres
    }
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(url + 'EmailBevestiging',{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(Email)
    })
        .then(function ValidateResponse(response){
            if (!response.ok) { // (1)
                throw Error(response.statusText); // (2)
            }
            return response;
        })
        .then(response => {
            return response.text();
        })
        .then(data =>{
            console.log(data)
            if(data !== "true")
            {
                alert("Uw wachtwoord is niet aangepast")
            }
            else {
                alert('Uw wachtwoord is aangepast')
                setTimeout(function () {
                    window.location.href = '../P2_OnlyNewUser_Inlog/login.html'
                }, 3000)
            }
        })
        .catch(error =>{
            console.log(error);
        })
}












