using System;

namespace ScrumR
{
    public class Task
    {
        public string TaskId { get; set; }
        public string Description { get; set; }
        public int HoursRemaining { get; set; }
        public string Name { get; set; }
        public string Volunteer { get; set; }
        public string BacklogItemId { get; set; }

        public Task(string backlogItemId)
        {
            this.BacklogItemId = backlogItemId;
        }
    }
}