// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var today = new Date().toISOString().split('T')[0];
var todayMax = new Date(today.getFullYear() - 14, today.getMonth(), today.getDate()).toISOString().split('T')[0];
document.getElementById("DateDeNaissance").setAttribute("max", todayMax);



$(document).ready(function () {

    // InputMask - pour configurer le format des données introduites dans les input
    // *** :  'A' signifie n'importe quelle lettre et '9' n'importe quel chiffre.

    // définir un modèle de code postal
    $('#CodePostal').inputmask('A9A 9A9');
    // définir un modèle de Numar de asigurare medicala
    $('#NAM').inputmask('AAAA99999999');

    //Fonction qui modifie la première lettre en majuscule de la valeur d'entrée
    $('.capitalize-first-letter').on('input', function () {
        // Obtenir la valeur actuelle
        var currentValue = $(this).val();

        // Vérifier si la valeur contient au moins une lettre
        if (/[a-zA-Z]/.test(currentValue)) {
            // Formatage de la valeur pour que la première lettre soit en majuscule et le reste en minuscule
            var formattedValue = currentValue.charAt(0).toUpperCase() + currentValue.slice(1).toLowerCase();

            // Remettre la valeur formatée dans le champ de saisie
            $(this).val(formattedValue);
        }
    });
});
