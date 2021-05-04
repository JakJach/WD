using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class SQLRepository : IWDWebRepository
    {
        private readonly WDWebContext _context;

        public SQLRepository(WDWebContext context)
        {
            _context = context;
        }

        public FinalNote Add(FinalNote finalNote)
        {
            _context.FinalNotes.Add(finalNote);
            _context.SaveChanges();
            return finalNote;
        }

        public FinalNote Delete(FinalNote finalNote)
        {
            var note = _context.FinalNotes.Find(finalNote);
            if (note != null)
            {
                _context.FinalNotes.Remove(note);
                _context.SaveChanges();
            }
            return note;
        }

        public FinalNote Update(FinalNote finalNote)
        {
            var note = _context.FinalNotes.Attach(finalNote);
            note.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return finalNote;
        }

        public IList<FinalNote> FinalNotes => (IList<FinalNote>)_context.FinalNotes;
    }
}
