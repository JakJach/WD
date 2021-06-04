using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var fn = _context.FinalNotes.Find(finalNote);
            if (fn != null)
            {
                _context.FinalNotes.Remove(fn);
                _context.SaveChanges();
            }
            return fn;
        }

        public FinalNote Update(FinalNote finalNote)
        {
            var fn = _context.FinalNotes.Attach(finalNote);
            fn.State = EntityState.Modified;
            _context.SaveChanges();
            return finalNote;
        }

        public Project Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project Delete(Project project)
        {
            var p = _context.Projects.Find(project);
            if(p != null)
            {
                _context.Projects.Remove(p);
                _context.SaveChanges();
            }
            return p;
        }

        public Project Update(Project project)
        {
            var p = _context.Projects.Attach(project);
            p.State = EntityState.Modified;
            _context.SaveChanges();
            return project;
        }

        public Class Add(Class _class)
        {
            _context.Classes.Add(_class);
            _context.SaveChanges();
            return _class;
        }

        public Class Delete(Class _class)
        {
            var c = _context.Classes.Find(_class);
            if(c != null)
            {
                _context.Classes.Remove(c);
                _context.SaveChanges();
            }
            return c;
        }

        public Class Update(Class _class)
        {
            var c = _context.Classes.Attach(_class);
            c.State = EntityState.Modified;
            _context.SaveChanges();
            return _class;
        }

        public Thesis Add(Thesis thesis)
        {
            _context.Theses.Add(thesis);
            _context.SaveChanges();
            return thesis;
        }

        public Thesis Delete(Thesis thesis)
        {
            var t = _context.Theses.Find(thesis);
            if(t != null)
            {
                _context.Theses.Remove(t);
                _context.SaveChanges();
            }
            return t;
        }

        public Thesis Update(Thesis thesis)
        {
            var t = _context.Theses.Attach(thesis);
            t.State = EntityState.Modified;
            _context.SaveChanges();
            return thesis;
        }

        public File Add(File file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
            return file;
        }

        public File Delete(File file)
        {
            var f = _context.Files.Find(file);
            if(f != null)
            {
                _context.Files.Remove(f);
                _context.SaveChanges();
            }
            return f;
        }

        public File Update(File file)
        {
            var f = _context.Files.Attach(file);
            f.State = EntityState.Modified;
            _context.SaveChanges();
            return file;
        }

        public IList<FinalNote> FinalNotes => _context.FinalNotes.ToList();

        public IList<Project> Projects => _context.Projects.ToList();

        public IList<Class> Classes => _context.Classes.ToList();

        public IList<Thesis> Theses => _context.Theses.ToList();

        public IList<File> Files => _context.Files.ToList();
    }
}
