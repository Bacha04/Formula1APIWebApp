using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Formula1APIWebApp.Models
{
    public class Team
    {
      public Team() 
        {
            Drivers = new List<Driver>();
        }

        [Key]
        public int Id { get; set; }

       
        public string Name { get; set; }

        public string Country { get; set; }

        public int Points { get; set; }




        public virtual ICollection<Driver> Drivers { get; set;}
    }
}
