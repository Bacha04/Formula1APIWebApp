namespace Formula1APIWebApp.Models
{
    public class RaceResult
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public int RaceId { get; set; }

        public int StartPosition { get; set; }
        public int FinishPosition { get; set; }

        public virtual Race Race { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
