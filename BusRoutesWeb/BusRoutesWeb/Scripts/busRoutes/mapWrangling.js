$.ready = function () {
    'use strict';

    var // dependencies
        geoProvider = new googleGeoProvider(),
        geoDataProcessor = new googleGeoDataProcessor(),
        mapDrawer = new openLayersMapDrawer(),

    drawCentredMap = function (data) {
        var lonlat = geoDataProcessor.processGeoData(data);
        mapDrawer.drawMap(lonlat.lng, lonlat.lat);
    },

    logError = function (message) {
        $('#errors').append('<li>{message}</li>'.replace('{message}', message));
    },

    clearErrors = function () {
        $('#errors').html('');
    };

    $('#findForm').submit(function (e) {
        'use strict';
        var logGeoDataError = function () {
            alert('bar');
            logError('unable to contact google geocoding api')
        },
        useGeoData = function (data) {
            //con('foo');
            drawCentredMap(data);
        };

        clearErrors();
        
        //$.post('http://maps.googleapis.com/maps/api/geocode/json?address=BS34LL&sensor=false', useGeoData);
        geoProvider.getGeoData($('#Postcode').val(), useGeoData, logGeoDataError);
        return false;
    });
};

