using System;

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
        private BusinessValue _businessValue = BusinessValue.XL;
        private Complexity _complexity;

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

        public BacklogItemBuilder AddingBusinessValue(BusinessValue size)
        {
            _businessValue = size;
            return this;
        }

        public BacklogItemBuilder WithEstimatedComplexity(Complexity complexity)
        {
            _complexity = complexity;
            return this;
        }
        
         public BacklogItem Build()
         {
             var backlogItem = new BacklogItem(_story)
                                   {
                                       Id = _id,
                                       Status = _status,
                                       StoryPoints = _storyPoints,
                                       Summary = _summary,
                                       Owner = _owner,
                                       BusinessValue = _businessValue
                                   };
             return backlogItem;
         }
    }
}