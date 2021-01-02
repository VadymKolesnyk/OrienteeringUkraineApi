namespace OrienteeringUkraine.Domain.Entities
{
    public class LoginData
    {
        public string Login { get; set; }
        public virtual User User { get; set; }
        public string HashedPassword { get; set; }
    }
}