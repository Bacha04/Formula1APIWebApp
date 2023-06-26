using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Formula1APIWebApp.Models
{
    public class Driver
    {
        public Driver() 
        {
            RaceResults = new List<RaceResult>();
        }

        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        
        public int PersonalPoints { get; set; }
        
        public int Number { get; set; }

        public virtual  Team Team { get; set; }

        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
