(function () {

    $(document).ready(function() {
        init();
    });

    function init() {
        //SHOPS
        mainSearchShops.load();
        mainSearchShops.setEvents();
        //JOBS
        mainSearchJobs.load();
        mainSearchJobs.setEvents();


        $('.dropdown .dropdown-menu').delegate('a', 'click', function () {
            //sammy.setLocation($(this).attr('href'));
            $(this).closest('.dropdown-menu').trigger('click');
            return false;
        });
    }

})();