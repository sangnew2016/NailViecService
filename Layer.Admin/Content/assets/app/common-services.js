var commonServices = (function () {
    var outstandingForOverlay = 40;
    var htmlShopPopupTemp = null;
    var htmlJobPopupTemp = null;

    return {
        showModal: showModal,
        replaceHTMLOnShopPopup: replaceHTMLOnShopPopup,
        replaceHTMLOnJobPopup: replaceHTMLOnJobPopup,
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

    function replaceHTMLOnShopPopup(selector) {
        if (htmlShopPopupTemp === null) htmlShopPopupTemp = $(selector);
        $('#overlay .popup-container').html(htmlShopPopupTemp);
    }

    function replaceHTMLOnJobPopup(selector) {
        if (htmlJobPopupTemp === null) htmlJobPopupTemp = $(selector);
        $('#overlay .popup-container').html(htmlJobPopupTemp);
    }

    function setEventsOnModal() {
        $('.modal-header .close, .modal-footer .btn-default').on('click', function () {
            $('#overlay').css('visibility', 'hidden');
        });
    }

})();