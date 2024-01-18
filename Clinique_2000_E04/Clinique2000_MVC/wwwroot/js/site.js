
// Write your JavaScript code.
/*var today = new Date().toISOString().split('T')[0];*/
document.addEventListener('DOMContentLoaded', function () {
    var today = new Date();
    var todayMax = new Date(today.getFullYear() - 14, today.getMonth(), today.getDate()).toISOString().split('T')[0];
    var dateInput = document.getElementById("DateDeNaissance");

    if (dateInput) {
        dateInput.setAttribute("max", todayMax);
    }
});



$(document).ready(function () {

    // InputMask - pour configurer le format des données introduites dans les input
    // *** :  'A' signifie n'importe quelle lettre et '9' n'importe quel chiffre.

    // définir un modèle de code postal
    $('#CodePostal').inputmask('A9A 9A9');
    // définir un modèle de Numar de asigurare medicala
/*    $('#nam').inputmask('aaaa 9999 9999', { "onfocusout": function () { alert('le format nam n\'est pas valide.(ex:abcd 1234 5678)'); } });*/
    $('#NAM').inputmask('AAAA 9999 9999');

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

//Start DATATABLE
//================================================== 
$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "decimal": ",",
            "thousands": ".",
            "lengthMenu": "Affichage de _MENU_ enregistrements par page",
            "zeroRecords": "Rien trouvé… Désolé! ",
            "info": "Affichage de la page _PAGE_ de _PAGES_",
            "infoEmpty": "Aucun enregistrement disponible ",
            "infoFiltered": "(filtré d’un maximum de _MAX_ enregistrement)",
            "search": "Recherche: ",
            "paginate": {
                "first": "Première",
                "last": "Dernière",
                "next": "Suivant",
                "previous": "Précédent",
            }

        }
    });
});
//END DATATABLES
//================================================== 