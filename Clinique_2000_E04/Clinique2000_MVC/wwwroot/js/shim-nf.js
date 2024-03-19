document.addEventListener('keydown', function (event) {
    if (event.keyCode === 49) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/AppelerProchainPatient"]').submit();
    }
    else if (event.keyCode === 50) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultationEtAppellerProchainPatient"]').submit();
    }
    else if (event.keyCode === 51) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultation"]').submit();
    }
    else if (event.keyCode === 52) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultationEtAppellerProchainPatient"]').submit();
    }
});