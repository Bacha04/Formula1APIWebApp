using System.ComponentModel.DataAnnotations;

namespace Formula1APIWebApp.Models
{
    public class Race
    {
        public Race()
        {
            RaceResults = new List<RaceResult>();
        }

        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
