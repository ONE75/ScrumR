using System.Linq;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    public class BacklogItems_StoryPoint_Count : AbstractIndexCreationTask<BacklogItem, BacklogItems_StoryPoint_Count.ReduceResult>
    {
        public BacklogItems_StoryPoint_Count()
        {
            Map = items => from bli in items
                           select new
                                      {
                                          bli.StoryPoints,
                                          Counter = 1
                                      };

            Reduce = results => from countResult in results
                                group countResult by countResult.StoryPoints
                                    into g
                                    select new
                                               {
                                                   StoryPoints = g.Key,
                                                   Counter = g.Sum(x=> x.Counter)
                                               };
        }


        public class ReduceResult
        {
            public int StoryPoints { get; set; }
            public int Counter { get; set; }
        }
    }
}