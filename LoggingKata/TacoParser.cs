namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Parse Success...");
            
            var cells = line.Split(',');
            
            if (cells.Length < 3)
            {
                logger.LogError("Not enough information");
                return null; 
            }

            // TODO: Grab the latitude from your array at index 0
            var lati  = double.Parse(cells[0]);
            
            
            // TODO: Grab the longitude from your array at index 1
            var longi  = double.Parse(cells[1]);
            
            
            // TODO: Grab the name from your array at index 2
            var name  = cells[2];
            
            // TODO: Create an instance of the Point Struct
            // TODO: Set the values of the point correctly (Latitude and Longitude)
            var point1 = new Point();
            point1.Longitude = longi;
            point1.Latitude = lati;

            // TODO: Create an instance of the TacoBell class
            // TODO: Set the values of the class correctly (Name and Location)
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point1;

            // TODO: Then, return the instance of your TacoBell class,
            return tacoBell;
        }
    }
}
