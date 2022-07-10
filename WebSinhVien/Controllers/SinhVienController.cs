using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSinhVien.Models;

namespace WebSinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Index(string strSearch)
        {
            ListStudent dssinhvien = new ListStudent();
            List<SinhVien> obj = dssinhvien.getsv(string.Empty).OrderBy(x => x.TENSV).ToList();
            
            if (!String.IsNullOrEmpty(strSearch))
            {
                obj = obj.Where(x => x.TENSV.Contains(strSearch)).ToList();
            }
            
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(SinhVien sv)
        {
            if (ModelState.IsValid)
            {

                ListStudent dssinhvien = new ListStudent();
                dssinhvien.InsertStudent(sv);
                return RedirectToAction("Index");
               }
            return View();
          

        }
        public ActionResult Edit(string id="")
        {
            ListStudent dssinhvien = new ListStudent();
            List<SinhVien> obj = dssinhvien.getsv(id);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(SinhVien sv)
        {
            ListStudent dssinhvien = new ListStudent();
            dssinhvien.EditSinhVien(sv);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id="")
        {
            ListStudent dssinhvien = new ListStudent();
            List<SinhVien> obj = dssinhvien.getsv(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id="")
        {
            ListStudent dssinhvien = new ListStudent();
            List<SinhVien> obj = dssinhvien.getsv(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(SinhVien sv)
        {
            ListStudent dssinhvien = new ListStudent();
            dssinhvien.DeleteSinhVien(sv);
            return RedirectToAction("Index");
            
        }
       
    }
}