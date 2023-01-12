// schrijf functie render kalender
// geef mee welke maand
// op basis van van eerste dag daar beginnen met renderen
// var dt = new Date(year(2022), maand(0 :january)); // hier moet ik mijn maand hebben wat de gebruiker wilt
// var month = dt.getMonth();
// var year = dt.getFullYear();
// daysInMonth = new Date(year, month, 0).getDate();
//setFullYear voor Y-jaar te wijzigen

let isSelected = 0;
let dateSelectOne = null;
let dateSelectTwo = null;
let bestellingDatum = new Date()
let VerwachteReturnDatum = new Date()
let boek

let btnBevestigen = document.getElementById('btn-bevestigen');
let inhoud_selected_dates = '';
const array_maanden = [
    "January",
    "February",
    "Maart",
    "April",
    "Mei",
    "Juni",
    "July",
    "Augustus",
    "September",
    "Oktober",
    "November",
    "December"];
const array_maanden_short = [
    "Jan",
    "Feb",
    "Mrt",
    "Apr",
    "Mei",
    "Jun",
    "Jul",
    "Aug",
    "Sep",
    "Okt",
    "Nov",
    "Dec"];
let today = new Date(new Date().setHours(0,0,0,0,))
const currentDate = new Date();
//console.log(currentDate)
const maandIndex = currentDate.getMonth();
currentDate.setMonth(maandIndex + 1);
let boek_string = localStorage.getItem('boekNaarProductPage')
let boek_array = JSON.parse(boek_string)
boek = boek_array[0]
if(boek === undefined) {
    boek = boek_array
}
isBtnGrayI();




renderKalender(currentDate);
function getDaysOnKalPrivMaand(currentDateFirstDayIndex){
    let daysOnKalPrivMaand;
    // 1 ma   2 di   3 wo   4 do   5 vr    6 za   0 zo
    if(currentDateFirstDayIndex === 0){ daysOnKalPrivMaand = 6}
    if(currentDateFirstDayIndex === 1){ daysOnKalPrivMaand = 0}
    if(currentDateFirstDayIndex === 2){ daysOnKalPrivMaand = 1}
    if(currentDateFirstDayIndex === 3){ daysOnKalPrivMaand = 2}
    if(currentDateFirstDayIndex === 4){ daysOnKalPrivMaand = 3}
    if(currentDateFirstDayIndex === 5){ daysOnKalPrivMaand = 4}
    if(currentDateFirstDayIndex === 6){ daysOnKalPrivMaand = 5}
    return daysOnKalPrivMaand

}
function renderKalender(date){
    const maandIndex = date.getMonth();
    let maandindex = 0;
    console.log('maandIndex:', maandIndex)
    console.log('maandindex:', maandindex)
    if(maandIndex !== 0){
        maandindex = maandIndex - 1;
    }
    if(maandIndex === 0){
        maandindex = 11
    }
    console.log('maandindex:', maandindex)
    const jaarIndex = date.getFullYear();
    const kalenderMmaanden = document.getElementById('maand');
    kalenderMmaanden.innerHTML = array_maanden_short[maandindex]
    let daysInMonth = new Date(jaarIndex, maandIndex, 0).getDate();
    let daysInVorigeMonth = new Date(jaarIndex, maandIndex - 1, 0).getDate();
    //console.log(daysInMonth)
    const kalenderDagen = document.getElementById('dagen');
    let inhoudKalender = '';
    let aantaldagenOpKalender = 42;
    let a = 0;
    const currentDateFirstDayIndex = new Date(jaarIndex,maandIndex-1,1).getDay();    // 0 zo 1 ma 2 di 3 wo 4 do 5 vr 6 za
    let  daysOnKalPrivMaand = getDaysOnKalPrivMaand(currentDateFirstDayIndex);
    let valuediv = daysInVorigeMonth - daysOnKalPrivMaand + 1
    // daysOnKalPrivMaand = het aantal dagen op de kalender van vorige maand
    // valuediv = is het verschilt tussen de aantaldagen vorige maand (31)
    // en de dagen die op kalender voorkomen (5)
    // zolang als er dagen op kalender voorkomen
    for (let x = daysOnKalPrivMaand; x > 0; x--, a++ , valuediv++) {
       inhoudKalender += `<div data-maand-target="${new Date(jaarIndex,maandIndex-2,valuediv)}"> ${valuediv}</div>`;
    }
    // zolang als er hoeveel dagen er zijn in de maand
    for (let i = 1; i <= daysInMonth && a < aantaldagenOpKalender; i++, a++) {
     inhoudKalender += `<div data-maand-target="${new Date(jaarIndex,maandIndex-1,i)}">${i}</div>`;
    }
    // tot de kalender vol is 42 div's gevuld
    for (let d = 1; d <= aantaldagenOpKalender && a < aantaldagenOpKalender; d++) {
        inhoudKalender += `<div data-maand-target="${new Date(jaarIndex,maandIndex,d)}">${d}</div>`;
        a++;
    }
    kalenderDagen.innerHTML = inhoudKalender;
    boekDatumsVerhuurdBoek()
    createButtonEventlissener(maandIndex, date);
    daySelectorEvent()

}
function createButtonEventlissener(maand, date){
    const volgendeMaand = document.querySelector('.btn--right');
    const vorigenMaand = document.querySelector('.btn--left');
    function naarVolgendeMaand() {
        vorigenMaand.removeEventListener("click", handlePreviousClick);
        volgendeMaand.removeEventListener("click", handleNextClick);
        date.setMonth(maand - 1);
        renderKalender(date);
    }

    function naarVorigeMaand() {
        vorigenMaand.removeEventListener("click", handlePreviousClick);
        volgendeMaand.removeEventListener("click", handleNextClick);
        date.setMonth(maand + 1)
        renderKalender(date);
    }
    function handlePreviousClick() {

        naarVolgendeMaand()

    }

    function handleNextClick() {
        naarVorigeMaand()
    }
    vorigenMaand.addEventListener("click", handlePreviousClick)
    volgendeMaand.addEventListener("click", handleNextClick)

}
function boekDatumsVerhuurdBoek(){

    if (boek.boekStatus === "Verhuurd"){
        bestellingDatum = new Date(boek.BestellingDatum);
        VerwachteReturnDatum = new Date(boek.VerwachteReturnDatum);

        const kalenderDagen = document.querySelectorAll('[data-maand-target]')
        kalenderDagen.forEach(dag => {
            let date = Date.parse(dag.dataset.maandTarget)
            if (bestellingDatum < date && date < VerwachteReturnDatum) {
                dag.classList.add("boekRendedDays");
            }
            else if (+bestellingDatum === +date || +date === +VerwachteReturnDatum) {
                dag.classList.add("boekRendedFurstLastDay");
            }

        })
    }
}
function daySelectorEvent() {
    /*ander oplossing om 2 datums te vergelijken *//*
    kalenderDagen.forEach(dag =>{
       let date = new Date(Date.parse(dag.dataset.maandTarget)).toLocaleDateString("nl-BE")
       let currendDate = new Date().toLocaleDateString("nl-BE")
        console.log(date)
        console.log(currendDate)
       if(date === currendDate){
           dag.classList.add("today");
       }
    })*/
    const kalenderDagen = document.querySelectorAll('[data-maand-target]')
    kalenderDagen.forEach(dag =>{
        let date = new Date(Date.parse(dag.dataset.maandTarget))
        if(date < today){
            dag.classList.add("beforeToday");
        }
        if(+date === +today){
            dag.classList.add("today");
        }

    })
    kalenderDagen.forEach(dag => {
        dag.addEventListener('click', () => {
            isSelected++
            if (isSelected === 1) {
                dateSelectOne = new Date(Date.parse(dag.dataset.maandTarget))
                if(today < dateSelectOne){
                    if(dateSelectOne < bestellingDatum || VerwachteReturnDatum < dateSelectOne){
                        dag.classList.add("clicked");
                    }
                    else{
                        isSelected = 3
                        dateSelectOne = null
                    }
                }
                else{
                    isSelected = 3
                    dateSelectOne = null
                }
            }
            else if (isSelected === 2) {
                dateSelectTwo = new Date(Date.parse(dag.dataset.maandTarget))
                if(today < dateSelectTwo){
                    if(dateSelectTwo < bestellingDatum && dateSelectOne < bestellingDatum  || VerwachteReturnDatum < dateSelectTwo && VerwachteReturnDatum < dateSelectOne) {
                        if (dateSelectOne < dateSelectTwo) {
                            dag.classList.add("clicked");
                            isBtnGrayI()
                            kalenderDagen.forEach(dag => {
                                let date = Date.parse(dag.dataset.maandTarget)

                                if (dateSelectOne < date && date < dateSelectTwo) {
                                    dag.classList.add("selectedDays");
                                } else if (dateSelectOne === date || date === dateSelectTwo) {
                                    dag.classList.add("selectedFurstLastDay")
                                }
                            })
                        } else {
                            isSelected = 3;
                            dateSelectOne = null
                            dateSelectTwo = null
                        }
                    }
                    else {
                        isSelected = 3
                        dateSelectOne = null
                        dateSelectTwo = null
                    }
                }
               else{
                    isSelected = 3
                    dateSelectOne = null
                    dateSelectTwo = null
                }
            }
           if (isSelected >= 3) {
                kalenderDagen.forEach(dag => {
                    dag.classList.remove("selectedDays");
                    dag.classList.remove("selectedFurstLastDay");
                    dag.classList.remove("clicked");
                })
                isSelected = 0;
                dateSelectOne = null
                dateSelectTwo = null
               isBtnGrayI()
            }
            infoSelecedDatesOpPaginaTonene()
        })
    })
}

function infoSelecedDatesOpPaginaTonene(){
    const selectedDates = document.getElementById('selected_dates')
    if(dateSelectOne){
        const sOne_d = dateSelectOne.getDate();
        const sOne_mIndex = dateSelectOne.getMonth();
        const sOne_y = dateSelectOne.getFullYear();
        //console.log('dateSelectOne:', dateSelectOne.toLocaleDateString("nl-BE"))
        //console.log(sOne_d)
        //console.log(array_maanden[sOne_mIndex])
        //console.log(sOne_y)
        inhoud_selected_dates = `<div>inplannen van: ${sOne_d} ${array_maanden[sOne_mIndex]} ${sOne_y}  `

    }
    if(dateSelectTwo && dateSelectOne){
        const sTwo_d = dateSelectTwo.getDate();
        const sTwo_mIndex = dateSelectTwo.getMonth();
        const sTwo_y = dateSelectTwo.getFullYear();
        inhoud_selected_dates += `
            tot: ${sTwo_d} ${array_maanden[sTwo_mIndex]} ${sTwo_y}</div> `
            btnBevestigenEventlisener()  // button word hier pas geactiveed
    }
    if(dateSelectOne === null && dateSelectTwo === null) {
         inhoud_selected_dates = '';
    }
    selectedDates.innerHTML = inhoud_selected_dates;
}
function btnBevestigenEventlisener(){
    btnBevestigen.addEventListener('click' ,  datumsBevestigen);
}
function datumsBevestigen() {
    /*
    let jaara = dateSelectOne.getFullYear();
    let maanda = dateSelectOne.getMonth();
    let daga = dateSelectOne.getDate();
    boek.dateSelectOne = jaara + "-" + (maanda +1) + "-" + daga;
    let jaarb = dateSelectTwo.getFullYear();
    let maandb = dateSelectTwo.getMonth();
    let dagb = dateSelectTwo.getDate();
    boek.dateSelectTwo = jaarb + "-" + (maandb +1) + "-" + dagb;
*/

    boek.dateSelectOne = dateSelectOne
    boek.dateSelectTwo = dateSelectTwo
    console.log(boek);


    let boekenInDeWinkelmand = getProductsInWinkelwagen()
    let isInwinkelwagen = false
    boekenInDeWinkelmand.forEach(o => {
            if( o.EAN === boek.EAN){
                isInwinkelwagen = true
                alert('boek zit al in winkelwagen')
            }
        })
    if(isInwinkelwagen === false){
        alert('boek is Toegevoegd')
        boekenInDeWinkelmand.push(boek)
        document.querySelector('.fas span').innerHTML = JSON.stringify(boekenInDeWinkelmand.length);
        localStorage.setItem('cardNumbers',JSON.stringify(boekenInDeWinkelmand.length))
        let boekenInDeWinkelmand_sting = JSON.stringify(boekenInDeWinkelmand);
        localStorage.setItem( 'boekenInWinkelWagen', boekenInDeWinkelmand_sting);
    }

    isBtnGrayI()
    //isBtnGray()
}

function isBtnGrayI(){
    isBtnGray()
    let boekenInDeWinkelmand  = getProductsInWinkelwagen()
    if(!btnBevestigen.classList.contains('gray')){
        btnBevestigen.classList.add('gray')
    }
      console.log(boekenInDeWinkelmand.length)
    if(boekenInDeWinkelmand.length !== 0){
        let isInwinkelwagen = false;
        boekenInDeWinkelmand.forEach(o => {
            if(o.EAN === boek.EAN){
                isInwinkelwagen = true;
                if(!btnBevestigen.classList.contains('gray')){
                    btnBevestigen.classList.add('gray')
                }
            }
            else if(isInwinkelwagen === false) {
                if (btnBevestigen.classList.contains('gray') && dateSelectOne !== null && dateSelectTwo !== null) {
                    btnBevestigen.classList.remove('gray');

                }}
        })
    }
    else{
        if (btnBevestigen.classList.contains('gray') && dateSelectOne !== null && dateSelectTwo !== null) {
            btnBevestigen.classList.remove('gray');}
    }


}
function getProductsInWinkelwagen(){
    let productenInWinkelwagen_string = localStorage.getItem('boekenInWinkelWagen')
    let CheckWinkelMand = JSON.parse(productenInWinkelwagen_string)
    if(CheckWinkelMand !== null){
        document.querySelector('.fas span').textContent = CheckWinkelMand.length
        localStorage.setItem('cardNumbers',JSON.stringify(CheckWinkelMand.length))
        return CheckWinkelMand
    }
    else{
        return []
    }
}