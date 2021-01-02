using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EventGroup> EventGroups { get; set; } = new HashSet<EventGroup>();
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();

        public override string ToString() => Name;
        public static implicit operator string(Group group) => group?.ToString();

    }
}