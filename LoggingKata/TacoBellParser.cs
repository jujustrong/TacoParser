using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading;
using GeoCoordinatePortable;

namespace LoggingKata;

public class TacoBellParser
{
    static readonly ILog logger = new TacoLogger();
    const string csvPath = "TacoBell-US-AL.csv";
    
    public static void RunProgram()
    {
        logger.LogInfo("Log initialized");
        var lines = File.ReadAllLines(csvPath);
        if (lines.Length == 0 || lines.Length == 1)
        {
            logger.LogError("File has no input or not enough information");
        }
            
        logger.LogInfo($"Total number of locations: {lines.Length} / {lines.Length}");
            
        var parser = new TacoParser();
            
        var locations = lines.Select(x => parser.Parse(x)).ToArray();
            
        ITrackable tacoBell1 = null;
        ITrackable tacoBell2 = null;

        double distance = 0;
            
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
        Thread.Sleep(2000);
    }
}