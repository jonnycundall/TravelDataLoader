using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GeoJsonObjectModel;

namespace DataSetLoader.Repository
{
    public class MongoRepository : IRepository
    {
        private MongoServer _server;

        public void SaveStop(StopPoint stopPoint)
        {
            BsonDocument stopData = new BsonDocument 
            {
                { "Code", stopPoint.code },
                { "Longitude", stopPoint.longitude },
                { "Latitude", stopPoint.latitude }
            };

            Stops.Save(stopData);
            
        }

        public void SaveRoute(RawRoute route, IEnumerable<StopPoint> stops, GeoBounds bounds)
        {
            var coords = stops.Select(s => 
                    new GeoJson2DGeographicCoordinates(s.longitude, s.latitude));

            var line = new GeoJsonLineString<GeoJson2DGeographicCoordinates>(
                new GeoJsonLineStringCoordinates<GeoJson2DGeographicCoordinates>(coords));

            BsonDocument bsonRoute = new BsonDocument
            {
                {"RouteName", route.RouteName},
                {"stops" , line.ToBsonDocument()
                },
                {"maxLongitude",bounds.TopLeft.Longitude},
                {"minLongitude",bounds.BottomRight.Longitude},
                {"maxLatitude", bounds.BottomRight.Latitude},
                {"minLatitude",bounds.TopLeft.Latitude}
            };

            Routes.Save(bsonRoute);
        }


        public RawRoute GetRoute(RouteReference routeReference)
        {
            throw new NotImplementedException();
        }

        public StopPoint GetStop(StopReference stopReference)
        {
            var document = Stops.FindOneAs<BsonDocument>(Query.EQ("Code", stopReference.Reference));

            if (document == null)
            {
                LogError("stopNotFound", stopReference.Reference);
                return new StopNotFound();
            }

            return new StopPoint
            (document["Code"].AsString,
                document["Longitude"].AsDouble,
                document["Latitude"].AsDouble
            );
        }

        private MongoDatabase Database
        {
            get 
            {
                if (_server == null)
                {
                    string connectionString = "mongodb://127.0.0.1";
                    _server = MongoServer.Create(connectionString);
                    if (_server.State == MongoServerState.Disconnected)
                        _server.Connect(); 
                }

                return _server.GetDatabase("BusRoutes");
            }
        }

        public void LogError(string category, params string[] data)
        {
            Errors.Save(
                new BsonDocument{
                    {"category", category},
                    {"data", new BsonArray(data)}
                });
        }

        private MongoCollection Errors
        {
            get
            {
                return Database.GetCollection("errors");
            }
        }

        private MongoCollection Stops
        {
            get
            {
                return Database.GetCollection("stops");
            }
        }

        private MongoCollection Routes
        {
            get
            {
                return Database.GetCollection("routes");
            }
        }

        ~MongoRepository()
        {
            if (_server != null)
                _server.Disconnect();
        }
    }
}
