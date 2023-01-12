// schrijf functie render kalender
// geef mee welke maand
// op basis van van eerste dag daar beginnen met renderen
// var dt = new Date(year(2022), maand(0 :january)); // hier moet ik mijn maand hebben wat de gebruiker wilt
// var month = dt.getMonth();
// var year = dt.getFullYear();
// daysInMonth = new Date(year, month, 0).getDate();
//setFullYear voor Y-jaar te wijzigen
let eersteGeselecteerdeDag;
let eersteGeselecteerdeMaand;
let tweedeGeselecteerdeDag;
let tweedeGeselecteerdeMaand;
let isSelected = 0
const array_maanden = [
    "January",
    "February",
    "Maart",
    "April",
    "Mei",
    "Juni",
    "July",
    "Agustus",
    "September",
    "Oktober",
    "November",
    "December"]
const currentDate = new Date();
renderKalender(currentDate);



function renderKalender(date) {
    const maand = date.getMonth();
    const jaar = date.getFullYear();
    const firstDayIndex = date.getDay();

    const maanden = document.getElementById('maand');
    let maandindex = 0;
    if(maand !== 0){
        maandindex = maand - 1;
    }
    maanden.innerHTML = array_maanden[maandindex] //

    let daysInMonth = new Date(jaar, maand, 0).getDate();
    const dagen = document.getElementById('dagen');
    let days = '';
    let a = 0;
    let aantaldagenOpKalender = 42;
    for (let x = firstDayIndex; x > 0; x--, a++) {
        days += `<div data-maand-target="${maand - 2}">${daysInMonth - x + 1} </div>`;
    }
    for (let i = 1; i <= daysInMonth && a < aantaldagenOpKalender; i++, a++) {
        days += `<div data-maand-target="${maand - 1}">${i}</div>`;
    }
    for (let d = 1; d <= (aantaldagenOpKalender - (daysInMonth)) && a < aantaldagenOpKalender; d++) {
        days += `<div data-maand-target="${maand}">${d}</div>`;
        a++;
    }
    dagen.innerHTML = days;
    boekDatumsVerhuurdBoek()
    daySelectorEvent();
    createButtonEventlissener(maand, date);

}


function createButtonEventlissener(maand, date) {

    const volgendeMaand = document.querySelector('.btn--right');
    const vorigenMaand = document.querySelector('.btn--left');
    function naarVolgendeMaand() {
        //console.log(date)   // console ???
        vorigenMaand.removeEventListener("click", handlePreviousClick);
        volgendeMaand.removeEventListener("click", handleNextClick);

        date.setMonth(maand - 1);
        renderKalender(date);
    }

    function naarVorigeMaand() {
        //console.log(date)   // console ???
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
function daySelectorEvent() {
    const kalenderDagen = document.querySelectorAll('[data-maand-target]')
    kalenderDagen.forEach(dag => {
        dag.addEventListener('click', () => {

            isSelected++
            if (isSelected === 1) {
                eersteGeselecteerdeDag = parseInt(dag.innerHTML);
                eersteGeselecteerdeMaand = parseInt(dag.dataset.maandTarget)
            }
            dag.classList.add("selected");
            if (isSelected === 2) {
                tweedeGeselecteerdeDag = parseInt(dag.innerHTML);
                tweedeGeselecteerdeMaand = parseInt(dag.dataset.maandTarget)
                kalenderDagen.forEach(dag => {
                    let maandNr = parseInt(dag.dataset.maandTarget);
                    let dagNr = parseInt(dag.innerHTML);
                    if (maandNr === eersteGeselecteerdeMaand && maandNr === tweedeGeselecteerdeMaand && eersteGeselecteerdeDag < tweedeGeselecteerdeDag) {
                        if (eersteGeselecteerdeDag < dagNr && dagNr < tweedeGeselecteerdeDag) {
                            dag.classList.add("selected--gray");
                        }
                    }
                    if (eersteGeselecteerdeMaand + 1 === tweedeGeselecteerdeMaand) {
                        if (eersteGeselecteerdeDag < dagNr && maandNr === eersteGeselecteerdeMaand) {
                            dag.classList.add("selected--gray");
                        }
                        if (dagNr < tweedeGeselecteerdeDag && maandNr === tweedeGeselecteerdeMaand) {
                            dag.classList.add("selected--gray");
                        }
                    }
                    if (eersteGeselecteerdeMaand + 2 === tweedeGeselecteerdeMaand) {
                        if (eersteGeselecteerdeDag < dagNr && maandNr === eersteGeselecteerdeMaand) {
                            dag.classList.add("selected--gray");
                        }
                        if (dagNr < tweedeGeselecteerdeDag && maandNr === tweedeGeselecteerdeMaand) {
                            dag.classList.add("selected--gray");
                        }
                        if (maandNr - 1 === eersteGeselecteerdeMaand) {
                            dag.classList.add("selected--gray");
                        }
                    }

                })
                datumsVerzamelen()
            }
            if (isSelected >= 3) {
                kalenderDagen.forEach(dag => {
                    dag.classList.remove("selected");
                    dag.classList.remove("selected--gray");
                })
                isSelected = 0;
            }
        })
    })
}
function boekDatumsVerhuurdBoek(){
    let boek_string = localStorage.getItem('boekNaarProductPage')
    let boek_array = JSON.parse(boek_string)
    let boek = boek_array[0]
    console.log(boek)
    if (boek.boekStatus === "Verhuurd"){
       // const verwachteReturnDatum = new Date(boek.VerwachteReturnDatum).toLocaleDateString("nl-BE")
       // const bestellingDatum = new Date(boek.BestellingDatum).toLocaleDateString("nl-BE")
        const verwachteReturnDatum = new Date(boek.VerwachteReturnDatum)
        const bestellingDatum = new Date(boek.BestellingDatum)
        console.log(verwachteReturnDatum)
        console.log(bestellingDatum)
        const x = new Date(boek.BestellingDatum);
        const y = new Date(boek.VerwachteReturnDatum);


        console.log('x < y', x < y); // true
        console.log('x > y', x > y); // false
        console.log('x <= y', x <= y); // true
        console.log('x >= y', x >= y); // false
        console.log('+x === +y', +x === +y); // false


        const maandverwachteReturnDatum = verwachteReturnDatum.getMonth();
      //  const jaarverwachteReturnDatum = verwachteReturnDatum.getFullYear();
        const dagverwachteReturnDatum = verwachteReturnDatum.getDay();
        const maandbestellingDatum = bestellingDatum.getMonth();
       // const jaarbestellingDatum = bestellingDatum.getFullYear();
        const dagbestellingDatum = bestellingDatum.getDay();
        const kalenderDagen = document.querySelectorAll('[data-maand-target]')
        kalenderDagen.forEach(dag => {
            let maandNr = parseInt(dag.dataset.maandTarget);
            let dagNr = parseInt(dag.innerHTML);

            if (maandNr === maandbestellingDatum && maandNr === maandverwachteReturnDatum && dagbestellingDatum < dagverwachteReturnDatum) {
                if (dagbestellingDatum < dagNr && dagNr < dagverwachteReturnDatum) {
                    dag.classList.add("selected--gray");
                }
            }
            if (maandbestellingDatum + 1 === maandverwachteReturnDatum) {
                if (dagbestellingDatum < dagNr && maandNr === maandbestellingDatum) {
                    dag.classList.add("selected--gray");
                }
                if (dagNr < dagverwachteReturnDatum && maandNr === maandverwachteReturnDatum) {
                    dag.classList.add("selected--gray");
                }
            }
            if (maandbestellingDatum + 2 === maandverwachteReturnDatum) {
                if (dagbestellingDatum < dagNr && maandNr === maandbestellingDatum) {
                    dag.classList.add("selected--gray");
                }
                if (dagNr < dagverwachteReturnDatum && maandNr === maandverwachteReturnDatum) {
                    dag.classList.add("selected--gray");
                }
                if (maandNr - 1 === maandbestellingDatum) {
                    dag.classList.add("selected--gray");
                }
            }



        })

    }
}


function datumsVerzamelen() {
    let gesilecteerdeDatum = document.querySelectorAll('.selected')
    gesilecteerdeDatum.forEach(day => {
        console.log(day.innerHTML)  // 11
        let dag = day.innerHTML
        console.log(array_maanden[day.dataset.maandTarget])
        let maand = parseInt(day.dataset.maandTarget) // 2
        const jaar = new Date().getFullYear()
        const huurdatum = new Date(jaar , maand, dag );
        console.log(huurdatum)

    })
}


