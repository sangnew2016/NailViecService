var mainSearchShopDetail = (function() {
    return {
        showEditPopup: showEditPopup
    };


     function showEditPopup(item) {
        commonServices.replaceHTMLOnPopup('#editShopPopup');
        commonServices.showModal();
        setMapByShopLocation();
        commonServices.setEventsOnModal();
        return;

        function setMapByShopLocation() {
            var map2;

            map2 = new GMaps({
                el: '#gmaps-marker',
                lat: -12.043333,
                lng: -77.028333
            });
            map2.addMarker({
                lat: -12.043333,
                lng: -77.03,
                title: 'Lima',
                details: {
                    database_id: 42,
                    author: 'HPNeo'
                },
                click: function (e) {
                    if (console.log)
                        console.log(e);
                    alert('You clicked in this marker');
                },
                mouseover: function (e) {
                    if (console.log)
                        console.log(e);
                }
            });
            map2.addMarker({
                lat: -12.042,
                lng: -77.028333,
                title: 'Marker with InfoWindow',
                infoWindow: {
                    content: '<p>HTML Content</p>'
                }
            });
        }
    }

})();