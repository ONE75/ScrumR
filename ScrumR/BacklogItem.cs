using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrumR
{
    public class BacklogItemId : IValueObject
    {
    }

    public class BacklogItem : IAggregateRoot
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Story { get; set; }
        public int StoryPoints { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }

        //// all tasks in for this BacklogItem
        //public IList<Task> Tasks { get; set; }

        //// references to other Aggregates
        //public ProductId ProductId { get; set; }
        //public ReleaseId ReleaseId { get; set; }
        //public SprintId SprintId { get; set; }
    }

    //public class Task : IEntity
    //{
    //    public string Discription { get; set; }
    //    public int HoursRemaining { get; set; }
    //    public string Name { get; set; }
    //    public string Volunteer { get; set; }
    //}

    //public class SprintId : IValueObject
    //{
    //}

    //public class ReleaseId : IValueObject
    //{
    //}

    //public class ProductId : IValueObject
    //{
    //}
}
