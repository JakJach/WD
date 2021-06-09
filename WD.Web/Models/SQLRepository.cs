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

        public StudentCourses Add(StudentCourses finalNote)
        {
            _context.StudentCourses.Add(finalNote);
            _context.SaveChanges();
            return finalNote;
        }

        public StudentCourses Delete(StudentCourses finalNote)
        {
            var fn = _context.StudentCourses.Find(finalNote.Id);
            if (fn != null)
            {
                _context.StudentCourses.Remove(fn);
                _context.SaveChanges();
            }
            return fn;
        }

        public StudentCourses Update(StudentCourses finalNote)
        {
            var fn = _context.StudentCourses.Attach(finalNote);
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

        public Course Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public Course Delete(Course course)
        {
            var c = _context.Courses.Find(course);
            if(c != null)
            {
                _context.Courses.Remove(c);
                _context.SaveChanges();
            }
            return c;
        }

        public Course Update(Course course)
        {
            var c = _context.Courses.Attach(course);
            c.State = EntityState.Modified;
            _context.SaveChanges();
            return course;
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

        public ProjectFile Add(ProjectFile projectFile)
        {
            _context.ProjectFiles.Add(projectFile);
            _context.SaveChanges();
            return projectFile;
        }

        public ProjectFile Delete(ProjectFile projectFile)
        {
            var pf = _context.ProjectFiles.Find(projectFile);
            if (pf != null)
            {
                _context.ProjectFiles.Remove(pf);
                _context.SaveChanges();
            }
            return pf;
        }

        public ProjectFile Update(ProjectFile projectFile)
        {
            var pf = _context.ProjectFiles.Attach(projectFile);
            pf.State = EntityState.Modified;
            _context.SaveChanges();
            return projectFile;
        }

        public ProjectStudent Add(ProjectStudent projectStudent)
        {
            _context.ProjectStudents.Add(projectStudent);
            _context.SaveChanges();
            return projectStudent;
        }

        public ProjectStudent Delete(ProjectStudent projectStudent)
        {
            var ps = _context.ProjectStudents.Find(projectStudent);
            if (ps != null)
            {
                _context.ProjectStudents.Remove(ps);
                _context.SaveChanges();
            }
            return ps;
        }

        public ProjectStudent Update(ProjectStudent projectStudent)
        {
            var ps = _context.ProjectStudents.Attach(projectStudent);
            ps.State = EntityState.Modified;
            _context.SaveChanges();
            return projectStudent;
        }

        public ThesisFile Add(ThesisFile thesisFile)
        {
            _context.ThesisFiles.Add(thesisFile);
            _context.SaveChanges();
            return thesisFile;
        }

        public ThesisFile Delete(ThesisFile thesisFile)
        {
            var tf = _context.ThesisFiles.Find(thesisFile);
            if (tf != null)
            {
                _context.ThesisFiles.Remove(tf);
                _context.SaveChanges();
            }
            return tf;
        }

        public ThesisFile Update(ThesisFile thesisFile)
        {
            var tf = _context.ThesisFiles.Attach(thesisFile);
            tf.State = EntityState.Modified;
            _context.SaveChanges();
            return thesisFile;
        }

        public IList<StudentCourses> StudentCourses => _context.StudentCourses.ToList();

        public IList<Project> Projects => _context.Projects.ToList();

        public IList<Course> Courses => _context.Courses.ToList();

        public IList<Thesis> Theses => _context.Theses.ToList();

        public IList<File> Files => _context.Files.ToList();

        public IList<ProjectFile> ProjectFiles => _context.ProjectFiles.ToList();

        public IList<ProjectStudent> ProjectStudents => _context.ProjectStudents.ToList();

        public IList<ThesisFile> ThesisFiles => _context.ThesisFiles.ToList();
    }
}
