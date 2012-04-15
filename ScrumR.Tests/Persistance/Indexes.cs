using NUnit.Framework;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class Indexes : RavenTest
    {
        [Test]
        public void CreateIndexes()
        {
            IndexCreation.CreateIndexes(typeof(Search_BacklogItems).Assembly, DocumentStore);
        }     
    }
}