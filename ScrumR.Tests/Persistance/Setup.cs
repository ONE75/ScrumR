using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class Setup : RavenTest
    {
        [Test]
        public void InsertBacklogItems()
        {
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all BacklogItems"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see all tasks that I volunteered for"));
            Store(BacklogItemForStory("As a user of ScrumR, I want an overview with BacklogItems per status"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see the total storypoints of the remaining work"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see the velocity per sprint"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to create tasks related to a BacklogItem"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to assign BacklogItems to a sprint"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to see the history of the bugcount (of the last month)"));
            Store(BacklogItemForStory("As a user of ScrumR, I want to change the status of a SprintBacklogItem to Done"));

            _session.SaveChanges();
        }

        private BacklogItem BacklogItemForStory(string story)
        {
            return new BacklogItemBuilder()
                .ForStory(story)
                .OwnedBy("Stijn Volders")
                .EstimatedStoryPoints(4)
                .InStatus("Not done")
                .Build();
        }

        private void Store(BacklogItem backlogItem)
        {
            _session.Store(backlogItem);
        }
    }
}