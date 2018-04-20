using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Controllers
{
    public class JsonOperationController : Controller
    {
        // GET: JsonOperation
      
        public ActionResult Index()
        {            
            ResponseNewsAppModels jsonModel = new ResponseNewsAppModels();

            string a = Request.QueryString["category"];
            string jsonObject =  jsonModel.TransportJsonNewsWithApp(Request.QueryString["category"]);
            IEnumerable<NewArticle> listArticle = JsonConvert.DeserializeObject<IEnumerable<NewArticle>>(jsonObject) as IEnumerable<NewArticle>;
            return View(listArticle);
        }
    }
}