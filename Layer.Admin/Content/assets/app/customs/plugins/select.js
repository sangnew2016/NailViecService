(function ($) {

    /*==================================
    1. Structure HTML:
        <div class="dropdown" id="shopStatus">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                <span class="selected-text">Dropdown Example</span>
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu">
                <li><a href="#" value="1">HTML</a></li>
                <li><a href="#" value="2" class="selected">CSS</a></li>
                <li><a href="#" value="3">JavaScript</a></li>
            </ul>
        </div>
    ===================================*/


    $.fn.select = function (option) {
        if (!$(this).attr('id')) {
            console.log('Has no id for this control. ', $(this));
            return;
        }

        var defaultOption = {
            placeholder: 'select option',
            selectId: '#' + $(this).attr('id'),
            field: { id: 'id', name: 'name' }
        };
        var dataKey = 'data';
        var selectedItemClass = 'selected';

        // This is the easiest way to have default options.
        var setting = $.extend(defaultOption, option);
        var data = setting.hasOwnProperty(dataKey) ? setting.data : null;

        //1. load select by ajax: options.url
        if (setting.hasOwnProperty('url')) {
            $.ajax({
                type: 'POST',
                url: setting.url,
                success: function (items) {
                    data = items;
                    $(setting.selectId).data(dataKey, data);
                    loadSelect.apply(this);
                },
                error: function (req, status, err) {
                    console.log(url, ' is invalid or issues: ', status, err);
                }
            });
        }

        //2. load select by data: options.data
        if (setting.hasOwnProperty(dataKey)) {
            $(setting.selectId).data(dataKey, data);
            loadSelect.apply(this);
        }

        //3. get selected Item: options = null || undefined (get selected option)
        if (!option) {
            var dataBefore = $(setting.selectId).data(dataKey);
            if (!dataBefore) return null;

            var selectedItem = getSelectedItem(dataBefore);
            return selectedItem;
        }

        //4. set selected item
        if (setting.hasOwnProperty('selectedId')) {
            var dataBefore = $(setting.selectId).data(dataKey);
            if (!dataBefore) return null;

            var selectedId = setting['selectedId'];
            if (selectedId) {
                $(setting.selectId + ' ' + dom.common.dropdownMenu).find('#' + selectedId).trigger('click');
            } else {
                $(setting.selectId + ' ' + dom.common.dropdownToggle + ' .selected-text').html(setting.placeholder);
            }
        }

        return this;



        //==============================================
        // FUNCTION
        //==============================================
        function loadSelect() {
            var template = getTemplate(data, setting);
            $(this).html(template);
            setEvents();
        }

        function getTemplate(data, setting) {
            var s = '' +
                '<button class="btn btn-info dropdown-toggle" type="button" data-toggle="dropdown">' +
                    '<span class="selected-text">' + setting.placeholder + '</span>' +
                    '&nbsp;&nbsp;<span class="caret"></span>' +
                '</button>' +
                '<ul class="dropdown-menu">';

            for (var i = 0; i < data.length; i++) {
                s += '<li><a href="#" value="' + data[i][setting.field.id] + '">' + data[i][setting.field.name] + '</a></li>';
            }
            s += '</ul>';

            return s;
        }

        function setEvents() {
            $(setting.selectId + ' ' + dom.common.dropdownMenu).on('click', 'a', function (event) {
                //set class into item after click
                $(setting.selectId + ' ' + dom.common.dropdownMenu + ' a').removeClass(selectedItemClass);
                $(this).addClass(selectedItemClass);

                //Fixed: for dropdownMenu (bootstrap)
                var selectedText = $(this).html();
                $(setting.selectId + ' ' + dom.common.dropdownToggle + ' .selected-text').html(selectedText);
            });
        }

        function getSelectedItem(data) {
            var item = $(setting.selectId).find(dom.common.dropdownMenu + ' .' + selectedItemClass);
            if (item && item.length > 0) {
                var value = item.attr('value');
                if (!value) return null;

                for (var i = 0; i < data.length; i++) {
                    if (data[i][setting.field.id] == value) {
                        return data[i];
                    }
                }
            }
            return null;
        }
    };

}(jQuery));