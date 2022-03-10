using System.ComponentModel.DataAnnotations;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation
{
    public class CreateCrewMemberSchema
    {

       
        
        public string Id { get; set; }
        public string Name { get; set; }


        public int Age { get; set; }

  
        public string Email { get; set; }

 
        public int Role { get; set; }


        public string CertifiedUntil { get; set; }

 
        public string BoatId { get; set; }

        public string Picture { get; set; }

    
        public string PictureName { get; set; }


        public string PictureType { get; set; }
    }
}
