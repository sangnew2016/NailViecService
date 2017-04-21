var mainSearchJobs = (function () {
    var tableResultOfJobs;
    var resultOfJobsId = 'resultOfJobs';
    var rows_selected = [];

    var jobSearchingModel = {
        title: '',
        body: '',
        phoneContact: '',
        salary: '',
        jobStatusId: 0,
        jobTypeId: 0,

        withShopCondition: false,
        withJobHistory: false
    };

    return {
        load: load,
        setEvents: setEvents,
        getJobSearchingModel: getJobSearchingModel
    };

    function load(callback) {
        loadDatatable();
        loadSelect();

        function loadDatatable() {
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

        function loadSelect() {
            var jobStatusList = [
                { id: 1, name: 'Test 1' },
                { id: 2, name: 'Test 2' },
                { id: 3, name: 'Test 3' },
                { id: 4, name: 'Test 4' },
                { id: 5, name: 'Test 5' }
            ];
            $(dom.job.status).select({ data: jobStatusList });
            $(dom.job.type).select({ data: jobStatusList });
        }

    }

    function setEvents(callback) {
        $('#btnAddJob').on('click', function () {
            mainSearchJobDetail.showEditPopup(null);
        });

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

        // Search
        $(dom.job.btnSearch).on('click', function () {
            event.preventDefault();
            event.stopPropagation();

            var model = getJobSearchingModel();
            console.log(model);
            return;

            //call server: (shops | jobs)
            $.ajax({
                type: 'POST',
                url: '/data/save',
                data: model,
                //dataType: 'json',
                success: function (data) {
                    console.log(data);
                },
                error: function (req, status, err) {
                    console.log('something went wrong', status, err);
                }
            });
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

    function getJobSearchingModel() {
        setJobSearchingModel();

        return jobSearchingModel;
    }

    function setJobSearchingModel() {
        var value = mapDOMintoModel();

        jobSearchingModel.title = value.title;
        jobSearchingModel.body = value.body;
        jobSearchingModel.phoneContact = value.phoneContact;
        jobSearchingModel.salary = value.salary;
        jobSearchingModel.jobStatusId = value.jobStatusId;
        jobSearchingModel.jobTypeId = value.jobTypeId;

        jobSearchingModel.withShopCondition = value.withShopCondition;
        jobSearchingModel.withJobHistory = value.withJobHistory;
    }

    function mapDOMintoModel() {
        var title = $(dom.job.title).val();
        var body = $(dom.job.body).val();
        var phoneContact = $(dom.job.phoneContact).val();
        var salary = $(dom.job.salary).val();
        var jobStatus = $(dom.job.status).select();
        var jobStatusId = jobStatus ? jobStatus['id'] : null;
        var jobType = $(dom.job.type).select();
        var jobTypeId = jobType ? jobType['id'] : null;

        var withShopCondition = $(dom.job.withShopCondition + ':checked').length > 0;
        var withJobHistory = $(dom.job.withJobHistory + ':checked').length > 0;

        return {
            title: title,
            body: body,
            phoneContact: phoneContact,
            salary: salary,
            jobStatusId: jobStatusId,
            jobTypeId: jobTypeId,

            withShopCondition: withShopCondition,
            withJobHistory: withJobHistory
        };
    }

})();