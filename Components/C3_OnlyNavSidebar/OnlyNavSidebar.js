document.getElementById("only-nav-sidebar-btn").addEventListener("click", openSidebarMenu);
function openSidebarMenu(){
    document.getElementById("only-nav-sidebar-content").classList.toggle("active")
    document.getElementById("only-nav-sidebar-btn-span").classList.toggle("active")
    document.getElementById("only-nav-sidebar-btn").classList.toggle("active")
}