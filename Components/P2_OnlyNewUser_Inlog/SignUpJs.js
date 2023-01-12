const apiUrl = 'https://localhost:44397/api/SignUp';
// prevent windows from reloading
if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
}

let voornaam = document.getElementById('voornaam').value;
let achternaam = document.getElementById('achternaam').value;
let email = document.getElementById('email').value;
let wachtOpslaan = document.getElementById('wachtwoord2').value;
/*
Wachtwoord check
 */
let myWachtwoord = document.getElementById("wachtwoord");
let mySecondWachtwoord = document.getElementById("wachtwoord2");
let letter = document.getElementById("letter");
let capital = document.getElementById("capital");
let number = document.getElementById("number");
let length = document.getElementById("length");
let btnRegisteren = document.getElementById('btn_registeren');
let inputSucceeded;

btnRegisteren.addEventListener("click", postData);

// When the user clicks on the password field, show the message box
myWachtwoord.onfocus = function () {
    document.getElementById("message").style.display = "block";
}
// When the user clicks outside of the password field, hide the message box
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
    } else {
        letter.classList.remove("valid");
        letter.classList.add("invalid");
        inputSucceeded = false;
    }
// Validate capital letters
    let upperCaseLetters = /[A-Z]/g;
    if (myWachtwoord.value.match(upperCaseLetters)) {
        capital.classList.remove("invalid");
        capital.classList.add("valid");
    } else {
        capital.classList.remove("valid");
        capital.classList.add("invalid");
        inputSucceeded = false;
    }
    // Validate numbers
    let numbers = /[0-9]/g;
    if (myWachtwoord.value.match(numbers)) {
        number.classList.remove("invalid");
        number.classList.add("valid");
    } else {
        number.classList.remove("valid");
        number.classList.add("invalid");
        inputSucceeded = false;
    }
// Validate length
    if (myWachtwoord.value.length >= 8) {
        length.classList.remove("invalid");
        length.classList.add("valid");
    } else {
        length.classList.remove("valid");
        length.classList.add("invalid");
        inputSucceeded = false;
    }
}
// Control of de vakken niet leeg zijn als leeg zijn return false
if (voornaam === " ") {
    inputSucceeded = false;
} else if (achternaam === " ") {
    inputSucceeded = false;
} else if (email === " ") {
    inputSucceeded = false;
}

mySecondWachtwoord.onkeydown = function () {
    document.getElementById('bevestigWachtwoord').style.display = 'none';
}
mySecondWachtwoord.onkeyup = function () {
    let password = document.getElementById("wachtwoord").value;
    let confirmPassword = document.getElementById('wachtwoord2').value;
    if (password !== confirmPassword) {
        document.getElementById('bevestigWachtwoord').style.display = 'block';
        inputSucceeded = false;
        //confirmPassword.setCustomValidity("\"Wachtwoord komt niet overeen\"");
    } else {
        document.getElementById('bevestigWachtwoord').style.display = 'none';
        inputSucceeded = true;
    }
}

function postData(event) {
    event.preventDefault();
    if(inputSucceeded)
    {
        const messageHeaders = new Headers({ // (1)
            'Content-Type': 'application/json'

        });
        voornaam = document.getElementById('voornaam').value;
        achternaam = document.getElementById('achternaam').value;
        email = document.getElementById('email').value;
        wachtOpslaan = document.getElementById("wachtwoord2").value;
        let person = {
            Voornaam: voornaam,
            Achternaam: achternaam,
            Wachtwoord: wachtOpslaan,
            EmailAdres: email,
        }
        fetch(apiUrl, {
            method: 'POST', // or 'PUT'
            headers: messageHeaders,
            body: JSON.stringify(person),
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
                //Ingelogd();
                window.location.replace("login.html");
                console.log('Success:', data);
                history.back();
            })
            .catch((error) => {
                NietKanInloggen();
                console.error('Error:', error);
            });
    }
    else {
        alert('Er ontbreekt nog informatie');
    }

}
function Ingelogd()
{
    alert('Je account is aangemaakt');

}
function NietKanInloggen()
{
    alert("Je hebt al een account gemaakt");
}

//btnRegisteren.addEventListener('click', SaveToLocalStorage);

function SaveToLocalStorage(event){
    event.preventDefault();
    let userInfos = [];
    if(inputSucceeded){
        let userInfo = {
            Voornaam : document.getElementById('voornaam').value,
            Achternaam : document.getElementById('achternaam').value,
            Email : document.getElementById('email').value,
            Wachtwoord : document.getElementById('wachtwoord').value
        }
        userInfos.push(userInfo);
        document.querySelector('form').reset();
        //for display
        console.warn("added", {userInfos});
        //alert(JSON.stringify(userInfos));
        localStorage.setItem('UserInfo', JSON.stringify(userInfos));
        const voornaam = document.getElementById('voornaam').value;
        localStorage.setItem('Voornaam', voornaam.textContent)
        window.location.replace("login.html");
        window.location.replace('../P1_OnlyStartPagina/OnlyStartPagina_1.html');
    }
    else {
        alert("Niet alle tekst zijn gevuld");
    }

}