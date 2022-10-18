using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzerverOf_5het.Models
{
    public class Hirdetes
    {
        [Key]
        public string Uid { get; set; }
        public string Pos { get; set; }
        public int Oraber { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        [NotMapped]
        public virtual SiteUser Owner { get; set; }

        public virtual ICollection<SiteUser> Applicants { get; set; }


        public Hirdetes()
        {
            Uid = Guid.NewGuid().ToString();
            Applicants = new List<SiteUser>();
        }
    }
}
