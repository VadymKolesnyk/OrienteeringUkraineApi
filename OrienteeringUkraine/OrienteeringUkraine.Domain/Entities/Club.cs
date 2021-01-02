using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public override string ToString() => Name;
        public static implicit operator string(Club club) => club?.ToString();
    }
}