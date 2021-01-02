using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();

        public override string ToString() => Name;
        public static implicit operator string(Region region) => region?.ToString();
    }
}