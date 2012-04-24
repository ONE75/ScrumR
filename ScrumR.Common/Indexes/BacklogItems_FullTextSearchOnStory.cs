using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance 
{
    public class BacklogItems_FullTextSearchOnStory : AbstractIndexCreationTask<BacklogItem>
    {
        public BacklogItems_FullTextSearchOnStory()
        {
            Map = backlogitems => from backlogItem in backlogitems
                                  select new { backlogItem.Story };
            
            Index(x => x.Story, FieldIndexing.Analyzed);
        }
    }
}