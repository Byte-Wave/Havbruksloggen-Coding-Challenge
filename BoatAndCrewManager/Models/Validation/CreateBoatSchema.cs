using System.ComponentModel.DataAnnotations;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation
{
    public class CreateBoatSchema
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public int BuildNumber { get; set; }

        [Required]
        public float MaximumLength { get; set; }

        [Required]
        public float MaximumWidth { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string PictureName { get; set; }

        [Required]
        public string PictureType { get; set; }
    }
}
