
const zoekInput = document.getElementById('zoekbalk')
let zoekOpties = [];



zoekInput.addEventListener("keypress", function(event) {
    // If the user presses the "Enter" key on the keyboard
    if (event.key === "Enter") {
        // Cancel the default action, if needed
        event.preventDefault();
        localStorage.setItem( 'zoekopdracht', JSON.stringify(zoekInput.value))

        window.location.assign('../P4_OnlyWinkelPagina/pageByJS_Winkelpagina.html')

    }
});