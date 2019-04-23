using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pratical_Rithik.Models;
using Pratical_Rithik.Interface;

namespace Pratical_Rithik.Repository
{
    public class NoteRepository : INoteRepository
    {
        PracticalEntities _db = new PracticalEntities();

        public bool AddNote(NoteModel model)
        {
            Note note = new Note();
            note.title = model.title;
            note.body = model.body;
            _db.Notes.Add(note);
            return _db.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<NoteModel> GetAll()
        {
            return (from m in _db.Notes
                    select new NoteModel
                    {
                        id = m.id,
                        body = m.body,
                        title = m.title
                    }).ToList();

        }

        public bool UpdateNote(NoteModel model)
        {
            Note note = _db.Notes.FirstOrDefault(p => p.id == model.id);
            note.title = model.title;
            note.body = model.body;
            return _db.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteNote(int id)
        {
            Note note = _db.Notes.Find(id);
            _db.Notes.Remove(note);
            return _db.SaveChanges() == 1 ? true : false;
        }
    }
}