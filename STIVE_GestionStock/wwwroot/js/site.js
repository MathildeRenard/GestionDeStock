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

//Tri ordre des vins par prix
function tri(id,ordre) {
    document.getElementById('tri').textContent = id.textContent;
 
    //parcourir les elements et comparer leur prix.
    table = document.getElementsByClassName('info');
    var tbody = document.getElementById('tbody');
    //Tri des prix par ordre croissant
    if (ordre == "croissant") {
        //tri à bulles
        for (i = 0; i < table.length; i++) {
            for (var j = 0; j < (table.length - i - 1); j++) {

                tablePrix = parseInt(table[j].childNodes[5].textContent.split(' ')[0]);
                tablePrixSup = parseInt(table[j + 1].childNodes[5].textContent.split(' ')[0])

                if (tablePrix > tablePrixSup) {
                    tbody.insertBefore(table[j + 1], table[j]);

                }


            }
        }
    } else {
        //Si on veut trier par ordre decroissant
        for (i = 0; i < table.length; i++) {
            for (var j = 0; j < (table.length - i - 1); j++) {

                tablePrix = parseInt(table[j].childNodes[5].textContent.split(' ')[0]);
                tablePrixSup = parseInt(table[j + 1].childNodes[5].textContent.split(' ')[0])

                if (tablePrix < tablePrixSup) {
                    tbody.insertBefore(table[j + 1], table[j]);

                }
            }
        }}
    
   

}