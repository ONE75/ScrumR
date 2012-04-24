using System.Linq;
using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class BacklogItemPersistanceTests : RavenTest
    {
        [Test]
        public void BacklogItem_can_be_Saved()
        {
            var backlogItem = new BacklogItemBuilder()
                .WithId("backlogitems/1")
                .ForStory("As a user of ScrumR, I want to see all tasks that I volunteered for")
                .OwnedBy("Stijn Volders")
                .EstimatedStoryPoints(6)
                .InStatus("Not done")
                .AddingBusinessValue(BusinessValue.XL)
                .WithEstimatedComplexity(Complexity.XL)
                .Build();

            _session.Store(backlogItem);
            _session.SaveChanges();
        }

        [Test]
        public void GetBacklogItemWithoutRequiredProperty()
        {
            var bli = _session.Load<BacklogItem>("backlogitems/1");
            Assert.IsNotNull(bli);
           _session.SaveChanges();
        }

        [Test]
        public void BacklogItem_can_be_scheduled_in_sprint()
        {
            var sprint = _session.Load<Sprint>(1);
            var backLogItem = _session.Load<BacklogItem>(1);

            backLogItem.ScheduleIn(sprint);

            _session.SaveChanges();
        }

        [Test]
        public void Task_can_be_added_to_BacklogItem()
        {
            var task = new TaskBuilder().Build();
            var backLogItem = _session.Load<BacklogItem>(1);

            backLogItem.AddTask(task);
            _session.SaveChanges();

            Assert.IsTrue(backLogItem.HasTasks);
        }

        [Test]
        public void Query()
        {
            var allTasksCount = _session.Query<BacklogItem>().Count();
            Assert.IsTrue(allTasksCount >= 8);
        }

        [Test]
        public void Query_on_status()
        {
            var allTasks = _session.Query<BacklogItem>().Where(bli => bli.Status == "Not done");
            Assert.IsTrue(allTasks.Count() >= 8);
        }

        [Test]
        public void Query_All_unassigned_items_via_property()
        {
            var allUnAssignedTasks = _session.Query<BacklogItem>().Where(bli => bli.SprintId == null);
            Assert.IsNotNull(allUnAssignedTasks);
        }

        [Test]
        public void Query_All_unassigned_items_via_wrapped_method()
        {
            var allUnAssignedTasks = _session.Query<BacklogItem>().Where(bli => bli.IsUnassigned).ToList();
            Assert.IsNotNull(allUnAssignedTasks);
        }
    }
}