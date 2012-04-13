using System;

namespace ScrumR
{
    public class SprintBuilder
    {
        private string _name = "First sprint";
        private int _capacity = 100;
        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today.AddDays(14);
        private SprintStatusEnum _status = SprintStatusEnum.InProgress;

        public Sprint Build()
        {
            return new Sprint()
                       {
                           Capacity = _capacity,
                           StartDate = _startDate,
                           EndDate = _endDate,
                           Name = _name,
                           SprintStatus = _status
                       };
        }
    }
}