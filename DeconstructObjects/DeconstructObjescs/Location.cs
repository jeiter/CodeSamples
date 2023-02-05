namespace DeconstructObjects
{
	public class Location
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public void Deconstruct(out double latitude, out double longitude)
		{
			latitude = Latitude;
			longitude = Longitude;
		}
	}
}
