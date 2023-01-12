let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout')
let isloggedIn = false
loggedInUserCheck();

function loggedInUserCheck(){
    let user = localStorage.getItem('klant')



    //console.log(user);
    if (user !== null){
        let userArray = JSON.parse(user);
       // document.getElementById('accountItem').style.display = "none";
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        let name
        name = userArray.Voornaam;  if(name === undefined){name = userArray[0].Voornaam}
        pKlant.textContent = "Hi, " + name;
        //let btnMaakEenAccount = document.getElementById('maakAccount2').style.display = "none";
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





document.getElementById('small-display-dropdown-accountBtn').addEventListener('click', openAccPagina);
document.getElementById('account-btn-footer').addEventListener('click', openAccPagina);



function openAccPagina() {
    if(isloggedIn === true){
        window.location.assign('../P3_AccountPagina/AccountPagina.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
    }
}