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
        static void Main(string[] args)
        {
            while (TacoLogger.LogStartApp())
            { 
                TacoBellParser.RunProgram();
            }
        }
    }
}
