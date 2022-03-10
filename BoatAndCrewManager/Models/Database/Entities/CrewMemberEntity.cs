namespace Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities
{
    public class CrewMemberEntity
    {
        public Guid Id { get; set; }
        public Guid BoatId { get; set; }
        public virtual BoatEntity Boat { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
        public string Email { get; set; }
        public CrewRole Role { get; set; }
        public DateOnly CertifiedUntil { get; set; }
        public string PicturesPath { get; set; }

    }

    public enum CrewRole
    {
        Captain = 100,
        DeckCadet = 200,
        ChiefEngineer = 300,
        MotorMan = 400
    }
}
