using System.Web.Mvc;
using ScrumR.Common.Controllers;
using ScrumR.Web.Models;

namespace ScrumR.Web.Controllers
{
    public class BacklogItemController : RavenController
    {
        //
        // GET: /BacklogItem/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var bli = RavenSession.Load<BacklogItem>(id);
            return Json(bli);
        }

        public ActionResult CreateBacklogItem()
        {
            var bli = new CreateBacklogItemModel()
                          {
                              Story = "Sample",
                              StoryPoints = 4,
                              Summary = "A summary"
                          };

            return View(bli);

        }

        [HttpPost]
        public ActionResult CreateBacklogItem(CreateBacklogItemModel model)
        {
            try
            {
                var backlogItem = new BacklogItemBuilder()
                    .ForStory(model.Story)
                    .EstimatedStoryPoints(model.StoryPoints)
                    .WithSummary(model.Summary)
                    .OwnedBy("Stijn Volders")
                    .Build();

                RavenSession.Store(backlogItem);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}