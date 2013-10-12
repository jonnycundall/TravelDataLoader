googleGeoDataProcessor = function () {
    this.prototype = Object.create(interfaces.GeoDataProcessor);

    this.processGeoData = function (data) {
        return {
            lng: data.results[0].geometry.location.lng,
            lat: data.results[0].geometry.location.lat
        };
    };
};