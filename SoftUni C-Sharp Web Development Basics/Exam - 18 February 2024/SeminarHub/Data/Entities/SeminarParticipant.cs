using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Entities
{
	public class SeminarParticipant
	{
		[Required]
		[ForeignKey(nameof(Seminar))]
		public int SeminarId { get; set; }
		[Required]
		public Seminar Seminar { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Participant))]
		public string ParticipantId { get; set; } = null!;
		[Required]
		public IdentityUser Participant { get; set; } = null!;
	}
}
