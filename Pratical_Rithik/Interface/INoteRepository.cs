using Pratical_Rithik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratical_Rithik.Interface
{
    interface INoteRepository
    {
        IEnumerable<NoteModel> GetAll();
        bool AddNote(NoteModel model);
        bool UpdateNote(NoteModel model);
        bool DeleteNote(int id);
    }
}
