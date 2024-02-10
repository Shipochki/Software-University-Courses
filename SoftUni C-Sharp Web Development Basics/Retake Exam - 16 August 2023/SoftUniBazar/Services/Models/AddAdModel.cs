using SoftUniBazar.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Services.Models
{
    public class AddAdModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(15)]
        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 25 (required)
//•	Has Description – a string with min length 15 and max length 250 (required)
//•	Has Price – a decimal (required)
//•	Has OwnerId – a string (required)
//•	Has Owner – an IdentityUser (required)
//•	Has ImageUrl – a string (required)
//•	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has CategoryId – an integer, foreign key (required)
//•	Has Category – a Category (required)
