(function () {

    $(document).ready(function() {
        init();
    });

    function init() {
        //SHOPS
        mainSearchShops.loadResults();
        mainSearchShops.setEventsOnResult();
        //JOBS
        mainSearchJobs.loadResults();
        mainSearchJobs.setEventsOnResult();
    }

})();