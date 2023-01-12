// selecteren van de elementen die we gebruiken

//const modalfooter = document.getElementsByClassName('modal-footer')
const openModalButtons = document.querySelectorAll('[data-modal-target]')  //voor de modal open btn
const annuleerModalButtons = document.querySelectorAll('[data-close-button-target]')  // voor de modal close btn
const overlay = document.getElementById('overlay')   // voor de overlay
let modal;
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
    "December"];
createMaandenSelect()
function createMaandenSelect(){
    let select = document.createElement('select');
    select.name = 'maanden';

    array_maanden.forEach(m => {
        let option = document.createElement('option');
        option.value = m;
        option.innerText = m;
        select.appendChild(option);
    });

    let filterbox = document.getElementById('DBT-maand')
    filterbox.appendChild(select);
}


// //voor de model open btn
openModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        modal = document.querySelector(button.dataset.modalTarget)
        openModal(modal)
    })
})

// voor de overlay
overlay.addEventListener('click', () => {
    const modals = document.querySelectorAll('.modal.active')
    modals.forEach(modal => {
     closeModal(modal)
    })
})

// voor btn annuleer
annuleerModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        modal = document.querySelector(button.dataset.closeButtonTarget)
        closeModal(modal)
    })
})



//voor de model open btn
function openModal(modal) {
    modal.classList.add('active')
    modal.classList.add('modalClassActive')
    overlay.classList.add('active' )
    overlay.classList.add('overlayClassActive' )
    document.getElementById('account').style.display = "none";
    let dropdownMenu =  document.getElementById('small-display-content')
    if(dropdownMenu.classList.contains(('active'))){
        dropdownMenu.classList.remove(('active'))}
}

function closeModal(modal){
    modal.classList.remove('active')
    modal.classList.remove('modalClassActive')
    overlay.classList.remove('active')
    overlay.classList.remove('overlayClassActive')
}