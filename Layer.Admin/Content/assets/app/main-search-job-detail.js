var mainSearchJobDetail = (function(){
    return {
        showEditPopup: showEditPopup
    };

    function showEditPopup(item) {
        commonServices.replaceHTMLOnJobPopup('#editJobPopup');
        commonServices.showModal();

        if (item) {
            //....
        }

        commonServices.setEventsOnModal();
    }

})();