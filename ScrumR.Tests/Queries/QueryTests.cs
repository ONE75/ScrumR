using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using ScrumR.Tests.Persistance;

namespace ScrumR.Tests.Queries
{
    [TestFixture]
    public class QueryTests : RavenTest
    {
        [Test]
        public void All_BacklogItems()
        {
            var allBacklogItems = _session.Query<BacklogItem>().ToList();
            OutputBacklogItems("All BacklogItems", allBacklogItems);
        }

        [Test]
        public void All_tasks_that_I_own()
        {
            var backlogItemsOwnedByMe = _session.Query<BacklogItem>().Where(bli => bli.Owner == "Stijn Volders").ToList();
            OutputBacklogItems("All BacklogItems owned by me", backlogItemsOwnedByMe);
        }

        [Test]
        public void BacklogItems_per_status()
        {
            var notDone = _session.Query<BacklogItem>().Where(bli => bli.Status == "Not Done");
            OutputBacklogItems("BacklogItems in status 'Not Done'", notDone);

            var inProgress = _session.Query<BacklogItem>().Where(bli => bli.Status == "In Progress");
            OutputBacklogItems("BacklogItems in status 'In Progress'", inProgress);

            var done = _session.Query<BacklogItem>().Where(bli => bli.Status == "Done");
            OutputBacklogItems("BacklogItems in status 'Done'", done);
        }

        [Test]
        public void Total_storypoints_of_remaining_work()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void All_backlogItems_with_a_BusinessValue_equal_or_higher_than_Large()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Seach_BacklogItems_by_a_word_in_the_story()
        {
            throw new NotImplementedException();
        }   

        private void OutputBacklogItems(string queryDescription, IEnumerable<BacklogItem> backlogItems)
        {
            Debug.WriteLine("Showing output for " + queryDescription);
            foreach (var allBacklogItem in backlogItems)
            {
                Debug.WriteLine(allBacklogItem.Story);
            }
            Debug.WriteLine("");
        }
    }
}