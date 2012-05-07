using System;

namespace ScrumR
{
    public class Task
    {
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        
        public Task()
        {
        }
    }
}