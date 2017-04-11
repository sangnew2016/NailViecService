var commonServices = (function () {
    return {
        showModal: showModal,
        replaceHTMLOnPopup: replaceHTMLOnPopup,
        setEventsOnModal: setEventsOnModal
    };

    function showModal() {
        var el = document.getElementById("overlay");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    }

    function replaceHTMLOnPopup(selector) {
        var html = $(selector);
        $('#overlay .popup-container').html(html);
    }

    function setEventsOnModal() {
        $('.modal-header .close, .modal-footer .btn-default').on('click', function () {
            $('#overlay').css('visibility', 'hidden');
        });
    }

})();