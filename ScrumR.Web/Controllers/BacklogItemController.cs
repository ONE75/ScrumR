using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        
        // GET: /BacklogItem/Details/5

        public ActionResult Details(int id)
        {
            var bli = RavenSession.Load<BacklogItem>(id);
            return Json(bli);
        }

        //
        // GET: /BacklogItem/Create

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

        //
        // POST: /BacklogItem/Create

        [HttpPost]
        public ActionResult CreateBacklogItem(CreateBacklogItemModel model)
        {
            try
            {
                var backlogItem = new BacklogItem(model.Story)
                                      {
                                          Story = model.Story,
                                          StoryPoints = model.StoryPoints,
                                          Summary = model.Summary,
                                          Owner = "Stijn Volders"
                                      };

                RavenSession.Store(backlogItem);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        ////
        //// GET: /BacklogItem/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /BacklogItem/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /BacklogItem/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /BacklogItem/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
