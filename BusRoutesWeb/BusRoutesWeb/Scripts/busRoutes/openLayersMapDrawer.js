openLayersMapDrawer = function () {
    this.prototype = Object.create(interfaces.MapDrawer);

    this.drawMap = function (lng, lat) {
        $('#mapdiv').empty();
        map = new OpenLayers.Map("mapdiv");
        var mapLayer = new OpenLayers.Layer.OSM();
        var fromProjection = new OpenLayers.Projection("EPSG:4326");
        var toProjection = new OpenLayers.Projection("EPSG:900913");
        var position = new OpenLayers.LonLat(lng, lat).transform(fromProjection, toProjection);
        var zoom = 15;
        map.addLayer(mapLayer);
        map.setCenter(position, zoom);
    }
};