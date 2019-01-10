using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace windbg_web.Controllers
{
    public class HomeController : Controller
    {
        public static event EventHandler _MyEvent;
        List<byte[]> _List = new List<byte[]>();

        public ActionResult Index()
        {
            ViewData["Message"] = "hello world!";
            _MyEvent += new EventHandler(TestEvent);
            _MyEvent(null, new EventArgs());
            MyMethod();
            return View();
        }
        public ActionResult Crash()
        {
            ViewData["Message"] = "hello world!";
            _MyEvent += new EventHandler(TestEvent);
            _MyEvent(null, new EventArgs());
            MyMethod();
            return View();
        }

        public void MyMethod()
        {
            long i = 0;
            while (i < 9999999999)
            {
                i++;
            }
        }

        public void TestEvent(object obj, EventArgs args)
        {
            for (int i = 0; i < 20; i++)
            {
                _List.Add(new byte[1024 * 1024 * 10]);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}