googleGeoDataProcessor = function () {
    this.prototype = Object.create(interfaces.GeoDataProcessor);

    var translateStatuses = function (googleStatus) {
        switch (googleStatus) {
            case 'OK': return 'OK'; break;
            case 'OVER_QUERY_LIMIT': return 'OVER_API_LIMIT'; break;
            case 'ZERO_RESULTS': return 'COULD_NOT_FIND'; break;
            default: return 'STATUS_NOT_RECOGNISED';

        }
    };

    this.processGeoData = function (data) {
        var status = translateStatuses(data.status);
        if (status != 'OK') return { status: status };
        return {
            lng: data.results[0].geometry.location.lng,
            lat: data.results[0].geometry.location.lat,
            status: translateStatuses(data.status),
        };
    };
};