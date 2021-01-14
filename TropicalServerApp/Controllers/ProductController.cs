using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServer.BLL;
using System.Data;
using System.Web.UI.WebControls;

namespace TropicalServerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        
        public ActionResult Product()
        {
            if ((string)Session["username"] == "sessionon")
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }
        /*
        public ActionResult ViewOrders()
        {
            return View();
        }*/

        [HttpGet]
        public ActionResult ViewOrders(int parameters)
        {
            
            ReportsBLL rll = new ReportsBLL();
            DataSet ds = rll.GetViewOrders(parameters);

            List<List<string>> result = new List<List<string>>();

            List<string> res;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                res = new List<string>();
                res.Add(dr[0].ToString());
                res.Add(dr[1].ToString());
                res.Add(dr[2].ToString());
                res.Add(dr[3].ToString());
                res.Add(dr[4].ToString());
                res.Add(dr[5].ToString());
                res.Add(dr[6].ToString());
                res.Add(dr[7].ToString());
                res.Add(dr[8].ToString());
                res.Add(dr[9].ToString());
                res.Add(dr[10].ToString());
                res.Add(dr[11].ToString());
                res.Add(dr[12].ToString());
                res.Add(dr[13].ToString());
                result.Add(res);
            }
            ViewBag.data2 = result;
            return View();
        }


        [HttpGet]
        public ActionResult Orders(string parameters)
        {
            if ((string)Session["username"] != "sessionon")
            {
                return RedirectToAction("Login", "Login");
            }

            ReportsBLL rll = new ReportsBLL();
            DataSet ds = rll.GetOrdersbyTimePeriod(parameters);

            List<List<string>> result = new List<List<string>>();
            /*
            List<Orders> result = ds.Tables[0].AsEnumerable().Select(
                            dataRow => new Orders
                            {
                                OrderTrackingNumber = dataRow.Field<string>("OrderTrackingNumber"),
                                OrderDate = dataRow.Field<DateTime>("OrderDate"),
                                OrderCustomerNumber = dataRow.Field<int>("OrderCustomerNumber"),
                                CustName = dataRow.Field<string>("CustName"),
                                CustOfficeAddress1 = dataRow.Field<string>("CustOfficeAddress1"),
                                OrderRouteNumber = dataRow.Field<int>("OrderRouteNumber")
                            }).ToList();*/


             List<string> res;
             
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 res = new List<string>();
                 res.Add(dr[0].ToString());
                 res.Add(dr[1].ToString());
                 res.Add(dr[2].ToString());
                 res.Add(dr[3].ToString());
                 res.Add(dr[4].ToString());
                 res.Add(dr[5].ToString());
                 res.Add(dr[6].ToString());
                 result.Add(res);
             }
             ViewBag.data = result;
             return View();
        }
    }
}