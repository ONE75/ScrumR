using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class SprintPersistanceTests : RavenTest
    {
        [Test]
        public void Sprint_can_be_Saved()
        {
            var sprint = new SprintBuilder().Build();
            _session.Store(sprint);
            _session.SaveChanges();
        }

        [Test]
        public void Sprint_can_be_loaded_by_id_only()
        {
            var sprint = _session.Load<Sprint>(1);
            Assert.IsNotNull(sprint);
            Assert.AreEqual("First sprint", sprint.Name);
        }
    }
}