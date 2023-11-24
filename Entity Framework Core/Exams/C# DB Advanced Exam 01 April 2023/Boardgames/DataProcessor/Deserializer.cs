namespace Boardgames.DataProcessor
{
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;
	using Boardgames.Data;
	using Boardgames.Data.Models;
	using Boardgames.Data.Models.Enums;
	using Boardgames.DataProcessor.ImportDto;
	using Newtonsoft.Json;

	public class Deserializer
	{
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
			StringBuilder sb = new StringBuilder();

			XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCreatorDto[]), xmlRoot);

			using StringReader reader = new StringReader(xmlString);
            ImportCreatorDto[] importCreatorDtos = (ImportCreatorDto[])xmlSerializer.Deserialize(reader);

            ICollection<Creator> creators = new List<Creator>();

            foreach (var cDto in importCreatorDtos)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = cDto.FirstName,
                    LastName = cDto.LastName,
                };

                foreach (var bDto in cDto.Boardgames)
                {
                    if (!IsValid(bDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = bDto.Name,
                        Rating = bDto.Rating,
                        YearPublished = bDto.YearPublished,
                        CategoryType = (CategoryType)bDto.CategoryType,
                        Mechanics = bDto.Mechanics,
                        CreatorId = creator.Id,
                        Creator = creator,
                    };

                    creator.Boardgames.Add(boardgame);
                }

                creators.Add(creator);

                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportSellerDto[] importSellerDtos =
                JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString); 

            ICollection<Seller> sellers = new List<Seller>();

            foreach (var sDto in importSellerDtos)
            {
                if (!IsValid(sDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sDto.Name,
                    Address = sDto.Address,
                    Country = sDto.Country,
                    Website = sDto.Website,
                };

                foreach (var bId in sDto.Boardgames.Distinct())
                {
                    Boardgame boardgame = context.Boardgames.Find(bId);

                    if(boardgame == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    seller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        Boardgame = boardgame,
                    });
                }

                sellers.Add(seller);

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
