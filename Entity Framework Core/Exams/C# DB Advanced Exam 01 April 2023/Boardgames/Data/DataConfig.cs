namespace Boardgames.Data
{
	public static class DataConfig
	{
		//Boardgame
		public const int BoardgameNameMinLength = 10;
		public const int BoardgameNameMaxLength = 20;

		public const int BoardgameRatingMinRange = 1;
		public const int BoardgameRatingMaxRange = 10;

		public const int BoardgameYearPublisherMinRange = 2018;
		public const int BoardgameYearPublisherMaxRange = 2023;

		//Seller
		public const int SellerNameMinLength = 5;
		public const int SellerNameMaxLength = 20;

		public const int SellerAddressMinLength = 2;
		public const int SellerAddressMaxLength = 30;

		//Creator
		public const int CreatorFirstNameMaxLength = 7;
		public const int CreatorFirstNameMinLength = 2;

		public const int CreatorLastNameMaxLength = 7;
		public const int CreatorLastNameMinLength = 2;
	}
}
