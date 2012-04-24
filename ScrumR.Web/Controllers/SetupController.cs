using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumR.Common;
using ScrumR.Common.Controllers;

namespace ScrumR.Web.Controllers
{
    public class SetupController : RavenController
    {
      public string InsertTestData()
        {
            var initializer = new Initializer();
            initializer.InsertSampleData(this.RavenSession);
            return "Sample data was inserted";
        }

        public string CreateIndexes()
        {
            var initializer = new Initializer();
            initializer.CreateIndexes(DocumentStore);
            return "Done creating indexes";
        }

    }
}
