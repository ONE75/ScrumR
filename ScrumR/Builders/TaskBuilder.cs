namespace ScrumR
{
    public class TaskBuilder
    {
        private string _name = "First task";
        private int _estimatedHours = 4;
        private string _description;
        private string _owner = "Stijn Volders";

        public TaskBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public TaskBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        public TaskBuilder WithEstimatedHours(int remainingHours)
        {
            _estimatedHours = remainingHours;
            return this;
        }

        public TaskBuilder OwnedBy(string owner)
        {
            _owner = owner;
            return this;
        }

        public Task Build()
        {
            return new Task()
                       {
                           Name = _name,
                           Description = _description,
                           EstimatedHours = _estimatedHours,
                           Owner = _owner
                       };
        }
    }
}