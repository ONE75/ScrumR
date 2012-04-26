using System;
using Raven.Client;
using Raven.Client.Indexes;
using ScrumR.Tests.Persistance;

namespace ScrumR.Common
{
    public class Initializer
    {
        private IDocumentSession _session;

        public void InsertSampleData(IDocumentSession session)
        {
            _session = session;

            AddSprints();
            AddBacklogItems();

            _session.SaveChanges();
        }

        public void CreateIndexes(IDocumentStore store)
        {
            IndexCreation.CreateIndexes(typeof(BacklogItems_FullTextSearchOnStory).Assembly, store); 
        }

        private void AddBacklogItems()
        {
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all BacklogItems", BusinessValue.XL));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all tasks that I own", BusinessValue.S));
            Store(BacklogItemForStory("As a user of ScrumR, I want an overview with BacklogItems per status", BusinessValue.XL));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see the total storypoints of remaining work", BusinessValue.L));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all BacklogItems with a BusinessValue equal or higher than L (Large)", BusinessValue.S));
            Store(BacklogItemForStory("As a user of ScrumR, I want to create tasks related to a BacklogItem", BusinessValue.XL));
            Store(BacklogItemForStory("As a user of ScrumR, I want to assign BacklogItems to a sprint", BusinessValue.XL));
            Store(BacklogItemForStory("As a user of ScrumR, I want to change the status of a SprintBacklogItem to Done", BusinessValue.L));
        }

        private void AddSprints() 
        {
            var sprintStartDate = new DateTime(2012, 4, 30);
            var sprintEndDate = sprintStartDate.AddDays(11);

            while (sprintEndDate < new DateTime(2012, 12, 31))
            {
                var sprint = new SprintBuilder()
                    .StartingOn(sprintStartDate)
                    .EndingOn(sprintEndDate)
                    .Build();
                _session.Store(sprint);

                sprintStartDate = sprintStartDate.AddDays(14);
                sprintEndDate = sprintEndDate.AddDays(14);
            }
        }

        private BacklogItem BacklogItemForStory(string story, BusinessValue businessValue)
        {
            return new BacklogItemBuilder()
                .ForStory(story)
                .OwnedBy("Stijn Volders")
                .EstimatedStoryPoints(4)
                .InStatus("Not done")
                .AddingBusinessValue(businessValue)
                .WithEstimatedComplexity(Complexity.L)
                .Build();
        }

        private void Store(BacklogItem backlogItem)
        {
            _session.Store(backlogItem);
        }
    }
}