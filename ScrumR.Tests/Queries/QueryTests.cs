using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using ScrumR.Tests.Persistance;
using Raven.Client.Linq;


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
            RavenQueryStatistics stats;
            var backlogItemsOwnedByMe = _session.Query<BacklogItem>()
                .Statistics(out stats)
                .Where(bli => bli.Owner == "Stijn Volders").ToList();
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
        public void BacklogItemStatusCount()
        {
            var result = _session.Query<BacklogItemStatus_Count.ReduceResult, BacklogItemStatus_Count>().ToList();
            foreach (var reduceResult in result)
            {
                Debug.WriteLine("status: {0}, # of backlog items: {1} ", reduceResult.Status, reduceResult.Occurrences);
            }
        }

        [Test]
        public void All_backlogItems_with_a_BusinessValue_equal_or_higher_than_Large()
        {
            var importantBacklogItems = _session.Query<BacklogItem>().Where(bli => bli.BusinessValue >= BusinessValue.L);
            var luceneQuery = importantBacklogItems.ToString();
            OutputBacklogItems("Important backlogitems", importantBacklogItems);
            Assert.AreEqual(6, importantBacklogItems.Count());
        }

        [Test]
        public void All_backlogItems_with_a_BusinessValue_equal_or_higher_than_Large_On_a_collection_in_memory()
        {
            var allbacklogitems = _session.Query<BacklogItem>().ToList();
            var importantBacklogItems = allbacklogitems.Where(bli => bli.BusinessValue >= BusinessValue.L);
            Assert.AreEqual(6, importantBacklogItems.Count());
        }

        [Test]
        public void Seach_BacklogItems_by_a_word_in_the_story()
        {
            var searchTerm = "BusinessValue";

            var results = _session.Query<BacklogItems_FullTextSearchOnStory.Query, BacklogItems_FullTextSearchOnStory>()
                .Where(x => x.Story == searchTerm)
                .As<BacklogItem>()
                .ToList();

            OutputBacklogItems("Matched the search term '" + searchTerm + "'", results);
        }

        [Test]
        public void QueryWithoutIndex()
        {
            var backlogitems = _session.Query<BacklogItem>().Where(bli => bli.Story.Contains("BusinessValue"));
            OutputBacklogItems("QuerywithoutIndex", backlogitems);
        }

        [Test]
        public void BacklogItem_paging_with_total_count()
        {
            RavenQueryStatistics statistics;
            var result = _session.Query<BacklogItem>()
                .Statistics(out statistics)
                .Take(5)
                .ToList();
            var listCount = result.Count;
            var totalCount = statistics.TotalResults;

            Assert.AreEqual(5, listCount);

            Debug.WriteLine("{0} backlogitems match the requested query", totalCount);
        }

        [Test]
        public void All_BacklogItems_ordered_by_Story()
        {
            RavenQueryStatistics stats;
            var query = _session.Query<BacklogItem>()
                .Statistics(out stats)
                .OrderBy(x => x.Story);

            Debug.WriteLine("Query: " + query.ToString());

            var results = query.ToList();


            OutputBacklogItems("Ordered BacklogItems", results);
            Debug.WriteLine("Used index: " + stats.IndexName);
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