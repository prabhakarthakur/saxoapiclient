using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using SaxoBusinessComp;
using SaxoDAL;

namespace SaxoApi.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View("BookFinder");
        }

        public JsonResult GetBookByIsbnNumber(string isbnNumbers)
        {
            if (string.IsNullOrEmpty(isbnNumbers))
                isbnNumbers = "9788741201122";

            isbnNumbers = "&isbn=" + isbnNumbers.TrimEnd(',');
            var saxoApi = new SaxoApiWraper();
            var apiResult = saxoApi.CallSaxoApi(isbnNumbers);
            return new JsonResult()
            {
                Data = new { imageurl = apiResult.products.FirstOrDefault().imageurl, title = apiResult.products.FirstOrDefault().title, url = apiResult.products.FirstOrDefault().url, label = apiResult.products.FirstOrDefault().label },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        

    }
}
