using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private int lastEmployeeId = 0;

        public ActionResult Index()
        {
            IEnumerable<Administration> model;
            using (CommonContext db = new CommonContext())
            {
                IEnumerable<Administration> administrations = db.Administrations.ToList();
                IEnumerable<Section> sections = db.Sections.ToList();
                IEnumerable<Group> groups = db.Groups.ToList();
                IEnumerable<Subgroup> subgroups = db.Subgroups.ToList();
                IEnumerable<Employee> employees = db.Employees.ToList();
                model = administrations;
            }
            return View(model);
        }

        public JsonResult AddAdministration(string title)
        {
            int lastAdmId = 0;
            using (CommonContext db = new CommonContext())
            {
                Administration adm = new Administration { Title = title };
                db.Administrations.Add(adm);
                db.SaveChanges();
                lastAdmId = db.Administrations.Max(a => a.Id);
            }
            return Json(new { lastDeptId = lastAdmId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSection(int departmentId, string title)
        {
            int lastSectionId = 0;
            using (CommonContext db = new CommonContext())
            {
                Administration adm = db.Administrations.Where(a => a.Id == departmentId).ToArray().FirstOrDefault();
                adm.Sections.Add(new Section() { Title = title, Administration = adm });
                db.SaveChanges();
                lastSectionId = db.Sections.Max(s => s.Id);
            }
            return Json(new { lastDeptId = lastSectionId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddGroup(int departmentId, string title)
        {
            int lastGroupId = 0;
            using (CommonContext db = new CommonContext())
            {
                Section section = db.Sections.Where(s => s.Id == departmentId).ToArray().FirstOrDefault();
                section.Groups.Add(new Group() { Title = title, Section = section });
                db.SaveChanges();
                lastGroupId = db.Groups.Max(s => s.Id);
            }
            return Json(new { lastDeptId = lastGroupId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSubgroup(int? groupId, string title)
        {
            int lastSubgroupId = 0;
            using (CommonContext db = new CommonContext())
            {
                Group group = db.Groups.Where(g => g.Id == groupId).ToArray().FirstOrDefault();
                group.Subgroups.Add(new Subgroup() { Title = title });
                db.SaveChanges();
                lastSubgroupId = db.Subgroups.Max(s => s.Id);
            }
            return Json(new { lastDeptId = lastSubgroupId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployeeToAdministration(int departmentId, string lastName, string firstName, string patronymic)
        {
            using (CommonContext db = new CommonContext())
            {
                Administration adm = db.Administrations.Where(a => a.Id == departmentId).ToArray().FirstOrDefault();
                adm.Employees.Add(new Employee() { 
                    LastName = lastName, 
                    FirstName = firstName, 
                    Patronymic = patronymic, 
                    Administration = adm 
                });
                db.SaveChanges();
                lastEmployeeId = adm.Employees.Max(e => e.Id);
            }
            return Json(new { lastEmployeeId = lastEmployeeId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployeeToSection(int departmentId, string lastName, string firstName, string patronymic)
        {
            using (CommonContext db = new CommonContext())
            {
                Section section = db.Sections.Where(s => s.Id == departmentId).ToArray().FirstOrDefault();
                section.Employees.Add(new Employee()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Patronymic = patronymic,
                    Section = section
                });
                db.SaveChanges();
                lastEmployeeId = section.Employees.Max(e => e.Id);
            }
            return Json(new { lastEmployeeId = lastEmployeeId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployeeToGroup(int departmentId, string lastName, string firstName, string patronymic)
        {
            using (CommonContext db = new CommonContext())
            {
                Group group = db.Groups.Where(g => g.Id == departmentId).ToArray().FirstOrDefault();
                group.Employees.Add(new Employee()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Patronymic = patronymic,
                    Group = group
                });
                db.SaveChanges();
                lastEmployeeId = group.Employees.Max(e => e.Id);
            }
            return Json(new { lastEmployeeId = lastEmployeeId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployeeToSubgroup(int departmentId, string lastName, string firstName, string patronymic)
        {
            using (CommonContext db = new CommonContext())
            {
                Subgroup subgroup = db.Subgroups.Where(s => s.Id == departmentId).ToArray().FirstOrDefault();
                subgroup.Employees.Add(new Employee()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Patronymic = patronymic,
                    Subgroup = subgroup
                });
                db.SaveChanges();
                lastEmployeeId = subgroup.Employees.Max(e => e.Id);
            }
            return Json(new { lastEmployeeId = lastEmployeeId }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEmployee(int employeeId)
        {
            using (CommonContext db = new CommonContext())
            {
                Employee employee = db.Employees.Where(e => e.Id == employeeId).ToArray().FirstOrDefault();
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public void EditEmployee(int employeeId, string lastName, string firstName, string patronymic)
        {
            using (CommonContext db = new CommonContext())
            {
                Employee employee = db.Employees.Where(e => e.Id == employeeId).ToArray().FirstOrDefault();
                employee.LastName = lastName;
                employee.FirstName = firstName;
                employee.Patronymic = patronymic;
                db.SaveChanges();
            }
        }
    }
}