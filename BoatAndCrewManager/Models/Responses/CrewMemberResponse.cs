using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses
{
    public class CrewMemberResponse
    {
        public string Id { get; set; }
        public string BoatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public CrewRole Role { get; set; }
        public DateOnly CertifiedUntil { get; set; }
        public string Picture{ get; set; }
        public string PictureName { get; set; }
        public string PictureType{ get; set; }
    }
}
