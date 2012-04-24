using NUnit.Framework;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class Create_Indexes : RavenTest
    {
        [Test]
        public void CreateIndexes()
        {
            IndexCreation.CreateIndexes(typeof(BacklogItems_FullTextSearchOnStory).Assembly, DocumentStore);
        }     
    }
}