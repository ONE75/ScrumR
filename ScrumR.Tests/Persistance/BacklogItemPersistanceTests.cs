using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Raven.Client.Linq;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class BacklogItemPersistanceTests : RavenTest
    {
        [Test]
        public void BacklogItem_can_be_Saved()
        {
            var backlogItem = new BacklogItemBuilder()
                .WithId("BacklogItems/1")
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
        public void BacklogItem_can_be_scheduled_in_sprint()
        {
            var sprint = _session.Load<Sprint>(33);
            if (sprint == null)
                throw new NullReferenceException("Sprint not found!");

            var backLogItem = _session.Load<BacklogItem>(1);

            backLogItem.ScheduleIn(sprint);

            _session.SaveChanges();
        }

        [Test]
        public void Task_can_be_added_to_BacklogItem()
        {
            var addViewTask = new TaskBuilder()
                .WithName("Create asp.net mvc listview")
                .OwnedBy("Stijn Volders")
                .WithEstimatedHours(2)
                .Build();

            var createControllerMethodsTask = new TaskBuilder()
                .WithName("Create BacklogItemController with listview support")
                .OwnedBy("Stijn Volders")
                .WithEstimatedHours(1)
                .Build();

            var backLogItem = _session.Load<BacklogItem>(1);

            backLogItem.AddTask(addViewTask);
            backLogItem.AddTask(createControllerMethodsTask);


            _session.SaveChanges();

            Assert.IsTrue(backLogItem.Tasks.Any());
        }

        [Test]
        public void WaitForStaleResults()
        {
            var backlogItem = new BacklogItemBuilder()
                .WithId("backlogitems/1")
                .ForStory("As a user of ScrumR, I don't want stale indexes")
                .OwnedBy("Stijn Volders")
                .EstimatedStoryPoints(6)
                .InStatus("Not done")
                .AddingBusinessValue(BusinessValue.XS)
                .WithEstimatedComplexity(Complexity.XS)
                .Build();

            _session.Store(backlogItem);
            _session.SaveChanges();

            RavenQueryStatistics stats;
            var staleIndexBacklogItem = _session.Query<BacklogItem>().Where(bli => bli.Story == "As a user of ScrumR, I don't want stale indexes")
                    .Statistics(out stats)
                    .Customize(x => x.WaitForNonStaleResults(TimeSpan.FromSeconds(5)));
            
            Assert.IsNotNull(staleIndexBacklogItem);
            Debug.WriteLine(stats.IsStale);



        }
    }
}