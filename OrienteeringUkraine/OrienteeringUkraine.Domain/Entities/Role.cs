using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

        public override string ToString() => Name;
        public static implicit operator string(Role role) => role?.ToString();

    }
}