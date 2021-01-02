using OrienteeringUkraine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Domain.Entities
{
    public class User
    {
        public string Login { get; set; }
        public virtual LoginData LoginData { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Surname + " " + Name;
        public DateTime? BirthDate { get; set; }

        public Sex? Sex { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public int? ClubId { get; set; }
        public virtual Club Club { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new HashSet<Application>();
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
