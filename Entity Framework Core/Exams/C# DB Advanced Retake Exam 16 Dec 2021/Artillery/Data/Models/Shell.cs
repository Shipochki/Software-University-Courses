namespace Artillery.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Shell
	{
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		public double ShellWeight { get; set; }

		[Required]
		[MaxLength(MaxLengthShellCaliber)]
		public string Caliber { get; set; } = null!;

		public ICollection<Gun> Guns { get; set; }
	}
}
