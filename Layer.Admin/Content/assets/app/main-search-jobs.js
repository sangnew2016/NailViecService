var mainSearchJobs = (function () {
    var tableResultOfJobs;
    var resultOfJobsId = 'resultOfJobs';
    var rows_selected = [];

    return {
        loadResults: loadResults,
        setEventsOnResult: setEventsOnResult
    };

    function loadResults(callback) {
        var dataSet = tempService.getDataTempForShops();
        tableResultOfJobs = $('#' + resultOfJobsId).DataTable({
            data: dataSet,
            columns: [
                {
                    "className": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": '30'
                },
                { "data": "name" },
                { "data": "position" },
                { "data": "office" },
                { "data": "salary" }
            ],
            order: [[1, 'asc']]
        });
    }

    function setEventsOnResult(callback) {
        $('#' + resultOfJobsId + ' tbody').on('click', 'tr', function (event) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                tableResultOfJobs.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                mainSearchJobDetail.showEditPopup(tableResultOfJobs.$('tr.selected'));
            }
            event.stopPropagation();
        });

        // Add event listener for opening and closing details
        $('#' + resultOfJobsId + ' tbody').on('click', 'td.details-control', function (event) {
            var tr = $(this).closest('tr');
            var row = tableResultOfJobs.row(tr);

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                // Open this row
                row.child(format(row.data())).show();
                tr.addClass('shown');
            }
            event.stopPropagation();
        });

        /* Formatting function for row details - modify as you need */
        function format(d) {
            // `d` is the original data object for the row
            return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                '<tr>' +
                    '<td>Full name:</td>' +
                    '<td>' + d.name + '</td>' +
                '</tr>' +
                '<tr>' +
                    '<td>Extension number:</td>' +
                    '<td>' + d.extn + '</td>' +
                '</tr>' +
                '<tr>' +
                    '<td>Extra info:</td>' +
                    '<td>And any further details here (images etc)...</td>' +
                '</tr>' +
            '</table>';
        }

        // On each draw, loop over the `detailRows` array and show any child rows
        tableResultOfJobs.on('draw', function () {
            $.each( detailRows, function ( i, id ) {
                $('#'+id+' td.details-control').trigger( 'click' );
            } );
        });

    }


})();