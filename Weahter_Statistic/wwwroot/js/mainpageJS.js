// Connect element to interaction
var menuclick = document.querySelector(".menu");
var menu = document.querySelector("nav");
var bgmenu = document.querySelector(".bgmenu");
var mybutton = document.querySelector(".mybutton");

menuclick.addEventListener("click", showMenu);
mybutton.addEventListener("click", showMenu);

// Menu ready to correct visible
window.onclick = function (event) {
    if (event.target == bgmenu) {
        menu.style.right = "-400px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "0";
        menuclick.style.transition = "2s ease";
        bgmenu.style.display = "none";
    }
}

function showMenu() { 
    if (menuclick.style.right == "0px" || menuclick.style.right == "") {
        menu.style.right = "0px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "400px";
        menuclick.style.transition = "2s ease";
        bgmenu.style.display = "block";
    }
    else {
        menu.style.right = "-400px";
        menu.style.transition = "2s ease";
        menuclick.style.right = "0";
        menuclick.style.transition = "2s ease";
        bgmenu.style.display = "none";
    }
}


//JQuery
$(document).ready(function () {
    $(".detailmenu").hover(
        function () {
            $(this).find('ul').slideDown();
        },
        function () {
            $(this).find('ul').slideUp();
        });
});


//load elements of json array and function random on bottom code
$.ajax({
    url: "../JSON/goldthink.json",
    dataType: "json",
    success: (function (data) {
        var short = data.goldThink;
        var array = [];
        for (var i = 0; i < 3; i++) {
            var temp = getRandomInt(0, short.length - 1);
            var flag = false;
            for (var y = 0; y < array.length; y++) {
                if (temp == array[y]) {
                    flag = true;
                }
            }
            if (flag != true) {
                array.push(temp);
            }
            else {
                i = i - 1;
            }
        }
        $('#goldthink1').append(short[array[0]].think);
        $('#goldthink2').append(short[array[1]].think);
        $('#goldthink3').append(short[array[2]].think);
        $('#author1').append(short[array[0]].author);
        $('#author2').append(short[array[1]].author);
        $('#author3').append(short[array[2]].author);
    })
});

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}