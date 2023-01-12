


window.onload = function() {
    let boek_string = localStorage.getItem('boekNaarProductPage')
    let boek = JSON.parse(boek_string)
    console.log(boek)
    boekOnPage(boek)
}
let huurbtn = document.getElementById('btn-winkelwagen')
huurbtn.addEventListener("click", createHuurButtonEvenListener)
document.getElementById('omschrijving-dropdown').addEventListener( "click", openOmschrijving);
document.getElementById('dropdown-info-tabel').addEventListener( "click", openTabel);
let hetBoek
function openTabel(){
    document.getElementById("dropdown-content-info-tabel").classList.toggle("drop")
    document.getElementById('dropdown-info-tabel').classList.toggle("active")

}
function openOmschrijving(){
    document.getElementById("omschrijving-dropdown-content").classList.toggle("drop")
    document.getElementById('omschrijving-dropdown').classList.toggle("active")
}
function getProductsInWinkelwagen(){
    let productenInWinkelwagen_string = localStorage.getItem('boekenInWinkelWagen')
    let CheckWinkelMand = JSON.parse(productenInWinkelwagen_string)
    if(CheckWinkelMand !== null){
        document.querySelector('.fas span').textContent = CheckWinkelMand.length
        return CheckWinkelMand
    }
    else{
        return []
    }
}
function isBtnGray(){
    if(hetBoek === undefined){hetBoek = boek}
    let boekenInDeWinkelmand  = getProductsInWinkelwagen()
    let isInwinkelwagen = false
    boekenInDeWinkelmand.forEach(o => {
        isInwinkelwagen = o.EAN === hetBoek.EAN;
    })
    if(isInwinkelwagen === true){
        if(!huurbtn.classList.contains('gray')){
            huurbtn.classList.add('gray')
        }}
    else{
    if (huurbtn.classList.contains('gray')) {
        huurbtn.classList.remove('gray')
    }}
    if (hetBoek.boekStatus === "Verhuurd"){
        if   (!huurbtn.classList.contains('gray')){
            huurbtn.classList.add('gray')
        }
    }

}


function boekOnPage(boek){
         hetBoek = boek;
          isBtnGray();
        document.getElementById('DBI-img').src = `../../DataAssets/${boek.SourceImg}`;
        document.getElementById('DBI-titel').innerHTML  = `${boek.Titel}`;
        document.getElementById('DBI-auteur').innerHTML = `${boek.Auteur}`;
        document.getElementById('DBI-prijs').innerHTML = `huurprijs: € ${boek.HuurPrijs}`;
        document.getElementById('DBI-auteur2').innerHTML = `${boek.Auteur}`;
        document.getElementById('DBI-uitgever').innerHTML = `${boek.Uitgeverij}`;
        document.getElementById('DBI-blz').innerHTML = `${boek.Aantalbladzijden}`;
        document.getElementById('DBI-taal').innerHTML = `${boek.Taal}`;
        document.getElementById('DBI-ean').innerHTML = `${boek.EAN}`;
        document.getElementById('DBI-uitvoering').innerHTML = `${boek.Uitvoering}`;
        document.getElementById('DBI-gewicht').innerHTML = `${boek.Gewicht} g`;
        document.getElementById('DBI-omschrijving').innerHTML = `${boek.Omschrijving}`;
}


function createHuurButtonEvenListener(){
    let boekenInDeWinkelmand  = getProductsInWinkelwagen()
        if(hetBoek.boekStatus === "Beschikbaar"){
            let isInwinkelwagen = false
                boekenInDeWinkelmand.forEach(o => {
                    if( o.EAN === hetBoek.EAN){
                        isInwinkelwagen = true;
                        alert('boek zit al in je mandje')
                    }
                })
               if(isInwinkelwagen === false){
                   alert('boek is toegevoegd aan je mandje')
                   boekenInDeWinkelmand.push(hetBoek)
                   document.querySelector('.fas span').innerHTML = JSON.stringify(boekenInDeWinkelmand.length);
                   localStorage.setItem('cardNumbers',JSON.stringify(boekenInDeWinkelmand.length))
                   let boekenInDeWinkelmand_sting = JSON.stringify(boekenInDeWinkelmand);
                   localStorage.setItem( 'boekenInWinkelWagen', boekenInDeWinkelmand_sting);
                   let btnBev = document.getElementById('btn-bevestigen')
                   if(!btnBev.classList.contains('gray')){
                       btnBev.classList.add('gray')
                   }

               }}
   isBtnGray()
}


