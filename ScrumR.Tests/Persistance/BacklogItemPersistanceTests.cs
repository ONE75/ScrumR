using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class BacklogItemPersistanceTests : RavenTest
    {


        [Test]
        public void BacklogItem_can_be_Saved()
        {
            var backlogItem = new BacklogItem();
            backlogItem.Status = "Not done";
            backlogItem.Story = "As a user of ScrumR, I want to see all tasks that I volunteered for";
            backlogItem.StoryPoints = 6;
            backlogItem.Summary = "A brief summary of this story.";
            backlogItem.Type = "Product Backlog item";

            _session.Store(backlogItem);
            _session.SaveChanges();
        }
    }
}