using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;

namespace GrandTravel.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager _teacherManager;

        public TeacherController()
        {
            _teacherManager = new TeacherManager(new TeacherEFRepository());
        }
        // GET: Lesson
        public ActionResult Index()
        {
            var teachers = _teacherManager.GetAll();
            return View(teachers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherManager.Create(teacher);
                return RedirectToAction("Index");
            }
            else
            {
                return View(teacher);
            }
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var teacher = _teacherManager.GetById(id);

            return View(teacher);
        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherManager.Update(teacher);
                return RedirectToAction("Index");
            }
            else
            {
                return View(teacher);
            }
        }

        public ActionResult Delete(long id)
        {
            var teacher = _teacherManager.GetById(id);
            _teacherManager.Delete(teacher);
            return RedirectToAction("Index");
        }
    }
}