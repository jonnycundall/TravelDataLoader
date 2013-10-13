googleGeoProvider = function () {
    this.prototype = Object.create(interfaces.GeoProvider);
    var googleApisUri = 'http://maps.googleapis.com/maps/api/geocode/json?address={postcode}&sensor=false';
    this.getGeoData = function (location, callback, failureCallback) {
            var uri = googleApisUri.replace('{postcode}', location);

            $.ajax(uri)
                .done(callback)
                .fail(failureCallback);

            return false;
        };

};