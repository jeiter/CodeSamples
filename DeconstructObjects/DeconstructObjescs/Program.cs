namespace DeconstructObjects {
    internal class Program
    {
        static void Main(string[] args)
        {
            var location = new Location
            {
                Latitude = 52.5141156,
                Longitude = 13.2857691,
            };

            (double latitude, double longitude) = location;
            Console.WriteLine($"lat: {latitude}, long: {longitude}"); // lat: 52.5141156, long: 13.2857691
        }
    }
}
