namespace DeconstructObjects;

internal class Program
{
    static void Main(string[] args)
    {
        // Example: deconstruct tuple
        (double latitude1, double longitude1) = GetLocation("Berlin");
        Console.WriteLine($"[Tuple] lat: {latitude1}, long: {longitude1}"); // lat: 52.5141156, long: 13.2857691


        // Example: deconstruct object
        var location = new Location
        {
            Latitude = 52.5141156,
            Longitude = 13.2857691
        };

        (double latitude2, double longitude2) = location;
        Console.WriteLine($"[Object] lat: {latitude2}, long: {longitude2}"); // lat: 52.5141156, long: 13.2857691


        // Example: deconstruct record
        (double latitude3, double longitude3) = new LocationRecord(52.5141156, 13.2857691);
        Console.WriteLine($"[Record] lat: {latitude3}, long: {longitude3}"); // lat: 52.5141156, long: 13.2857691
    }

    /// <summary>
    ///     Mock method to return location based on city
    /// </summary>
    /// <param name="city"></param>
    /// <returns>Location as tuple</returns>
    private static (double latitude, double longitude) GetLocation(string city)
    {
        if (city == "Berlin")
            return (52.5141156, 13.2857691);

        return (0, 0);
    }
}
