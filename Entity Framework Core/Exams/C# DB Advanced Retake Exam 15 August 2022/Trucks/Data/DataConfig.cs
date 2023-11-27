namespace Trucks.Data
{
	public static class DataConfig
	{
		// Truck
		public const int LengthRegistrationNumber = 8;

		public const int LengthVinNumber = 17;

		public const int MinRangeTankCapacity = 950;
		public const int MaxRangeTankCapacity = 1420;

		public const int MinRangeCargoCapacity = 5000;
		public const int MaxRangeCargoCapacity = 29000;

		//Client
		public const int MinLengthClinetName = 3;
		public const int MaxLengthClientName = 40;

		public const int MinLengthNationality = 2;
		public const int MaxLengthNationality = 40;

		//Despatcher
		public const int MinLengthDespatcherName = 2;
		public const int MaxLengthDespatcherName = 40;
	}
}
