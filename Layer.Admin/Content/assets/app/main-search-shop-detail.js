var mainSearchShopDetail = (function () {
    var editPopupId = '#editShopPopup';

    var statusKeyBySelect = {id: 'id', name: 'name'};

    var shopModel = {
        id: 0,
        name: '',
        address: '',
        phone: '',
        shopStatusId: 0,

        placeId: '',
        latitude: '',
        longtitude: '',
        fullAddress: '',
        areaName: '',
        stateName: '',
        countryName: ''
    };

    return {
        showEditPopup: showEditPopup,
        getShopModel: getShopModel
    };


    function showEditPopup(item) {
        var selector = dom.editShop.addressMap;
        var markers = [
            {
                latitude: -12.043333,
                longtitude: -77.03
            }, {
                latitude: -12.042,
                longtitude: -77.028333
            }
        ];

        commonServices.replaceHTMLOnShopPopup(editPopupId);
        commonServices.showModal();

        if (item) {
            shopModel.id = item.id;
            setMapByShopLocation(selector, markers);
            setShopModel(function (addressInfo) {
                alert(addressInfo);
            });
        } else {
            clearDataForAddNew();
        }

        commonServices.setEventsOnModal();
        return;

        function setMapByShopLocation(selector, markers) {
            var map2;
            var marker1 = markers[0];
            var marker2 = markers[1];

            map2 = new GMaps({
                el: selector,
                lat: marker1.latitude,
                lng: marker1.longtitude
            });
            map2.addMarker({
                lat: marker1.latitude,
                lng: marker1.longtitude,
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
                lat: marker2.latitude,
                lng: marker2.longtitude,
                title: 'Marker with InfoWindow',
                infoWindow: {
                    content: '<p>HTML Content</p>'
                }
            });
        }

        function clearDataForAddNew() {
            $(dom.shop.name).val('');
            $(dom.shop.address).val('');
            $(dom.shop.phone).val('');
            $(dom.shop.status).select({ selectedId: 0 });

            //address temp: 8534 Westminster Blvd., Westminster, CA 92683
            //clear google map (address)
            //...
        }
    }

    function getShopModel(callbackWithAddressInfo) {
        setShopModel(callbackWithAddressInfo);

        return shopModel;
    }

    function setShopModel(callbackWithAddressInfo) {
        var value = mapDOMintoModel();

        shopModel.name = value.name;
        shopModel.address = value.address;
        shopModel.phone = value.phone;
        shopModel.shopStatusId = value.shopStatusId;

        //it is promise (process for addressInfo)
        generatePosition(value.address).then(function(data) {
            callbackWithAddressInfo(data);
        });
    }

    function mapDOMintoModel() {
        var name = $(dom.editShop.name).val();
        var address = $(dom.editShop.address).val();
        var phone = $(dom.editShop.phone).val();

        var shopStatus = $(dom.editShop.status).select();
        var shopStatusId = shopStatus ? shopStatus[statusKeyBySelect.id] : null;

        return {
            name: name,
            address: address,
            phone: phone,
            shopStatusId: shopStatusId
        };
    }

    function generatePosition(address) {
        var geocoder = new google.maps.Geocoder();
        return geocoder.geocode( { 'address': address}, function(results, status) {
            if (status == 'OK') {
                var addressInfo = getAddressInfo(results[0]);
                return addressInfo;
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });

        function getItemInGeocodeResult(name, result) {
            var partNames = [
                    'street_number',
                    'route',
                    'locality',
                    'administrative_area_level_2',
                    'administrative_area_level_1',
                    'country',
                    'postal_code'];

            if (partNames.indexOf(name) >= 0) {
                var addressItems = result['address_components'];
                var value = getItemInAddressInfo(addressItems, name);
                return value;
            }

            partNames = ['formatted_address', 'place_id'];
            if (partNames.indexOf(name) >= 0) {
                return result[name];
            }

            if (name === 'location') {
                return result['geometry'][name];
            }

            return null;
        }

        function getItemInAddressInfo(addressItems, name) {
            for (var i = 0; i < addressItems.length; i++) {
                var addressItem = addressItems[i];
                if (addressItem.types[0] === name) {
                    return addressItem['long_name'];
                }
            }
        }

        function getAddressInfo(result) {
            var location = getItemInGeocodeResult('location', result);
            var placeId = getItemInGeocodeResult('place_id', result);
            var fullAddress = getItemInGeocodeResult('formatted_address', result);
            var areaName = getItemInGeocodeResult('administrative_area_level_2', result);
            var stateName = getItemInGeocodeResult('administrative_area_level_1', result);
            var countryName = getItemInGeocodeResult('country', result);
            return {
                placeId: placeId,
                latitude: location && location['lat'](),
                longtitude: location && location['lng'](),
                fullAddress: fullAddress,
                areaName: areaName,
                stateName: stateName,
                countryName: countryName
            };
        }
    }

    /*
    {
       "results" : [
          {
             "address_components" : [
                {
                   "long_name" : "1600",
                   "short_name" : "1600",
                   "types" : [ "street_number" ]
                },
                {
                   "long_name" : "Amphitheatre Parkway",
                   "short_name" : "Amphitheatre Pkwy",
                   "types" : [ "route" ]
                },
                {
                   "long_name" : "Mountain View",
                   "short_name" : "Mountain View",
                   "types" : [ "locality", "political" ]
                },
                {
                   "long_name" : "Santa Clara County",
                   "short_name" : "Santa Clara County",
                   "types" : [ "administrative_area_level_2", "political" ]
                },
                {
                   "long_name" : "California",
                   "short_name" : "CA",
                   "types" : [ "administrative_area_level_1", "political" ]
                },
                {
                   "long_name" : "Hoa Kỳ",
                   "short_name" : "US",
                   "types" : [ "country", "political" ]
                },
                {
                   "long_name" : "94043",
                   "short_name" : "94043",
                   "types" : [ "postal_code" ]
                }
             ],
             "formatted_address" : "1600 Amphitheatre Pkwy, Mountain View, CA 94043, Hoa Kỳ",
             "geometry" : {
                "location" : {
                   "lat" : 37.4223895,
                   "lng" : -122.0843123
                },
                "location_type" : "ROOFTOP",
                "viewport" : {
                   "northeast" : {
                      "lat" : 37.4237384802915,
                      "lng" : -122.0829633197085
                   },
                   "southwest" : {
                      "lat" : 37.42104051970851,
                      "lng" : -122.0856612802915
                   }
                }
             },
             "place_id" : "ChIJ2eUgeAK6j4ARbn5u_wAGqWA",
             "types" : [ "street_address" ]
          }
       ],
       "status" : "OK"
    }
    */


})();