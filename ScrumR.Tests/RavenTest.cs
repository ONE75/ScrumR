using NUnit.Framework;
using Raven.Client;
using Raven.Client.Document;

namespace ScrumR.Tests.Persistance
{
    public abstract class RavenTest
    {
        private static IDocumentStore _store;
        protected IDocumentSession _session;

        protected static IDocumentStore DocumentStore
        {
            get
            {
                if (_store != null)
                    return _store;

                lock (typeof(RavenTest))
                {
                    if (_store != null)
                        return _store;

                    _store = new DocumentStore
                    {
                        Url = "http://localhost:8080"
                    }.Initialize();

                   // _store.Conventions.SaveEnumsAsIntegers = true;

                }
                return _store;
            }
        }

        [SetUp]
        public void Setup()
        {
            _session = DocumentStore.OpenSession();
        }

        [TearDown]
        public void TearDown()
        {
            _session.Dispose();
        }
    }

   
}