using System;
using System.Linq;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    public class BacklogItemStatus_Count : AbstractIndexCreationTask<BacklogItem, ReduceResult>
    {
        public BacklogItemStatus_Count()
        {
            Map = backlogItems => from item in backlogItems
                                  select new
                                             {
                                                 item.Status,
                                                 Occurrences = 1
                                             };

            Reduce = results => from result in results
                                group result by result.Status
                                    into g
                                    select new
                                               {
                                                   Status = g.Key,
                                                   Occurrences = g.Sum(x => x.Occurrences)
                                               };
        }
    }

    public class ReduceResult // needed for compile time support. RavenDB does this as dynamic
    {
        public String Status { get; set; }
        public int Occurrences { get; set; }
    }
}