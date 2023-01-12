let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout');
let total = 0
let totalItemsinbasket = '';
let isloggedIn = false;
loggedInUserCheck();
function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    console.log(user)
    let userArray = JSON.parse(user);
    console.log(userArray);
    let voornaam = userArray.Voornaam;
    if (user){
        isloggedIn = true;
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        pKlant.textContent = "Hi, " + voornaam;
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




let productenInWinkelwagen_string = localStorage.getItem('boekenInWinkelWagen')
console.log(productenInWinkelwagen_string)
let productenInWinkelwagen = JSON.parse(productenInWinkelwagen_string)
console.log(productenInWinkelwagen)
if(productenInWinkelwagen !== null){
    productenInWinkelwagen.forEach(item =>{
            let productContainer = document.getElementById('products')
            productContainer.innerHTML +=`
            <div class="product">


<img class="bookImage" src="../../DataAssets/${item.SourceImg}" alt="">
<span class="name">${item.Titel}</span>

 
<div class="price">€${item.HuurPrijs}</div>

</div></div>`


        })
}



function UpdateCartTotal(){
    let cartItemContainer = document.getElementsByClassName('container')[0]
    let cartRows= cartItemContainer.getElementsByClassName('product')
    total = 0
    for (let i = 0; i < cartRows.length; i++){
        let cartRow=cartRows[i]
        let priceElement= cartRow.getElementsByClassName('price')[0]
        let price=parseFloat(priceElement.innerText.replace('€',''))
         total+=price


    }
    let totalItems=localStorage.getItem('cardNumbers')
    if (totalItems>1){
        totalItemsinbasket = totalItems.toString().concat(" boeken in cart ")
    }
    else if (totalItems === 1){
        totalItemsinbasket = totalItems.toString().concat(" boek in cart ")
    }

let lastTotal = totalItemsinbasket.concat(total);
    document.querySelector('.product-total span').textContent= lastTotal+' €';


}
UpdateCartTotal()

function cancelOreder(){
    let isExecuted = confirm("weet je zeker dat je de bestelling wilt annuleren?");
    if (isExecuted){
        localStorage.removeItem('boekenInWinkelWagen');
        localStorage.removeItem('cardNumbers')
       window.location.replace( "../P1_OnlyStartPagina/OnlyStartPagina_1.html")


    }
}

/*Get user ino*/


function showCustomerInfo(){
    document.getElementById('adres').style.display="none";
let customer = localStorage.getItem('klant')
let loggedInCustomer = JSON.parse(customer)

    if (loggedInCustomer.postcode===null){
        alert("You should add your address",)
    }
    else {

    let productContainer = document.getElementById('left-container')
    productContainer.innerHTML +=`
            <div class="klantInfo">
<div class="voornaam">To:<br> Naam :${loggedInCustomer.Voornaam}</div>
<div class="achternaam">   Achternaam  :${loggedInCustomer.Achternaam}</div>
<div class="straatnaam">Straatnaam   :${loggedInCustomer.Straatnaam} HuisNr   :${loggedInCustomer.Huisnr}</div>
<div class="gemeente">Gemeente  :${loggedInCustomer.gemeente}</div>
<div class="postcode">Postcode  :${loggedInCustomer.postcode} </div>
</div>`}}



document.getElementById('account-btn-footer').addEventListener('click', openAccPagina);
function openAccPagina() {
    if(isloggedIn === true){
        window.location.assign('../P3_AccountPagina/AccountPagina.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
    }
}





