namespace Artillery.DataProcessor
{
    using Artillery.Data;
	using Artillery.Data.Models;
	using Artillery.DataProcessor.ImportDto;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Text.Json.Serialization;
	using System.Xml.Serialization;
    using Data.Models.Enums;
	using System.Linq;

	public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDbo[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCountryDbo[] importCountryDbos = (ImportCountryDbo[])xmlSerializer.Deserialize(reader);

            ICollection<Country> countries = new List<Country>();

            foreach (var cDbo in importCountryDbos)
            {
                if (!IsValid(cDbo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = cDbo.CountryName,
                    ArmySize = cDbo.ArmySize,
                };

                countries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportManufacturerDto[] importManufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Manufacturer> manufacturers = new List<Manufacturer>();

            foreach (var mDto in importManufacturerDtos)
            {
                if (!IsValid(mDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(manufacturers.Any(m => m.ManufacturerName == mDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = mDto.ManufacturerName,
                    Founded = mDto.Founded,
                };

                manufacturers.Add(manufacturer);

                string[] founded = manufacturer.Founded.Split(", ").ToArray();
                string town = founded[founded.Length - 2];
                string country = founded[founded.Length - 1];

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, town + ", " + country));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportShellDto[] importShellDtos = (ImportShellDto[])xmlSerializer.Deserialize(reader);

            ICollection<Shell> shells = new List<Shell>();

            foreach (var sDto in importShellDtos)
            {
                if (!IsValid(sDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = sDto.ShellWeight,
                    Caliber = sDto.Caliber,
                };

                shells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells); 
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
			string[] validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
			StringBuilder sb = new StringBuilder();

            ImportGunDto[] importGunDtos =
                JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            ICollection<Gun> guns = new List<Gun>();

            foreach (var gDto in importGunDtos)
            {
                if (!IsValid(gDto) || !validGunTypes.Contains(gDto.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = context.Manufacturers.Find(gDto.ManufacturerId);
                Shell shell = context.Shells.Find(gDto.ShellId);

                Gun gun = new Gun()
                {
                    ManufacturerId = gDto.ManufacturerId,
                    Manufacturer = manufacturer,
                    GunWeight = gDto.GunWeight,
                    BarrelLength = gDto.BarrelLength,
                    NumberBuild = gDto.NumberBuild,
                    Range = gDto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gDto.GunType),
                    ShellId = gDto.ShellId,
                    Shell = shell,
                };

                foreach (var cDto in gDto.Countries)
                {
                    Country country = context.Countries.Find(cDto.Id);

                    gun.CountriesGuns.Add(new CountryGun()
                    {
                        CountryId = cDto.Id,
                        Country = country,
                        GunId = gun.Id,
                        Gun = gun,
                    });
                }

                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));

                guns.Add(gun);
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}