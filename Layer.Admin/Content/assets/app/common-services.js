var commonServices = (function () {
    var outstandingForOverlay = 40;

    return {
        showModal: showModal,
        replaceHTMLOnPopup: replaceHTMLOnPopup,
        setEventsOnModal: setEventsOnModal
    };

    function showModal() {
        //set height for overlay
        var el = document.getElementById("overlay");
        var height = $('#wrap').outerHeight() + $('#footer').outerHeight() + outstandingForOverlay;
        $('#overlay').css({ 'visibility': 'visible', 'height': height + 'px' });

        //middle for window
        var topAfterScroll = $('body').scrollTop() + outstandingForOverlay;
        $('#overlay .popup-container').css({ 'marginTop': topAfterScroll });
    }

    function replaceHTMLOnPopup(selector) {
        var html = $(selector).html();
        $('#overlay .popup-container').html(html);
    }

    function setEventsOnModal() {
        $('.modal-header .close, .modal-footer .btn-default').on('click', function () {
            $('#overlay').css('visibility', 'hidden');
        });
    }

})();