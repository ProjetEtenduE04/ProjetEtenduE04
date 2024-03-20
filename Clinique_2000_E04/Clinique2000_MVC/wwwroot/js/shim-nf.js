document.addEventListener('keydown', function (event) {
    if (event.keyCode === 49) {
        event.preventDefault();
        var form = document.getElementById('form1');
        form.action = '/Cliniques/ListeAttente/AppelerProchainPatient';
        form.submit();
    }
});
document.addEventListener('keydown', function (event) {
    if (event.keyCode === 50) {
        event.preventDefault();
        var form = document.getElementById('form2');
        form.action = '/Cliniques/ListeAttente/TerminerConsultationEtAppellerProchainPatient';
        form.submit();
    }
});
document.addEventListener('keydown', function (event) {
    if (event.keyCode === 51) {
        event.preventDefault();
        var form = document.getElementById('form2');
        form.action = '/Cliniques/ListeAttente/TerminerConsultation';
        form.submit();
    }
});
document.addEventListener('keydown', function (event) {
    if (event.keyCode === 52) {
        event.preventDefault();
        var form = document.getElementById('form2');
        form.action = '/Cliniques/ListeAttente/TerminerConsultationEtAppellerProchainPatient';
        form.submit();    }
});