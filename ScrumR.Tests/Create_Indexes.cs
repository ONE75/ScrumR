using NUnit.Framework;
using Raven.Client.Indexes;
using ScrumR.Tests.Persistance;

namespace ScrumR.Tests
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