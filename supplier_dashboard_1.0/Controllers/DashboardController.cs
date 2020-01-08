using supplier_dashboard_1._0.ActionFilters;
using supplier_dashboard_1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Highsoft.Web.Mvc.Charts;


namespace supplier_dashboard_1._0.Controllers
{
    [SessionTimeout]
    public class DashboardController : Controller
    {
        db_vendor piechart = new db_vendor();

        // GET: Dashboard     
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();

        }
        public PartialViewResult MonthlySales()
        {
            return PartialView("MonthlySales");
        }
    }

    public partial class SharedController : Controller
    {
        public ActionResult PieBasic()
        {
            List<PieSeriesData> pieData = new List<PieSeriesData>();

            pieData.Add(new PieSeriesData { Name = "FireFox", Y = 45.0 });
            pieData.Add(new PieSeriesData { Name = "IE", Y = 26.8 });
            pieData.Add(new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true });
            pieData.Add(new PieSeriesData { Name = "Safari", Y = 8.5 });
            pieData.Add(new PieSeriesData { Name = "Opera", Y = 6.2 });
            pieData.Add(new PieSeriesData { Name = "Others", Y = 0.7 });

            ViewData["pieData"] = pieData;

            return View();
        }
    }
}