using System.Linq;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    public class BacklogItems_WithTasks : AbstractIndexCreationTask<BacklogItem>
    {
        public BacklogItems_WithTasks()
        {
            Map = items =>
                  items.Where(bli => bli.Tasks.Any())
                      .Select(bli => new {bli.Id});
        }
    }
}