using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
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