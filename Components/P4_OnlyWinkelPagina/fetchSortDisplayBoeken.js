

const apiUrlAllBoeken = 'https://localhost:44397/api/Boeken';
const apiUrlVerhuurde = 'https://localhost:44397/api/verhuurdeBoeken';
let allBoeken = [];
let verhuurdeBoeken = [];
let boeken = [];
let gefilterdeBoeken = [];
let selectedCatogorie = 'alles';
let selectedAuteur = 'alles';
let CardLinkTrigger;
let BtnHuurTrigger;
let boekStatus;
let BoekenInDeWinkelmand = []
let gefilterdZoekResultaat
let i = 0
// for de zoekbalk
let uniekeBoeken;
function checkZoekopdracht(){
    let zoekopdracht = JSON.parse(localStorage.getItem('zoekopdracht'))
    if(zoekopdracht !== null){
        gefilterdZoekResultaat = boeken.filter(boek => {
            return boek.Titel.toLowerCase().includes(zoekopdracht)
                || boek.Auteur.toLowerCase().includes(zoekopdracht)
                || boek.Categorie.toLowerCase().includes(zoekopdracht)
        })
        uniekeBoeken = gefilterdZoekResultaat.concat(boeken).filter((value, index, self) => {
            return self.findIndex(boek => boek.EAN === value.EAN) === index;
        })
        createBoekenCards(uniekeBoeken)
        localStorage.removeItem('zoekopdracht')
    }
    else {
        createBoekenCards(boeken)
    }
}

const zoekInputActive = document.getElementById('zoekbalk')
zoekInputActive.addEventListener('input', e =>{
    const inputValue =  e.target.value.toLowerCase()
    gefilterdZoekResultaat = boeken.filter(boek => {
        return boek.Titel.toLowerCase().includes(inputValue)
            || boek.Auteur.toLowerCase().includes(inputValue)
            || boek.Categorie.toLowerCase().includes(inputValue)

    })
    //console.log(boeken);
    uniekeBoeken = gefilterdZoekResultaat.concat(boeken).filter((value, index, self) => {
        return self.findIndex(boek => boek.EAN === value.EAN) === index;
    })
    ClearCardContainer()

})
function ClearCardContainer(){
    document.getElementsByClassName('grind-card-container')[0].remove();
    createBoekenCards(uniekeBoeken)

}

function createCatogorieSelect() {
    const catogorieen = ['alles','Fantasy', 'Kinderboeken', 'Tienerboeken','Young adult boeken', 'Romans', 'Romantische boeken', 'Trillers', 'Strips'];



    let select = document.createElement('select');
    select.name = 'catogorie';


    catogorieen.forEach(catogorie => {
        let option = document.createElement('option');
        option.value = catogorie;
        option.innerText = catogorie;
        select.appendChild(option);
    });

    select.addEventListener('change', firststepCato);
    let filterbox = document.getElementById('sorteerder')
    let div = document.createElement('div');
    div.innerHTML += `<div>${select.name}</div>`
    div.appendChild(select);
    filterbox.appendChild(div)

}
function createAuteurSelect(boeken) {
    let auteurs = [];

    //console.log(boeken)
    boeken.forEach(boek =>{
        let a = boek.Auteur;
        auteurs.push(a)
    })
    //console.log(auteurs)
    let uniekeAuteurs = auteurs.sort().reduce(function(a, b){
        if (b !== a[0]) a.unshift(b); return a }, [])
    //console.log(uniekeAuteurs)
    uniekeAuteurs.unshift('alles')


    let select = document.createElement('select');
    select.name = 'auteurs';

    uniekeAuteurs.forEach(auteur => {
        let option = document.createElement('option');
        option.value = auteur;
        option.innerText = auteur;
        select.appendChild(option);
    });

    select.addEventListener('change', firststepAut);
    let filterbox = document.getElementById('sorteerder')
    let div = document.createElement('div');
    div.innerHTML += `<div>${select.name}</div>`
    div.appendChild(select);
    filterbox.appendChild(div)

}
function firststepCato(){
    document.getElementsByClassName('grind-card-container')[0].remove();
    filterArrayCatogorie()
}
function firststepAut(){
    document.getElementsByClassName('grind-card-container')[0].remove();
    filterArrayAuteurs()
}
function filterArrayCatogorie() {

    selectedCatogorie = document.getElementsByName('catogorie')[0].value;
    if (selectedCatogorie === 'alles') {
        gefilterdeBoeken = boeken
    }
    else {
        gefilterdeBoeken = boeken.filter(boek => {
            return boek.Categorie === selectedCatogorie;
        })}
    createBoekenCards(gefilterdeBoeken)


}
function filterArrayAuteurs() {
 //   document.getElementsByClassName('grind-card-container')[0].remove();
    selectedAuteur = document.getElementsByName('auteurs')[0].value;
    if (selectedAuteur === 'alles') {
        gefilterdeBoeken = boeken
    }
    else {
        gefilterdeBoeken = boeken.filter(boek => {
            return boek.Auteur === selectedAuteur;
        })}
    createBoekenCards(gefilterdeBoeken)


}



function berekenStausBoek(boek){
    let bestellingdatum = null;
    let verwachteRetundatum = null;
    let returnDatum = null
    let datumVandaag = new Date().setHours(0,0,0,0)
    if (boek.BestellingDatum !== null){
        bestellingdatum = new Date(boek.BestellingDatum).setHours(0,0,0,0)
    }
    if (boek.VerwachteReturnDatum !== null){
        verwachteRetundatum = new Date(boek.VerwachteReturnDatum).setHours(0,0,0,0)
    }
    if (boek.ReturnDatum !== null){
        returnDatum = new Date(boek.ReturnDatum).setHours(0,0,0,0)
    }
    if(bestellingdatum === null && verwachteRetundatum === null && returnDatum === null){
        // alles nog null -> New boek
        boekStatus = "Beschikbaar"
        return boekStatus
    }
    if(returnDatum !== null){
        boekStatus = "Beschikbaar"
        return boekStatus
    }
    if(bestellingdatum !== null){
        if(+bestellingdatum < +datumVandaag && returnDatum !== null){
            // oude bestelling
            boekStatus = "Beschikbaar"
            return boekStatus
        }
        if(+bestellingdatum >= +datumVandaag && +verwachteRetundatum > +datumVandaag){
            //  bestelling in de toekomst
            boekStatus = "Verhuurd"
            return boekStatus
        }
        if(+bestellingdatum <= +datumVandaag && +verwachteRetundatum >= +datumVandaag){
            // boek is nog niet terug
            boekStatus = "Verhuurd"
            return boekStatus
        }

         if(+bestellingdatum < +datumVandaag && +verwachteRetundatum <= +datumVandaag && returnDatum === null ){
            // oude bestelling - boek is nog niet terug (overdatum)
            boekStatus = "Verhuurd"
            return boekStatus
        }
    }


}
function SorteerDeArrayBoeken(boeken){
    //console.log(boeken)
    boeken.forEach(boek => {
        boek.boekStatus = berekenStausBoek(boek)
    })
    let verhuurdeUniekeBoeken = boeken.filter((value, index, self) => {
        return self.findIndex(boek => boek.EAN === value.EAN && boek.boekStatus === "Verhuurd") === index;
    })
    let alleUniekeBoeken = boeken.filter((value, index, self) => {
        return self.findIndex(boek => boek.EAN === value.EAN && boek.boekStatus === "Beschikbaar") === index;
    })
    //console.log(boeken , boeken.length)
    //console.log(verhuurdeUniekeBoeken, alleUniekeBoeken.length);
    //console.log(alleUniekeBoeken, alleUniekeBoeken.length);
    let uniekeGesorteerdeBoeken = verhuurdeUniekeBoeken.concat(alleUniekeBoeken).filter((value, index, self) => {
        return self.findIndex(boek => boek.EAN === value.EAN) === index;
    })

    return shuffle(uniekeGesorteerdeBoeken)

}
function shuffle(uniekeGesorteerdeBoeken) {
    let currentIndex = uniekeGesorteerdeBoeken.length,  randomIndex;
    while (currentIndex !== 0) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;
        [uniekeGesorteerdeBoeken[currentIndex], uniekeGesorteerdeBoeken[randomIndex]] = [
            uniekeGesorteerdeBoeken[randomIndex], uniekeGesorteerdeBoeken[currentIndex]];}

    return uniekeGesorteerdeBoeken;
}
function createBoekenCards(boeken) {
   // console.log(boeken)
    const pagina = document.getElementById('start');
    let cardContainer = document.createElement('div');
    cardContainer.classList.add('grind-card-container');
    pagina.appendChild(cardContainer);
    boeken.forEach(boek => {
        let indexButton = "Huur nu"
        BoekenInDeWinkelmand = getProductsInWinkelwagen()
        if (boek.boekStatus === "Verhuurd"){
            indexButton = 'Inplannen'
        }
        BoekenInDeWinkelmand.forEach(o => {
           if(o.EAN === boek.EAN ) { indexButton = 'Toegevoegd'; }
        })



        cardContainer.innerHTML += `
       <div class="card">
             <a class="card__link" id="post-EAN" data-ean-target="${boek.EAN}" href="../../Components/P5_OnlyProductPagina/OnlyProductPagina_1.html">
                <div class="card__img"  >
                   <img src="../../DataAssets/${boek.SourceImg}" alt="">
                   <div class="status ${boek.boekStatus}">${boek.boekStatus}</div>
                </div>
              </a>
            <div class="card__info">
               <div class="innerbox-card__info">
                  <div class="auteur">${boek.Auteur}</div>
                  <div class="title">${boek.Titel}</div>
                  </div>
               <button class="${indexButton.slice(0,4)}" data-huur-button-target="${boek.EAN}">${indexButton}</button>
            </div>
       </div> `
    })

    createCardLinkEventLister(boeken)


}
function createCardLinkEventLister(boeken) {
    const cardsEan = document.querySelectorAll('[data-ean-target]')
    cardsEan.forEach(button => {
        button.addEventListener('click', () => {
            const ean = button.dataset.eanTarget
            CardLinkTrigger = boeken.filter(boek => {
                return boek.EAN === ean;
            })
            let boek_sting = JSON.stringify(CardLinkTrigger[0])
            localStorage.setItem('boekNaarProductPage', boek_sting);

        })
    })
    createHuurButtonEvenListener(boeken)
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
function createHuurButtonEvenListener(boeken) {
    const huurButtons = document.querySelectorAll('[data-huur-button-target]')
    //BoekenInDeWinkelmand = getProductsInWinkelwagen()
    huurButtons.forEach(button => {
        button.addEventListener('click', () => {
            BoekenInDeWinkelmand = getProductsInWinkelwagen()
            const ean = button.dataset.huurButtonTarget
            BtnHuurTrigger = boeken.find(boek => {
                return boek.EAN === ean;
            })
            let isInwinkelwagen = false
            if (BtnHuurTrigger.boekStatus === "Beschikbaar"){
                BoekenInDeWinkelmand.forEach(o => {
                    if( o.EAN === BtnHuurTrigger.EAN){

                        isInwinkelwagen = true

                    }
                })
            if( isInwinkelwagen === false) {
                    BoekenInDeWinkelmand.push(BtnHuurTrigger)
                    button.innerHTML = 'is toegevoegd'
                   // console.log(BoekenInDeWinkelmand.length)
                    document.querySelector('.fas span').textContent = JSON.stringify(BoekenInDeWinkelmand.length);
                    localStorage.setItem('cardNumbers',JSON.stringify(BoekenInDeWinkelmand.length))
                    let BoekenInDeWinkelmand_sting = JSON.stringify(BoekenInDeWinkelmand)
                    localStorage.setItem('boekenInWinkelWagen', BoekenInDeWinkelmand_sting);
                }
            }
            else{
                isInwinkelwagen = false
                BoekenInDeWinkelmand.forEach(o => {
                    if( o.EAN === BtnHuurTrigger.EAN){
                        isInwinkelwagen = true
                    }
                })
                if( isInwinkelwagen === false) {
                    let boek_sting = JSON.stringify(BtnHuurTrigger)
                    localStorage.setItem('boekNaarProductPage', boek_sting);
                    window.location.assign('../../Components/P5_OnlyProductPagina/OnlyProductPagina_1.html')
                }
            }

        })
    })
}

function validateResponse(response) {
    //console.log(response)
    if (!response.ok) {
        console.log(' a problem:');
        throw Error(response.statusText); // (2)
    }
    else{
        console.log('succes')
        return response;
    }
}
function readResponseAsJSON(response) {
    return response.json(); // (1)
}
function logError(error) {
    console.log('Looks like there was a problem:', error);
}
/*
fetch(apiUrlAllBoeken) // pad van de bron ingeven
    .then(validateResponse) // (3)
    .then(readResponseAsJSON) // (4)
    .then(logAllBoekenResult) // (5)
    .catch(logError); // (6)*/
fetch(apiUrlVerhuurde) // pad van de bron ingeven
    .then(validateResponse) // (3)
    .then(readResponseAsJSON) // (4)
    .then(logResult) // (5)
    .catch(logError); // (6)*/

function logAllBoekenResult(result){
    allBoeken = result
    if(verhuurdeBoeken !== [] && i === 1) {logResult(); i = 0} else {i = 1}
}
function logVerhuurdeBoekenResult(result){
    verhuurdeBoeken = result
    if(allBoeken !== []  && i === 1) {logResult()} else {i = 1}
}
function logResult(result) {
    createCatogorieSelect()
    boeken = SorteerDeArrayBoeken(result)
    checkZoekopdracht(boeken)
    createAuteurSelect(boeken)
    getProductsInWinkelwagen()
}


