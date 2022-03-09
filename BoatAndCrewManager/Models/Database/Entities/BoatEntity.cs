using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities
{
    public class BoatEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int BuildNumber { get; set; }
        public double MaximumLength { get; set; }
        public double MaximumWidth { get; set; }
        public string PicturesPath { get; set; }
        public virtual List<CrewMemberEntity> CrewMembers { get; set; }

    }
}
