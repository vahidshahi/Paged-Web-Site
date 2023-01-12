
document.getElementById("zoek-icon").addEventListener("click", openZoekbalk);
function openZoekbalk(){
    document.getElementById("zoekbalk").classList.toggle("active")

}

document.getElementById("small-display-btn").addEventListener("click", openMenu);
function openMenu(){
    document.getElementById("small-display-content").classList.toggle("active")

}
getProductsInWinkelwagen()
function getProductsInWinkelwagen(){
    let productenInWinkelwagen_string = localStorage.getItem('boekenInWinkelWagen')
    let CheckWinkelMand = JSON.parse(productenInWinkelwagen_string)
    if(CheckWinkelMand !== null){
        document.querySelector('.fas span').textContent = CheckWinkelMand.length
    }
}


/*
document.getElementById("account-btn").addEventListener("click", openAccountMenu);
function openAccountMenu(){
    document.getElementById("dropdown-login").classList.toggle("active")

}
document.getElementById("dropdown-account-btn").addEventListener("click", openDropAccountMenu);
function openDropAccountMenu(){
    document.getElementById("dropdown-login").classList.toggle("active")

}*/


