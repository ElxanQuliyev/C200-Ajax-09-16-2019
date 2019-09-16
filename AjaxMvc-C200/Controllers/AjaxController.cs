using AjaxMvc_C200.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvc_C200.Controllers
{
    public class AjaxController : Controller
    {
        CarsC200DB db = new CarsC200DB();
        // GET: AjaxController
        public ActionResult  GetModels(int? id)
        {
            object data = null;
            if (id==null)
            {
                data = new
                {
                    status=404,
                    message="Id not found",
                    response=""
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            Model selectModel = db.Models.FirstOrDefault(md => md.MarkaId == id);
            if (selectModel==null)
            {
                data = new
                {
                    status=404,
                    message="Id does not exist",
                    response=""
                };
                return Json(data,JsonRequestBehavior.AllowGet);
            }
            var modelMarka = db.Models.Where(md => md.MarkaId == id).Select(md =>new {
                md.Id,
                md.Name
            }).ToList();
            data = new
            {
                status = 200,
                message = "Success",
                response = modelMarka
            };
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}