
let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout')
let isLoggedIn = false;
let name;
loggedInUserCheck();
function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    console.log(user)
    let userArray = JSON.parse(user);
    console.log(userArray);
    if (user){
        isLoggedIn = true
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        name = userArray.Voornaam;  if(name === undefined){name = userArray[0].Voornaam}
        pKlant.textContent = "Hi, " + name;
        document.getElementById('p1MaakAccountButton').style.display = "none"
        let headingMaakEenAccount = document.getElementById('p1MaakAccountHeading')
        headingMaakEenAccount.innerHTML = `<div> Geniet</div>`
        headingMaakEenAccount.innerHTML += `<div> Van</div>`
        headingMaakEenAccount.innerHTML += `<div> Voordelen</div>`
        headingMaakEenAccount.classList.add('isIngelogde')
       let sectionMaakEenAccount =  document.getElementById('maak-een-account')
        sectionMaakEenAccount.classList.add('isDisplay')
        btnLogin.style.display = "none";
        btnSignOut.style.display = "inline-block";
    }
    else {
        document.getElementById("naamVanKlant").style.display = "none";
    }
}

document.getElementById('small-display-dropdown-accountBtn').addEventListener('click', openPagina)
function openPagina() {
    if(isLoggedIn === true){
        window.location.assign('../P3_AccountPagina/AccountPagina.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
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





