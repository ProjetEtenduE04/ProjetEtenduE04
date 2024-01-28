function actualiserHeure() {
    console.log("Mise à jour satisfaisante heure")
    var now = new Date();
    var hour = ('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2);
    document.getElementById('watch').innerText = hour;
}

setInterval(actualiserHeure, 60000);
actualiserHeure();



document.addEventListener('DOMContentLoaded', function () {

    function actualiserContenu() {
        console.log("Mise jour satisfaisante du contenu...");
        fetch('https://localhost:7240/Cliniques/ListeAttente/IndexlisteSalleAttente?listeAttenteID=1')
            .then(function (response) {
                return response.text();
            })
            .then(function (html) {
                var parser = new DOMParser();
                var doc = parser.parseFromString(html, "text/html");
                var nouveauContenu = doc.querySelector('#salle-attente').innerHTML;

                document.getElementById('salle-attente').innerHTML = nouveauContenu;

                $('#dataTable').DataTable({});
            })
            .catch(function (err) {
                console.warn('Erreur lors du chargement de la section :', err);
            });
    }


    setInterval(actualiserContenu, 60000);
    actualiserContenu();
});
actualiserHeure();
actualiserContenu();