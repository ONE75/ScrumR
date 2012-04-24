using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrumR
{
    public class BacklogItem : IAggregateRoot
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Story { get; set; }
        public int StoryPoints { get; set; }
        public string Summary { get; set; }

        private IList<Task> Tasks { get; set; }

        public BacklogItem()
        {
            this.Tasks = new List<Task>();
        }

        public BacklogItem(string story)
            : this()
        {
            this.Story = story;
        }

        public void ScheduleIn(Sprint sprint)
        {
            this.SprintId = sprint.Id;
        }

        public string SprintId { get; set; }

        public string Owner { get; set; }

        public BusinessValue BusinessValue { get; set; }

        public void AddTask(Task task)
        {
            if (this.Tasks == null)
                this.Tasks = new List<Task>();
            this.Tasks.Add(task);
        }

        public bool HasTasks
        {
            get {return this.Tasks.Any();}
        }

        public bool IsUnassigned
        {
            get { return this.SprintId == null; }
        }
    }
}
