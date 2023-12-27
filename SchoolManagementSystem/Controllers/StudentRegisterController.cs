using Newtonsoft.Json;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace SchoolManagementSystem.Controllers
{
    public class StudentRegisterController : Controller
    {
        StudentContext _dbContext = new StudentContext();       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (IsValidUser(model))
            {
                var student = GetStudentByUsername(model.Username);

                if (student != null)
                {
                    return RedirectToAction("StudentDetails", new { id = student.StudentId });
                }
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return RedirectToAction("Register");
        }     
        public ActionResult StudentDetails(int id)
        {
            var student = _dbContext.Students.Include(s=>s.Qualifications).FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                return View(student);
            }
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Register(StudentModel model, string qualificationsJson)
        {        

            if (ModelState.IsValid)
            {
                List<QualificationModel> qualifications = JsonConvert.DeserializeObject<List<QualificationModel>>(qualificationsJson);
                _dbContext.Students.Add(model);
                foreach(var qualification in qualifications)
                _dbContext.QualificationModels.Add(qualification);
                _dbContext.SaveChanges();             
                return RedirectToAction("StudentDetails", new { id = model.StudentId });
            }
            return View(model);
        }
        private bool IsValidUser(LoginModel model)
        {
            var user = _dbContext.Students.FirstOrDefault(u => u.Username == model.Username && u._password == model._password);
            return user != null;
        }
        private StudentModel GetStudentByUsername(string username)
        {
            return _dbContext.Students.SingleOrDefault(u => u.Username == username);
        }
    }
}