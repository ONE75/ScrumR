using System.Linq;
using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class MapReduce : RavenTest
    {
         [Test]
        public void Get_itemcount_per_status()
        {
            // get a list with all status
             var backlogItems = _session.Query<BacklogItem>();
             var map = from backlogItem in backlogItems
                       select new
                                  {
                                      Status = backlogItem.Status,
                                      Count = 1
                                  };
             var results = map;

             var reduce = from agg in results
                          group agg by agg.Status into g
                          select new
                                     {
                                        g.Key,
                                        Count = g.Sum(x=> x.Count)
                                     };

             var reducedList = reduce.ToList();




        }
    }
}