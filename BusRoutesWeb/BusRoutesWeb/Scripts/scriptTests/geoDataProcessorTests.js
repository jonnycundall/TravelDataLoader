(function(processor){

    describe("lonlat", function () {
        var googleData = {
                "results": [
                   {
                       "address_components": [
                          {
                              "long_name": "BS5 5LL",
                              "short_name": "BS5 5LL",
                              "types": ["postal_code"]
                          },
                          {
                              "long_name": "Bristol",
                              "short_name": "Bristol",
                              "types": ["locality", "political"]
                          },
                          {
                              "long_name": "City of Bristol",
                              "short_name": "City of Bristol",
                              "types": ["administrative_area_level_2", "political"]
                          },
                          {
                              "long_name": "United Kingdom",
                              "short_name": "GB",
                              "types": ["country", "political"]
                          },
                          {
                              "long_name": "Bristol",
                              "short_name": "Bristol",
                              "types": ["postal_town"]
                          }
                       ],
                       "formatted_address": "Bristol, City of Bristol BS5 5LL, UK",
                       "geometry": {
                           "bounds": {
                               "northeast": {
                                   "lat": 51.4406003,
                                   "lng": -2.5885434
                               },
                               "southwest": {
                                   "lat": 51.4393663,
                                   "lng": -2.5908011
                               }
                           },
                           "location": {
                               "lat": 51.8897189,
                               "lng": -2.7703315
                           },
                           "location_type": "APPROXIMATE",
                           "viewport": {
                               "northeast": {
                                   "lat": 51.8813322802915,
                                   "lng": -2.778323269708498
                               },
                               "southwest": {
                                   "lat": 51.4386343197085,
                                   "lng": -2.591021230291501
                               }
                           }
                       },
                       "types": ["postal_code"]
                   }
                ],
                "status": "OK"
            };

        it("gets longitude and latitude from data", function () {
            var processedData = processor.processGeoData(googleData);
            expect(processedData.lat).toEqual(51.8897189);
            expect(processedData.lng).toEqual(-2.7703315);
        });
    });

})(new googleGeoDataProcessor());
