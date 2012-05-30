using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;
using NUnit.Framework;

namespace ScrumR.Tests.Persistance
{
    [TestFixture]
    public class Transaction : RavenTest
    {
        [Test]
        public void Transaction_is_rolled_back_if_something_happens()
        {
            using (var scope = new TransactionScope())
            {
                var test = new JustATest
                               {
                                   TestName = "testje"
                               };

                _session.Store(test);
                _session.SaveChanges();

                throw new Exception("This is expected");
                scope.Complete();
            }
        }

        [Test]
        public void JustWorksAsRegular()
        {
            using (var scope = new TransactionScope())
            {
                var test = new JustATest
                {
                    TestName = "testje"
                };

                _session.Store(test);
                _session.SaveChanges();

                scope.Complete();
                Debug.WriteLine("test is stored");
            }
        }

    }

    public class JustATest
    {
        public string TestName { get; set; }
    }
}
