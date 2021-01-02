namespace OrienteeringUkraine.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int? Chip { get; set; }

        public string UserLogin { get; set; }
        public virtual User User { get; set; }


        public int EventGroupId { get; set; }
        public virtual EventGroup EventGroup { get; set; }

        public Group Group => EventGroup?.Group;
        public Event Event => EventGroup?.Event;


    }
}