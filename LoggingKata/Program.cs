using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0 || lines.Length == 1)
            {
                logger.LogError("File has no input or not enough information");
            }
            
            logger.LogInfo($"Total number of locations: {lines.Length}");
            
            var parser = new TacoParser();
            
            var locations = lines.Select(x => parser.Parse(x)).ToArray();
            
            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            // TODO: Create a `double` variable to store the distance
            double distance = 0;

            // TODO: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            
            // TODO: Create a loop to go through each item in your collection of locations.
            // TODO: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude.
            // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
            // TODO: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.
            
            for (var i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;
                
                for (var j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }
            
            Thread.Sleep(2000);
            logger.LogInfo($"check complete...");
            Thread.Sleep(2000);
            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart from each other!");

        }
    }
}
