using CrystalDecisions.CrystalReports.Engine;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ViewModel;

namespace CRUDOperationsTask.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentService DeptService;
        private EmployeeService EmpService;

        public DepartmentController(DepartmentService deptService, EmployeeService empService)
        {
            DeptService = deptService;
            EmpService = empService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpGet]
        public ActionResult All()
        {
            return View(DeptService.GetAll());
        }
        public ActionResult AddDepartment()
        {
            ViewBag.managers = EmpService.GetAll();
            return View();

        }
        [System.Web.Mvc.HttpPost]
        public ActionResult AddDepartment(DepartmentEditViewModel d)
        {
            if (ModelState.IsValid)
            {
                DeptService.Add(d);
                return RedirectToAction("All");
            }
            ViewBag.managers = EmpService.GetAll();
            return View(d);

        }
        [System.Web.Mvc.HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            ViewBag.managers = EmpService.GetAll();
            ViewBag.employees = EmpService.GetFilter(id);

            return View(DeptService.GetByID(id));
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult UpdateDepartment(DepartmentEditViewModel e)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateEmployee");
            }
            DeptService.Update(e);
            return RedirectToAction("All");
        }
       
        [System.Web.Mvc.HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            ViewBag.managers = EmpService.GetAll();
            return View(DeptService.GetByID(id));
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteDepartment(DepartmentEditViewModel e)
        {
            DeptService.Remove(e);
            return RedirectToAction("All");
        }
        

    }
}
