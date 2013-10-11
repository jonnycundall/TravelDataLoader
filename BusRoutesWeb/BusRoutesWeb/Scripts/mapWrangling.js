$.ready = function () {
    var googleApisUri = 'http://maps.googleapis.com/maps/api/geocode/json?address={postcode}&sensor=false',
    populateLonLatBoxes = function (data) {
        var lng = data.results[0].geometry.location.lng,
            lat = data.results[0].geometry.location.lat;
        $('#Longitude').val(lng);
        $('#Latitude').val(lat);
        drawMap(lng, lat);
    },

    drawMap = function (lng, lat) {
        map = new OpenLayers.Map("mapdiv");
        var mapLayer = new OpenLayers.Layer.OSM();
        var fromProjection = new OpenLayers.Projection("EPSG:4326");
        var toProjection = new OpenLayers.Projection("EPSG:900913");
        var position = new OpenLayers.LonLat(lng, lat).transform(fromProjection, toProjection);
        var zoom = 15;
        map.addLayer(mapLayer);
        map.setCenter(position, zoom);
    };

    $('#findForm').submit(function (e) {
        var uri = googleApisUri.replace('{postcode}', $('#Postcode').val());
        $.post(uri, populateLonLatBoxes);
        return false;
    });
};

