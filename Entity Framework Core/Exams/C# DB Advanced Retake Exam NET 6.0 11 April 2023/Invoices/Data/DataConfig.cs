namespace Invoices.Data
{
	public static class DataConfig
	{
		//Name
		public const int NameMaxLength = 30;
		public const int NameMinLength = 9;

		public const int PriceMinRange = 5;
		public const int PriceMaxRange = 1000;

		//Address
		public const int StreetNameMaxLength = 20;
		public const int StreetNameMinLength = 10;

		public const int CityMaxLength = 15;
		public const int CityMinLength = 5;

		public const int CountryMaxLength = 15;
		public const int CountryMinLength = 5;

		//Invoice
		public const int NumberMaxRange = 1500000000;
		public const int NumberMinRange = 1000000000;

		//Client
		public const int ClientNameMaxLength = 25;
		public const int ClientNameMinLength = 10;

		public const int NumberVatMaxLength = 15;
		public const int NumberVatMinLength = 10;
	}
}
