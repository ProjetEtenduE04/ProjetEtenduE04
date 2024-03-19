document.addEventListener('keydown', function (event) {
    if (event.keyCode === 97) {
        11
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/AppelerProchainPatient"]').submit();
    }
    @* if (event.keyCode === 98) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultationEtAppellerProchainPatient"]').submit();
    } * @
        if (event.keyCode === 99) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultation"]').submit();
    }
    if (event.keyCode === 100) {
        event.preventDefault();
        document.querySelector('form[action="/Cliniques/listeattente/TerminerConsultationEtAppellerProchainPatient"]').submit();
    }
});