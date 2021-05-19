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

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Delete(Student student)
        {
            var s = _context.Students.Find(student);
            if(s != null)
            {
                _context.Students.Remove(s);
                _context.SaveChanges();
            }
            return s;
        }

        public Student Update(Student student)
        {
            var s = _context.Students.Attach(student);
            s.State = EntityState.Modified;
            _context.SaveChanges();
            return student;
        }

        public Teacher Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(Teacher teacher)
        {
            var t = _context.Teachers.Find(teacher);
            if(t != null)
            {
                _context.Teachers.Remove(t);
                _context.SaveChanges();
            }
            return t;
        }

        public Teacher Update(Teacher teacher)
        {
            var t = _context.Teachers.Attach(teacher);
            t.State = EntityState.Modified;
            _context.SaveChanges();
            return teacher;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            var u = _context.Users.Find(user);
            if (u != null)
            {
                _context.Users.Remove(u);
                _context.SaveChanges();
            }
            return u;
        }

        public User Update(User user)
        {
            var u = _context.Users.Attach(user);
            u.State = EntityState.Modified;
            _context.SaveChanges();
            return user;
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

        public IList<Student> Students => _context.Students.ToList();

        public IList<Teacher> Teachers => _context.Teachers.ToList();

        public IList<User> Users => _context.Users.ToList();

        public IList<Project> Projects => _context.Projects.ToList();

        public IList<Class> Classes => _context.Classes.ToList();

        public IList<Thesis> Theses => _context.Theses.ToList();

        public IList<File> Files => _context.Files.ToList();
    }
}
