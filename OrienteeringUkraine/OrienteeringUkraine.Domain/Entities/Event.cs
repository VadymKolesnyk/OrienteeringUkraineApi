using System;
using System.Collections.Generic;

namespace OrienteeringUkraine.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string InfoLink { get; set; }
        public string ResultsLink { get; set; }
        public string Location { get; set; }

        public bool? IsApplicationOpen { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public string OrganizerLogin { get; set; }
        public virtual User Organizer { get; set; }

        public virtual ICollection<EventGroup> EventGroups { get; set; } = new HashSet<EventGroup>();
        public virtual ICollection<Group> Groups { get; set; } = new HashSet<Group>();
    }
}