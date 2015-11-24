using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            var employees = from e in db.Employees
                            where e.EmployeeID > -1
                            select e;
            //return View(db.Employees.ToList());
            return View(employees.ToArray());

        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int employeeID = 0)
        {
            var employee = from e in db.Employees
                           where e.EmployeeID == employeeID
                           select e;

            //Employee employee = db.Employees.Find(employeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee.First());
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int employeeID = 0)
        {
            var employee = from e in db.Employees
                           where e.EmployeeID == employeeID
                           select e;
            //Employee employee = db.Employees.Find(employeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee.First());
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                /*
                Employee myEmp = (from e in db.Employees
                            where e.EmployeeID == employee.EmployeeID
                        select e).First();

                if (myEmp != null)
                {
                    myEmp.EmployeeID = employee.EmployeeID;
                    myEmp.LastName = employee.LastName;
                    myEmp.FirstName = employee.FirstName;
                    myEmp.Title = employee.Title;
                    myEmp.TitleOfCourtesy = employee.TitleOfCourtesy;
                    myEmp.BirthDate = employee.BirthDate;
                    myEmp.HireDate = employee.HireDate;
                    myEmp.Address = employee.Address;
                    myEmp.City = employee.City;
                    myEmp.Region = employee.Region;
                    myEmp.PostalCode = employee.PostalCode;
                    myEmp.Country = employee.Country;
                    myEmp.ReportsTo = employee.ReportsTo;
                    myEmp.PhotoPath = employee.PhotoPath;

                    db.SaveChanges();
                }
                */
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int employeeID = 0)
        {
            Employee employee = db.Employees.Find(employeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int employeeID)
        {
            Employee employee = db.Employees.Find(employeeID);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Employee/Test/5

        public ActionResult Test(string employeeID)
        {
            ViewBag.employeeID = employeeID;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}