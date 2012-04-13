namespace ScrumR
{
    public class Task : IEntity
    {
        public string Description { get; set; }
        public int HoursRemaining { get; set; }
        public string Name { get; set; }
        public string Volunteer { get; set; }
    }
}