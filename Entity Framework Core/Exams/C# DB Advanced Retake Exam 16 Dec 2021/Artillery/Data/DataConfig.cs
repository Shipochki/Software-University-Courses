namespace Artillery.Data
{
	public static class DataConfig
	{
		//Country
		public const int MinLengthCountryName = 4;
		public const int MaxLengthCountryName = 60;

		public const int MinRangeCountryArmySize = 50000;
		public const int MaxRangeCountryArmySize = 10000000;

		//Manufacturer
		public const int MinLengthManufacturerName = 4;
		public const int MaxLengthManufacturerName = 40;

		public const int MinLengthManufacturerFounded = 10;
		public const int MaxLengthManufacturerFounded = 100;

		//Shell
		public const int MinRangeShellWeight = 2;
		public const int MaxRangeShellWeight = 1680;

		public const int MinLengthShellCaliber = 4;
		public const int MaxLengthShellCaliber = 30;

		//Gun
		public const int MinRangeGunWeight = 100;
		public const int MaxRangeGunWeight = 1350000;

		public const int MinRangeGunBarrelLength = 2;
		public const int MaxRangeGunBarrelLength = 35;

		public const int MinRangeGunRange = 1;
		public const int MaxRangeGunRange = 100000;
	}
}
