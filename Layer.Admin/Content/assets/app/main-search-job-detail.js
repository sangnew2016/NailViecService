var mainSearchJobDetail = (function(){
    return {
        showEditPopup: showEditPopup
    };

    function showEditPopup(item) {
        commonServices.replaceHTMLOnPopup('#editJobPopup');
        commonServices.showModal();
        commonServices.setEventsOnModal();
    }

})();