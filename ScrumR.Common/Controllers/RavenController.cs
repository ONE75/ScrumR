using System.Web.Mvc;
using System.Xml.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace ScrumR.Common.Controllers
{
    public abstract class RavenController : Controller
    {
        private static IDocumentStore _store;

        protected static IDocumentStore DocumentStore
        {
            get
            {
                if (_store != null)
                    return _store;

                lock (typeof(RavenController))
                {
                    if (_store != null)
                        return _store;

                    _store = new DocumentStore
                    {
                        Url = "http://localhost:8080"
                    }.Initialize();
                }
                return _store;
            }
        }

        public IDocumentSession RavenSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RavenSession = DocumentStore.OpenSession();
        }

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           using(RavenSession)
            {
               if (RavenSession != null && filterContext.Exception== null)
               {
                   RavenSession.SaveChanges();
               }
            }
        }
    }
}
