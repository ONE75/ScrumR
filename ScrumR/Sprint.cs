using System;

namespace ScrumR
{
    public class Sprint : IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SprintStatusEnum SprintStatus { get; set; }
    }
}