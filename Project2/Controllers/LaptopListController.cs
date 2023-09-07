using Project2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class LaptopListController : Controller
    {
        // GET: LaptopList
        string conString = ConfigurationManager.ConnectionStrings["EcomConStr"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader srdr;
        public ActionResult Index()
        {
            List<laptop> laptoplist = new List<laptop>();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("Select * from Laptop", con);
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    laptoplist.Add(
                        new laptop
                        {
                            LaptopId = (string)srdr["LaptopId"],
                            Brand = (string)srdr["LaptopName"],
                            Price = (double)srdr["LaptopPrice"],
                            Specification = (string)srdr["Description"],

                        });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(laptoplist);


        }


        // GET: LaptopList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaptopList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaptopList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaptopList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaptopList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
