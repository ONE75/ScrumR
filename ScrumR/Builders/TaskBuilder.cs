namespace ScrumR
{
    public class TaskBuilder
    {
        private string _name = "First task";
        private int _hoursRemaining = 4;
        private string _description = "Description of the first task";
        private string _volunteer = "Stijn Volders";

        public Task Build()
        {
            return new Task()
                       {
                           Name = _name,
                           Description = _description,
                           HoursRemaining = _hoursRemaining,
                           Volunteer = _volunteer
                       };
        }
    }
}