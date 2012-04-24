using System;

namespace ScrumR
{
    public class SprintBuilder
    {
        private string _name = "First sprint";
        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today.AddDays(14);

        public SprintBuilder StartingOn(DateTime startDate)
        {
            _startDate = startDate;
            return this;
        }

        public SprintBuilder EndingOn(DateTime endDate)
        {
            _endDate = endDate;
            return this;
        }

        public Sprint Build()
        {
            return new Sprint()
                       {
                           StartDate = _startDate,
                           EndDate = _endDate,
                           Name = _name,
                       };
        }
    }
}