// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    if ($(window).width() > 991) {
        $('.navbar-light .d-menu').hover(function () {
            $(this).find('.sm-menu').first().stop(true, true).slideDown(150);
        }, function () {
            $(this).find('.sm-menu').first().stop(true, true).delay(120).slideUp(100);
        });
    }
});

//fonction barre de recherche du catalogue des vins
function search() {
    let input = document.getElementById('searchbar').value
    input = input.toLowerCase();
    let table = document.getElementsByClassName('info');

   

    for (i = 0; i < table.length; i++) {
        if (!table[i].innerHTML.toLowerCase().includes(input)) {
            table[i].style.display = "none";
        }
        else {
            table[i].style.display = "block";
        }
    }
}