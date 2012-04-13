namespace ScrumR
{
    public class BacklogItemBuilder
    {
        private string _id;
        private string _status = "Not done";
        private string _story;
        private int _storyPoints;
        private string _summary;
        private string _owner;
        
        public BacklogItemBuilder ForStory(string story)
        {
            _story = story;
            return this;
        }

        public BacklogItemBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public BacklogItemBuilder WithSummary(string summary)
        {
            _summary = summary;
            return this;
        }

        public BacklogItemBuilder EstimatedStoryPoints(int storyPoints)
        {
            _storyPoints = storyPoints;
            return this;
        }

        public BacklogItemBuilder InStatus(string status)
        {
            _status = status;
            return this;
        }

        public BacklogItemBuilder OwnedBy(string owner)
        {
            _owner = owner;
            return this;
        }
        
         public BacklogItem Build()
         {
             var backlogItem = new BacklogItem()
                                   {
                                       Id = _id,
                                       Status = _status,
                                       Story = _story,
                                       StoryPoints = _storyPoints,
                                       Summary = _summary,
                                       Owner = _owner
                                   };
             return backlogItem;
         }
    }
}