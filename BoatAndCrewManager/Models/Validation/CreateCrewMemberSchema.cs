using System.ComponentModel.DataAnnotations;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation
{
    public class CreateCrewMemberSchema
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public CrewRole Role { get; set; }

        [Required]
        public DateTime CertifiedUntil { get; set; }

        [Required]
        public string BoatId { get; set; }

        public string Picture { get; set; }

        [Required]
        public string PictureName { get; set; }

        [Required]
        public string PictureType { get; set; }
    }
}
