$.ready = function () {
    'use strict';

    var // dependencies
        geoProvider = new googleGeoProvider(),
        geoDataProcessor = new googleGeoDataProcessor(),
        mapDrawer = new openLayersMapDrawer(),

    drawCentredMap = function (data) {
        var mapData = geoDataProcessor.processGeoData(data);

        if (mapData.status != 'OK') {
            logError("there was an error:" + mapData.status);
            return;
        }
        clearErrors();
        mapDrawer.drawMap(mapData.lng, mapData.lat);
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
            logError('unable to contact google geocoding api')
        };

        clearErrors();
        
        geoProvider.getGeoData($('#Postcode').val(), drawCentredMap, logGeoDataError);
        return false;
    });
};

