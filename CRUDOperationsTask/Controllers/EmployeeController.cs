using CrystalDecisions.CrystalReports.Engine;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;
using ViewModel;

namespace CRUDOperationsTask.Controllers
{
   
    public class EmployeeController : Controller
    {
        private EmployeeService EmpService;
        private DepartmentService DeptService;

        public EmployeeController(EmployeeService empService , DepartmentService deptService)
        {
            EmpService = empService;
            DeptService = deptService;

        }
        public ActionResult Index()
        {

            return View();
        }
       
        [HttpGet]
        public ActionResult All()
        {
            var employees= EmpService.GetAll();
            return View(employees);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            ViewBag.Deps = DeptService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeEditViewModel e)
        {
            if (ModelState.IsValid)
            { 
                EmpService.Add(e);
                return RedirectToAction("All");
            }
            ViewBag.Deps = DeptService.GetAll();
            return View(e);
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            ViewBag.Deps = DeptService.GetAll();
            return View(EmpService.GetByID(id));
        }
        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeEditViewModel e)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateEmployee");
            }
            EmpService.Update(e);
            return RedirectToAction("All");
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            ViewBag.Deps = DeptService.GetAll();
            return View(EmpService.GetByID(id));
        }
        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeEditViewModel e)
        {
            EmpService.Remove(e);
            return RedirectToAction("All");
        }
        public ActionResult exportReport()
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReport"), "CrystalReport1.rpt"));
            rd.SetDataSource(EmpService.GetAll());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Employee_list.pdf");
            }
            catch
            {
                throw;
            }
        }
    }
}
