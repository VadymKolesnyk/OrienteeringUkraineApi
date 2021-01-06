using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Users.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public string Role { get; set; }
        public string Region { get; set; }
        public string Club { get; set; }
    }
}
