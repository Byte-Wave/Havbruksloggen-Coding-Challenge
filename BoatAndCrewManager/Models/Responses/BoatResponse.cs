namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses
{
    public class BoatResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int BuildNumber { get; set; }
        public double MaximumLength { get; set; }
        public double MaximumWidth { get; set; }
        public string PictureUrl { get; set; }
    }
}
