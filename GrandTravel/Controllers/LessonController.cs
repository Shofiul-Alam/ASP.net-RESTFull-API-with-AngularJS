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
    public class LessonController : Controller
    {
        private LessonManager _lessonManager;
        private TeacherManager _teacherManager;

        public LessonController()
        {
            _lessonManager = new LessonManager(new LessonEFRepository());
            _teacherManager = new TeacherManager(new TeacherEFRepository());
        }
        // GET: Lesson
        public ActionResult Index()
        {
            var lessons = _lessonManager.GetAll();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AddDropDownValues();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _lessonManager.Create(lesson);
                return RedirectToAction("Index");
            }
            else
            {
                AddDropDownValues();
                return View(lesson);
            }
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var lesson = _lessonManager.GetById(id);
            AddDropDownValues();

            return View(lesson);
        }

        [HttpPost]
        public ActionResult Update(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _lessonManager.Update(lesson);
                return RedirectToAction("Index");
            }
            else
            {
                AddDropDownValues();
                return View(lesson);
            }
        }

        public ActionResult Delete(long id)
        {
            var lesson = _lessonManager.GetById(id);
            _lessonManager.Delete(lesson);
            return RedirectToAction("Index");
        }

        private void AddDropDownValues()
        {
            List<SelectListItem> teacherListItems = new List<SelectListItem>();

            var teachers = _teacherManager.GetAll();

            foreach (Teacher teacher in teachers)
            {
                teacherListItems.Add(new SelectListItem { Text = teacher.Name, Value = teacher.Name });
            }

            ViewBag.Teachers = teacherListItems;


            List<SelectListItem> topics = new List<SelectListItem>();

            topics.Add(new SelectListItem { Text = "MVC", Value = "MVC" });

            topics.Add(new SelectListItem { Text = "Web Api", Value = "Web Api" });

            topics.Add(new SelectListItem { Text = "C#", Value = "C#" });

            topics.Add(new SelectListItem { Text = "Android", Value = "Android" });

            ViewBag.Topics = topics;

        }
    }
}