using System;
using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class InitializationTest : RavenTest
    {
        [Test]
        public void InsertSampleData()
        {
            AddSprints();
            AddBacklogItems();

            _session.SaveChanges();
        }

        private void AddBacklogItems()
        {
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all BacklogItems"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all tasks that I own"));
            Store(BacklogItemForStory("As a user of ScrumR, I want an overview with BacklogItems per status"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see the total storypoints of remaining work"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all BacklogItems with a BusinessValue equal or higher than L (Large)"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to create tasks related to a BacklogItem"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to assign BacklogItems to a sprint"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to change the status of a SprintBacklogItem to Done"));
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

        private BacklogItem BacklogItemForStory(string story)
        {
            return new BacklogItemBuilder()
                .ForStory(story)
                .OwnedBy("Stijn Volders")
                .EstimatedStoryPoints(4)
                .InStatus("Not done")
                .AddingBusinessValue(BusinessValue.XL)
                .WithEstimatedComplexity(Complexity.L)
                .Build();
        }

        private void Store(BacklogItem backlogItem)
        {
            _session.Store(backlogItem);
        }
    }
}