using System.Linq;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    public class GetStatusCount_for_backlogItems : AbstractIndexCreationTask<BacklogItem>
    {
        public GetStatusCount_for_backlogItems()
        {
            // reduce is not working atm. Posted my question on the RavenDB mailing list 
            // https://groups.google.com/forum/?fromgroups#!topic/ravendb/kzGvdpECry0


            //Map = backlogItems => from bli in backlogItems
            //                      select new
            //                                 {
            //                                     Status = bli.Status,
            //                                     Occurrences = 1
            //                                 };

            //Reduce = results => from result in results
            //                    group result by result.Status
            //                        into g
            //                        select new
            //                                   {
            //                                       g.Key,
            //                                       Count = g.Sum(x => x.Occurrences)
            //                                   };
        }
    }
}