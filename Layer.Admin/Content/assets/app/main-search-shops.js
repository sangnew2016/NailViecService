var mainSearchShops = (function () {
    var tableResultOfShops;
    var rows_selected = [];

    var shopSearchingModel = {
        name: '',
        area: '',
        address: '',
        phone: '',
        shopStatusId: 0,
        nearAreaRadius: 0,
        withJobCondition: 0,
        withShopHistory: 0
    };

    return {
        load: load,
        setEvents: setEvents,
        getShopSearchingModel: getShopSearchingModel
    };

    function load(callback) {
        loadDatatable();
        loadSelect();

        function loadDatatable() {
            var dataSet = tempService.getDataTempForShops();
            tableResultOfShops = $(dom.shop.searchResults).DataTable({
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
                        //$(row).find('input[type="checkbox"]').prop('checked', true);
                        //$(row).addClass('selected');
                    }
                }
            });
        }

        function loadSelect() {
            var shopStatusList = [
                { id: 1, name: 'Test 1' },
                { id: 2, name: 'Test 2' },
                { id: 3, name: 'Test 3' },
                { id: 4, name: 'Test 4' },
                { id: 5, name: 'Test 5' }
            ];
            $(dom.shop.status).select({ data: shopStatusList });
        }
    }

    function setEvents(callback) {
        $('#btnAddShop').on('click', function () {
            mainSearchShopDetail.showEditPopup(null);
        });

        $(dom.shop.searchResults + ' tbody').on('click', 'tr', function (event) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                tableResultOfShops.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var rowData = tableResultOfShops.row(this).data();
                mainSearchShopDetail.showEditPopup(rowData);
            }
            event.stopPropagation();
        });

        // Add event listener for opening and closing details
        $(dom.shop.searchResults + ' tbody').on('click', 'td.details-control', function (event) {
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
        $(dom.shop.searchResults + ' tbody').on('click', 'input[type="checkbox"]', function (e) {
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

            //if (this.checked) {
            //    $row.addClass('selected');
            //} else {
            //    $row.removeClass('selected');
            //}

            // Update state of "Select all" control
            updateDataTableSelectAllCtrl(tableResultOfShops);

            // Prevent click event from propagating to parent
            e.stopPropagation();
        });


        $(dom.shop.btnSearch).on('click', function () {
            event.preventDefault();
            event.stopPropagation();

            var model = getShopSearchingModel();
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

        // Handle click on table cells with checkboxes
        $(dom.shop.searchResults).on('click', 'tbody td, thead th:first-child', function (e) {
            $(this).parent().find('input[type="checkbox"]').trigger('click');
        });

        // Handle click on "Select all" control
        $('thead input[name="select_all"]', tableResultOfShops.table().container()).on('click', function (e) {
            if (this.checked) {
                $(dom.shop.searchResults + ' tbody input[type="checkbox"]:not(:checked)').trigger('click');
            } else {
                $(dom.shop.searchResults + ' tbody input[type="checkbox"]:checked').trigger('click');
            }

            // Prevent click event from propagating to parent
            e.stopPropagation();
        });

        // Handle table draw event
        tableResultOfShops.on('draw', function () {
            // Update state of "Select all" control
            updateDataTableSelectAllCtrl(tableResultOfShops);
        });

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
    }

    function getShopSearchingModel() {
        setShopSearchingModel();

        return shopSearchingModel;
    }

    function setShopSearchingModel() {
        var value = mapDOMintoModel();

        shopSearchingModel.name = value.name;
        shopSearchingModel.area = value.area;
        shopSearchingModel.address = value.address;
        shopSearchingModel.phone = value.phone;
        shopSearchingModel.shopStatusId = value.shopStatusId;
        shopSearchingModel.nearAreaRadius = value.nearAreaRadius;
        shopSearchingModel.withJobCondition = value.withJobCondition;
        shopSearchingModel.withShopHistory = value.withShopHistory;
    }

    function mapDOMintoModel() {
        var name = $(dom.shop.name).val();
        var area = $(dom.shop.area).val();
        var address = $(dom.shop.address).val();
        var phone = $(dom.shop.phone).val();
        var nearAreaRadius = $(dom.shop.nearAreaRadius).val();
        var shopStatus = $(dom.shop.status).select();
        var shopStatusId = shopStatus ? shopStatus['id'] : null;
        var withJobCondition = $(dom.shop.withJobCondition + ':checked').length > 0;
        var withShopHistory = $(dom.shop.withShopHistory + ':checked').length > 0;

        return {
            name: name,
            area: area,
            address: address,
            phone: phone,
            shopStatusId: shopStatusId,
            nearAreaRadius: nearAreaRadius,
            withJobCondition: withJobCondition,
            withShopHistory: withShopHistory
        };
    }

})();