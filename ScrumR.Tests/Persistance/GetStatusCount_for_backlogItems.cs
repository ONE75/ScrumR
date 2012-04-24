using System;
using System.Linq;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    public class GetStatusCount_for_backlogItems : AbstractIndexCreationTask<BacklogItem, ReduceResult>
    {
        public GetStatusCount_for_backlogItems()
        {
            Map = backlogItems => from bli in backlogItems
                                  select new
                                             {
                                                 Status = bli.Status,
                                                 Occurrences = 1
                                             };

            Reduce = results => from result in results
                                group result by result.Status
                                    into g
                                    select new
                                               {
                                                   Status = g.Key,
                                                   Occurrences = g.Sum(x => x.Occurrences) // x.Occurrences is unknown 
                                               };
        }
    }

    public class ReduceResult
    {
        public String Status { get; set; }
        public int Occurrences { get; set; }
    }
}