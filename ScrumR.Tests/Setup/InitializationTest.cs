using System;
using NUnit.Framework;
using ScrumR.Common;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class InitializationTest : RavenTest
    {
        [Test]
        public void InsertSampleData()
        {
            var initializer = new Initializer();
            initializer.InsertSampleData(_session);
            _session.SaveChanges();
        }
    }
}