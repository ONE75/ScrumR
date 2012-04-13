using System.Linq;
using NUnit.Framework;
using Raven.Abstractions.Indexing;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class Indexes : RavenTest
    {
        [Test]
        public void CreateIndexes()
        {
            IndexCreation.CreateIndexes(typeof(Search_BacklogItems).Assembly, DocumentStore);
        }     
    }

    public class Search_BacklogItems : AbstractIndexCreationTask<BacklogItem>
    {
        public Search_BacklogItems()
        {
            Map = backlogitems => from backlogItem in backlogitems
                                  select new { backlogItem.Story };
            Index(x => x.Story, FieldIndexing.Analyzed);
        }
    }

}