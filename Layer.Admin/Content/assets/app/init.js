(function () {
    var tableResultOfShops;
    var resultOfShopsId = 'resultOfShops';
    var rows_selected = [];

    $(document).ready(function() {
        init();
    });


    function init() {
        loadResultOfShops();
        setEventsOnResultOfShops();
    }

    function loadResultOfShops() {
        var dataSet = tempService.getDataSet();
        tableResultOfShops = $('#' + resultOfShopsId).DataTable({
            data: dataSet,
            columns: [
                {
                    "className": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": ''
                },
                { "data": "name" },
                { "data": "position" },
                { "data": "office" },
                { "data": "salary" }
            ],
            columnDefs: [{
                'targets': 0,
                'searchable': false,
                'orderable': false,
                'width': '1%',
                'className': 'dt-body-center',
                'render': function (data, type, full, meta) {
                    return '<input type="checkbox">';
                }
            }],
            order: [[1, 'asc']],
            rowCallback: function (row, data, dataIndex) {
                // Get row ID
                var rowId = data[0];

                // If row ID is in the list of selected row IDs
                if ($.inArray(rowId, rows_selected) !== -1) {
                    $(row).find('input[type="checkbox"]').prop('checked', true);
                    $(row).addClass('selected');
                }
            }
        });
    }

    function setEventsOnResultOfShops() {
        $('#' + resultOfShopsId + ' tbody').on('click', 'tr', function (event) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                tableResultOfShops.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                showEditShopPopup(tableResultOfShops.$('tr.selected'));
            }
        });

        // Add event listener for opening and closing details
        $('#' + resultOfShopsId + ' tbody').on('click', 'td.details-control', function (event) {
            var tr = $(this).closest('tr');
            var row = tableResultOfShops.row(tr);

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

        // Handle click on checkbox
        $('#' + resultOfShopsId + ' tbody').on('click', 'input[type="checkbox"]', function (e) {
            var $row = $(this).closest('tr');

            // Get row data
            var data = tableResultOfShops.row($row).data();

            // Get row ID
            var rowId = data[0];

            // Determine whether row ID is in the list of selected row IDs
            var index = $.inArray(rowId, rows_selected);

            // If checkbox is checked and row ID is not in list of selected row IDs
            if (this.checked && index === -1) {
                rows_selected.push(rowId);

                // Otherwise, if checkbox is not checked and row ID is in list of selected row IDs
            } else if (!this.checked && index !== -1) {
                rows_selected.splice(index, 1);
            }

            if (this.checked) {
                $row.addClass('selected');
            } else {
                $row.removeClass('selected');
            }

            // Update state of "Select all" control
            updateDataTableSelectAllCtrl(tableResultOfShops);

            // Prevent click event from propagating to parent
            e.stopPropagation();
        });

        // Handle click on table cells with checkboxes
        $('#' + resultOfShopsId).on('click', 'tbody td, thead th:first-child', function (e) {
            $(this).parent().find('input[type="checkbox"]').trigger('click');
        });

        // Handle click on "Select all" control
        $('thead input[name="select_all"]', tableResultOfShops.table().container()).on('click', function (e) {
            if (this.checked) {
                $('#' + resultOfShopsId + ' tbody input[type="checkbox"]:not(:checked)').trigger('click');
            } else {
                $('#' + resultOfShopsId + ' tbody input[type="checkbox"]:checked').trigger('click');
            }

            // Prevent click event from propagating to parent
            e.stopPropagation();
        });

        // Handle table draw event
        tableResultOfShops.on('draw', function () {
            // Update state of "Select all" control
            updateDataTableSelectAllCtrl(tableResultOfShops);
        });
    }

    //
    // Updates "Select all" control in a data table
    //
    function updateDataTableSelectAllCtrl(table) {
        var $table = tableResultOfShops.table().node();
        var $chkbox_all = $('tbody input[type="checkbox"]', $table);
        var $chkbox_checked = $('tbody input[type="checkbox"]:checked', $table);
        var chkbox_select_all = $('thead input[name="select_all"]', $table).get(0);

        // If none of the checkboxes are checked
        if ($chkbox_checked.length === 0) {
            chkbox_select_all.checked = false;
            if ('indeterminate' in chkbox_select_all) {
                chkbox_select_all.indeterminate = false;
            }

            // If all of the checkboxes are checked
        } else if ($chkbox_checked.length === $chkbox_all.length) {
            chkbox_select_all.checked = true;
            if ('indeterminate' in chkbox_select_all) {
                chkbox_select_all.indeterminate = false;
            }

            // If some of the checkboxes are checked
        } else {
            chkbox_select_all.checked = true;
            if ('indeterminate' in chkbox_select_all) {
                chkbox_select_all.indeterminate = true;
            }
        }
    }



    function showEditShopPopup(item) {
        console.log(item);
        //alert(item);
    }

    //http://www.gyrocode.com/articles/jquery-datatables-checkboxes/
    //https://jsfiddle.net/gyrocode/abhbs4x8/

})();