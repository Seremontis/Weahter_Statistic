var menuclick = document.querySelector(".menu");
var menu = document.querySelector("nav");
var bgmenu = document.querySelector(".bgmenu");

menuclick.addEventListener("click", showMenu);


window.onclick = function (event) {
    if (event.target== menu) {
        menu.style.right = "-400px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "0";
        menuclick.style.transition = "2s ease";
        bgmenu.display = "block";
    }
}

function showMenu() { 
    if (menuclick.style.right == "0px" || menuclick.style.right == "") {
        menu.style.right = "0px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "400px";
        menuclick.style.transition = "2s ease";
        bgmenu.display = "block";
    }
    else {
        menu.style.right = "-400px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "0";
        menuclick.style.transition = "2s ease";
        bgmenu.display = "none";
    }
}

