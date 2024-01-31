//function actualiserHeure() {
//    console.log("Mise à jour satisfaisante heure")
//    var now = new Date();
//    var hour = ('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2);
//    document.getElementById('watch').innerText = hour;
//}

//setInterval(actualiserHeure, 60000);
//actualiserHeure();



//document.addEventListener('DOMContentLoaded', function () {

//    function actualiserContenu() {
//        console.log("Mise jour satisfaisante du contenu...");
//        fetch('https://localhost:7240/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1')
//            .then(function (response) {
//                return response.text();
//            })
//            .then(function (html) {
//                var parser = new DOMParser();
//                var doc = parser.parseFromString(html, "text/html");
//                var nouveauContenu = doc.querySelector('#salle-attente').innerHTML;

//                document.getElementById('salle-attente').innerHTML = nouveauContenu;

///*                $('#dataTable').DataTable({});*/
//            })
//            .catch(function (err) {
//                console.warn('Erreur lors du chargement de la section :', err);
//            });
//    }


//    setInterval(actualiserContenu, 60000);
//    actualiserContenu();
//});
//actualiserHeure();
//actualiserContenu();


function actualiserHeure() {
    console.log("Mise à jour satisfaisante heure");
    var now = new Date();
    var hour = ('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2);
    $('#watch').text(hour);
}


$('#PasserPatient').on('click', function (e) {
    e.preventDefault();
    var consultaionID = Cli
    $.ajax({
        url: '/Cliniques/ListeAttente/ChangerConsultationStatut?consultaionID=' + consultaionID,
        method: 'POST',
        success: function (response) {
            
        },
        error: function (error) {
            console.error("Error al cambiar el estado del paciente", error);
        }
    });
});



function actualiserContenu() {
    console.log("Mise à jour satisfaisante du contenu...");
    $.ajax({
        url: 'https://localhost:7240/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1',
        method: 'GET',
        dataType: 'html',
        success: function (html) {
            var nouveauContenu = $('<div>').html(html).find('#salle-attente').html();
            $('#salle-attente').html(nouveauContenu);

            // Inițializează DataTable aici, după ce datele au fost încărcate
            initDataTableSalleDAttente();
        },
        error: function (err) {
            console.warn('Erreur lors du chargement de la section :', err);
        }
    });
}
//Start DATATABLE
//==================================================
function initDataTableSalleDAttente() {
    $('#dataTableSalleDAttente').DataTable({
        searching: false,
        ordering: false,
        lengthMenu: [[20, -1], [20, "All"]], // Opțiuni de afișare în meniu și valoarea implicită
        pageLength: 20,
        "language": {
            "decimal": ",",
            "thousands": ".",
            "lengthMenu": "Affichage de _MENU_ patients par page",
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
}
//END DATATABLES
//==================================================

$(document).ready(function () {
    setInterval(actualiserHeure, 60000);
    actualiserHeure();
    actualiserContenu();
});

//Start Montre/Clock
//==================================================
$(document).ready(function () {
    function currentTime() {
        var date = new Date();
        var day = date.getDay();
        var hour = date.getHours();
        var min = date.getMinutes();
        var sec = date.getSeconds();
        var month = date.getMonth();
        var currDate = date.getDate();
        var year = date.getFullYear();
        var monthName = [
            "Janvier",
            "Février",
            "Mars",
            "Avril",
            "Mai",
            "Juin",
            "Juillet",
            "Août",
            "Septembre",
            "Octobre",
            "Novembre",
            "Décembre",
        ];
        var showDay = $('.dayDiv span')
        var midDay = "AM"
        midDay = (hour >= 12) ? "PM" : "AM";
        hour = (hour == 0) ? 12 : ((hour < 12) ? hour : (hour - 12));
        hour = updateTime(hour);
        min = updateTime(min);
        sec = updateTime(sec);
        currDate = updateTime(currDate);
        $("#time").html(`${hour}:${min}`);
        $("#sec").html(`${sec}`);
        $("#med").html(`${midDay}`);
        $("#full-date").html(`${monthName[month]} ${currDate} ${year}`);
        showDay.eq(day).css('opacity', '1')
    }
    updateTime = function (x) {
        if (x < 10) {
            return "0" + x
        }
        else {
            return x;
        }
    }
    setInterval(currentTime, 1000);
});
//End Montre/Clock
//==================================================