using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pratical_Rithik.Models;
using Pratical_Rithik.Interface;
using Pratical_Rithik.Repository;
using Pratical_Rithik.Filter;

namespace Pratical_Rithik.Controllers
{
    [CustomException]
    public class NoteController : Controller
    {
        private readonly INoteRepository noteRepo;

        public NoteController()
        {
            noteRepo = new NoteRepository();
        }

        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllNote()
        {
            return Json(noteRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddNote(NoteModel model)
        {
            var result = noteRepo.AddNote(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateNote(NoteModel model)
        {
            var result = noteRepo.UpdateNote(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteNote(int id)
        {
            var result = noteRepo.DeleteNote(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}