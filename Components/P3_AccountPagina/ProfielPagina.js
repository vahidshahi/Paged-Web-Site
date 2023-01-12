
window.onload = function() {
    openMijnSettingsMenu()
}

document.getElementById("btn-mijn-boeken").addEventListener("click", openMijnBoekenMenu);
function openMijnBoekenMenu(){

    if(document.getElementById("section-mijn-geschiedenis").classList.contains("active")){
        document.getElementById("section-mijn-geschiedenis").classList.remove("active")
        document.getElementById("btn-mijn-geschiedenis").classList.remove("active")
    }
    if(document.getElementById("section-profiel-settings").classList.contains("active")){
        document.getElementById("section-profiel-settings").classList.remove("active")
        document.getElementById("btn-mijn-profiel").classList.remove("active")
    }
    document.getElementById("section-mijn-boeken").classList.add("active")
    document.getElementById("btn-mijn-boeken").classList.add("active")

}
document.getElementById("btn-mijn-profiel").addEventListener("click", openMijnSettingsMenu);
function openMijnSettingsMenu(){
    if(document.getElementById("section-mijn-geschiedenis").classList.contains("active")){
        document.getElementById("section-mijn-geschiedenis").classList.remove("active")
        document.getElementById("btn-mijn-geschiedenis").classList.remove("active")
    }
    if(document.getElementById("section-mijn-boeken").classList.contains("active")){
        document.getElementById("section-mijn-boeken").classList.remove("active")
        document.getElementById("btn-mijn-boeken").classList.remove("active")
    }

    document.getElementById("section-profiel-settings").classList.add("active")
    document.getElementById("btn-mijn-profiel").classList.add("active")

}

document.getElementById("btn-mijn-geschiedenis").addEventListener("click", openMijnGeschiedenisMenu);
function openMijnGeschiedenisMenu(){
    if(document.getElementById("section-mijn-boeken").classList.contains("active")){
        document.getElementById("section-mijn-boeken").classList.remove("active")
        document.getElementById("btn-mijn-boeken").classList.remove("active")
    }
    if(document.getElementById("section-profiel-settings").classList.contains("active")){
        document.getElementById("section-profiel-settings").classList.remove("active")
        document.getElementById("btn-mijn-profiel").classList.remove("active")
    }
    document.getElementById("section-mijn-geschiedenis").classList.add("active")
    document.getElementById("btn-mijn-geschiedenis").classList.add("active")

}









/*

let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout')


function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    console.log(user)
    let userArray = JSON.parse(user);
    console.log(userArray);
    if (user){
        //document.getElementById('accountItem').style.display = "none";
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        pKlant.textContent = "Hi, " + userArray[0].Voornaam;
        //let btnMaakEenAccount = document.getElementById('maakAccount2').style.display = "none";
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
}*/
