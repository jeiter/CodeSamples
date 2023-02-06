namespace DeconstructObjects {
    internal class Program
    {
        static void Main(string[] args)
        {

            //(double latitude, double longitude) = GetLocation("Berlin");
            //Console.WriteLine($"lat: {latitude}, long: {longitude}"); // lat: 52.5141156, long: 13.2857691

            var location = new Location(52.5141156, 13.2857691);

            (double latitude, double longitude) = location;
            Console.WriteLine($"lat: {latitude}, long: {longitude}"); // lat: 52.5141156, long: 13.2857691
        }

        private static (double latitude, double longitude) GetLocation(string city)
        {
            if (city == "Berlin")
                return (52.5141156, 13.2857691);

            return (0, 0);
        }
    }
}
