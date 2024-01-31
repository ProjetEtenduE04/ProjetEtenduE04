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


//function actualiserHeure() {
//    console.log("Mise à jour satisfaisante heure");
//    var now = new Date();
//    var hour = ('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2);
//    $('#watch').text(hour);
//}

//function actualiserContenu() {
//    console.log("Contenu bien mis a jour")
//     window.location.reload();
//}

//$('#PasserPatient').on('click', function (e) {
//    e.preventDefault();

//    $.ajax({
//        url: '/Cliniques/ListeAttente/IndexSalleAttente/IndexListeSalleAttente?listeAttenteID=1',
//        method: 'GET',
//        dataType: 'json',
//        success: function (response) {
//            if (response.success && response.data && response.data.consultations) {
//                var consultations = response.data.consultations;
//                var table = $('#dataTableSalleDAttente').DataTable();
//                table.clear();

//                $.each(consultations, function (index, consultation) {
//                    if (consultation.patient && consultation.plagesHoraires) {
//                        var ordre = index + 1;
//                        var nomPatient = consultation.patient.prenom + ' ' + consultation.patient.nom.charAt(0) + '.';
//                        var heureDebut = consultation.plagesHoraires[0].heureDebut;

//                        table.row.add([
//                            ordre,
//                            nomPatient,
//                            heureDebut
//                        ]);
//                    }
//                });

//                table.draw();
//                initDataTableSalleDAttente();
//            } else {
//                console.error("Erreur lors du chargement des données");
//            }
//        },
//        error: function (error) {
//            console.error("Error en la solicitud AJAX", error);
//        }
//    });
//});












//function actualiserContenu() {
//    console.log("Mise à jour satisfaisante du contenu...");
//    $.ajax({
//        url: 'https://localhost:7240/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1',
//        method: 'GET',
//        dataType: 'JSON',
//        success: function () {
//            var nouveauContenu = $('<div>').html(html).find('#salle-attente').html();
//            $('#salle-attente').html(nouveauContenu);

//            // Inițializează DataTable aici, după ce datele au fost încărcate
//            initDataTableSalleDAttente();
//        },
//        error: function (err) {
//            console.warn('Erreur lors du chargement de la section :', err);
//        }
//    });
//}

//function actualizarTabla() {
//    $.ajax({
//        url: 'https://localhost:7240/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1',
//        method: 'GET',
//        data: { listeAttenteID: tuListeAttenteID },
//        dataType: 'json',
//        success: function (response) {
//            // Aquí llamas a una función que actualiza la tabla con los nuevos datos
//            remplirAvecNouveauxDonnees(response);
//        },
//        error: function (error) {
//            console.error("Error al actualizar la tabla: ", error);
//        }
//    });
//}

//// MEthode pour remplir la table avec les nouvelles données
//function remplirAvecNouveauxDonnees(donnees) {
//    var table = $('#dataTableSalleDAttente').DataTable();
//    table.clear();

//    $.each(donnees.consultations, function (index, consultation) {
//        // Asumiendo que 'consultation' tiene las propiedades que necesitas
//        table.row.add([
//            index + 1, // Orden
//            consultation.patient.prenom + ' ' + consultation.patient.nom.charAt(0), // Nombre e inicial
//            new Date(consultation.plageHoraire.heureDebut).toLocaleTimeString() // Hora de inicio
//        ]);
//    });

//    table.draw();
//initDataTableSalleDAttente();
//}
actualiserHeure();
actualiserContenu();

$('#PasserPatient').on('click', function (e) {
    e.preventDefault();
    var consultationID = $(this).data('consultationid');
    
    console.log(consultationID);
   

    $.ajax({
        url: "/Cliniques/ListeAttente/ChangerStatutConsultation?ConsultationID="+ consultationID, 
        method: 'POST',
        dataType: 'json',
        data: { consultationID: consultationID },
        success: function (response) {
            if (response.success) {
                console.log("Changement de status correct", response);

            } else {
                console.error("Erreur lors du chargement de statut");
            }
        },
        error: function (error) {
            console.error("Error en la solicitud AJAX", error);
        }
    });
});




function actualiserHeure() {
    console.log("Mise à jour satisfaisante heure");
    var now = new Date();
    var hour = ('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2);
    $('#watch').text(hour);
}

function actualiserContenu() {
    console.log("Mise à jour satisfaisante du contenu...");
    $.ajax({
        url: '/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1',
        method: 'GET',
        /*dataType: 'json',*/
        success: function (response) {
            if (response && response.data && Array.isArray(response.data)) {
                console.log(response);
            }
            
            ////var table = $('#dataTableSalleDAttente').DataTable();
            ////if ($.fn.DataTable.isDataTable('#dataTableSalleDAttente')) {
            ////    table.destroy();
            ////}
            ////var table = $('#dataTableSalleDAttente').DataTable();
            //$.each(response.data, function (index, consultation) {
            //    console.log("Mise à jour satisfaisante du contenu2...");
            //    table.row.add([

            //        index + 1,
            //        consultation.patient.prenom + ' ' + consultation.patient.nom.charAt(0) + '.',
            //        consultation.plagesHoraires[0].heureDebut

            //    ]);
            //});


            //table.draw();
initDataTableSalleDAttente();
          

        },
        error: function (error) {
            console.error("Error en la solicitud AJAX", error);
        }
    });

};

actualiserHeure();
actualiserContenu();


$(document).ready(function () {
    setInterval(function () {
        actualiserHeure();
        actualiserContenu();
    }, 60000);
    
});

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

//$(document).ready(function () {
//    setInterval(actualiserHeure, 60000);
//    actualiserHeure();
//    actualiserContenu();
//});

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