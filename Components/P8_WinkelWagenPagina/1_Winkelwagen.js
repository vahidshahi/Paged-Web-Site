/* login en logout*/
let isloggedIn=false;
let btnLogin = document.getElementById('login');
let btnSignOut = document.getElementById('logout')
let totalItemsinbasket;
loggedInUserCheck();
function loggedInUserCheck(){
    let user = localStorage.getItem('klant')
    console.log(user)
    let userArray = JSON.parse(user);
    console.log(userArray);
    if (user){
isloggedIn=true;
        let pKlant = document.getElementById("naamVanKlant");
        pKlant.style.display = "inline-block";
        let name
        name = userArray.Voornaam
        if (name === undefined){  name = userArray.Voornaam }
        pKlant.textContent = "Hi, " + name;
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

document.getElementById('btnCheckout').addEventListener('click', openPagina)
document.getElementById('account-btn-footer').addEventListener('click', openAccPagina);

function openPagina() {
    if(isloggedIn === true){
        window.location.assign('2_checkoutPage.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
    }
}




function openAccPagina() {
    if(isloggedIn === true){
        window.location.assign('../P3_AccountPagina/AccountPagina.html')
    }
    else{
        window.location.assign('../P2_OnlyNewUser_Inlog/login.html')
    }
}





produchtenOpWinkelPagina()
onLoadCartNumbers();
function onLoadCartNumbers(){
    updatCartTotal()
    let productNumbers = localStorage.getItem('cardNumbers');
    if (productNumbers>0){
        document.getElementById('emptyCart').style.display="none";
        document.querySelector('.fas span').textContent= productNumbers ;

        document.getElementById('btnCheckout').style.display="block";
    }
    else {

        document.getElementById('emptyCart').style.display="block";
        document.querySelector('.fas span').textContent= productNumbers ;

        document.getElementById('btnCheckout').style.display="none";
    }
}
function produchtenOpWinkelPagina(){
    let productenInWinkelwagen_string = localStorage.getItem('boekenInWinkelWagen')
    let productenInWinkelwagen = JSON.parse(productenInWinkelwagen_string)
    productenInWinkelwagen.forEach(item =>{
let productContainer = document.getElementById('products')
            productContainer.innerHTML +=`
            <div class="product">
<button  class ="btn-remove" data-remove-button-target="${item.EAN}"><i class="gg-remove"></i></button>

<img alt="" class="bookImage" src="../../DataAssets/${item.SourceImg}">
<span class="name">${item.Titel}</span>
 
 
<div class="price">€${item.HuurPrijs}</div>

</div></div>`

            }
     )}

let removedItems = document.getElementsByClassName("btn-remove");
if (removedItems){
    removeItems();

}
function removeItems(){
for (let i = 0; i < removedItems.length; i++) {
    let button = removedItems[i];
    button.addEventListener('click', function (event) {
        let buttonClicked=event.target;
        buttonClicked.parentElement.parentElement.remove();


        updatCartTotal()
    })

}

    onLoadCartNumbers();
}


let boeken_string = localStorage.getItem('boekenInWinkelWagen')
let boeken = JSON.parse(boeken_string)
let eanVanBoek;
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
                localStorage.setItem('cardNumbers',  JSON.stringify(productsNumbers - 1));
                if (productsNumbers === 0){

                    document.getElementById('emptyCart').style.display="block";

                }

            }
        }
        removeItems()

    })
})

function updatCartTotal(){
    let cartItemContainer = document.getElementsByClassName('products-container')[0]
    let cartRows= cartItemContainer.getElementsByClassName('product')
    let total=0
    for (let i = 0; i < cartRows.length; i++){
        let cartRow=cartRows[i]
        let priceElement= cartRow.getElementsByClassName('price')[0]
        let price=parseFloat(priceElement.innerText.replace('€',''))
         total+=price


    }
    let totalItems=localStorage.getItem('cardNumbers')
    if (totalItems >= 1){
        totalItemsinbasket=totalItems.toString().concat(" boeken in cart ")
    }
    else if (totalItems === 1){
        totalItemsinbasket=totalItems.toString().concat(" boek in cart ")
    }
    else {
        totalItems=0;
        totalItemsinbasket=totalItems.toString().concat(" boek in cart ")
    }

    let lastTotal=totalItemsinbasket.concat(total);
    document.querySelector('.product-total span').textContent= lastTotal+' €';


}


onLoadCartNumbers();
updatCartTotal()



let klantNaamHover = document.getElementById('naamVanKlant');
klantNaamHover.onclick = function (){
    document.getElementById('account').style.display = "flex";
}
let account = document.getElementById('account')
account.onmouseleave = function (){
    document.getElementById('account').style.display = "none";
}
//let btnCheckout = document.getElementById('btnCheckout');
//btnCheckout.addEventListener('click', IfKlantIngelogd);
function IfKlantIngelogd()
{
    let user = localStorage.getItem('klant');
    let userArray = JSON.parse(user);
    if(user){
        // naar de checkout nemen
        console.log("er wordt geklikt")
    }
    else
    {
        console.log("eer wordt niet geklikt")
        window.location.href = "../P2_OnlyNewUser_Inlog/login.html"
    }

}

function KlantInfo()
{
    let user = localStorage.getItem('klant');
    let jsonUser = JSON.parse(user);
    if(user)
    {
        let deliveryAdresNode = document.createElement('h5');
        deliveryAdresNode.textContent = "Bezorgadres";
        document.querySelector('.klantInfo').appendChild(deliveryAdresNode);

        let naamNode = document.createElement('p');
        naamNode.textContent = jsonUser[0].Voornaam + " " + jsonUser[0].Achternaam;
        document.querySelector('.klantInfo').appendChild(naamNode);

        let adresNode = document.createElement('p');
        adresNode.textContent = jsonUser[0].Straatnaam + " " + jsonUser[0].Busnr;
        document.querySelector('.klantInfo').appendChild(adresNode);

        let adresNodeLijn2 = document.createElement('p');
        adresNodeLijn2.textContent =  jsonUser[0].Postcode + ", " + "BE";
        document.querySelector('.klantInfo').appendChild(adresNodeLijn2);

    }

}