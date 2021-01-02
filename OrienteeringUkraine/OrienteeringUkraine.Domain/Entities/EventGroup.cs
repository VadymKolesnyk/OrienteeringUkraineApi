using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class EventGroup
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}