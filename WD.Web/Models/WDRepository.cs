using System.Collections.Generic;
using System.Linq;
using WD.Data.Models;
using WD.Data.Services;

namespace WD.Web.Models
{
    public class WDRepository : IWDRepository
    {
        #region Fields
        private readonly WDContext _context;

        #endregion

        #region Constructors
        public WDRepository(WDContext context)
        {
            _context = context;
        }
        #endregion

        #region Gets

        #region Classes
        public IEnumerable<Classes> GetAllClasses
        {
            get { return _context.Classes; }
        }

        public Classes GetClasses(int id)
        {
            return GetAllClasses.FirstOrDefault(c => c.ID == id);
        }

        public Classes GetClasses(string name)
        {
            return GetAllClasses.FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<Classes> GetStudentClasses(Student student)
        {
            return GetAllClasses.Where(c => c.StudentIDs.Contains(student.ID));
        }

        public IEnumerable<Classes> GetTeacherClasses(Teacher teacher)
        {
            return GetAllClasses.Where(c => c.TeacherID == teacher.ID);
        }
        #endregion

        #region Projects
        public IEnumerable<Project> GetAllProjects
        {
            get { return _context.Projects; }
        }

        public Project GetProject(int id)
        {
            return GetAllProjects.FirstOrDefault(p => p.ID == id);
        }

        public Project GetProject(string name)
        {
            return GetAllProjects.FirstOrDefault(p => p.Name == name);
        }

        public Project GetProject(Classes classes, Student student)
        {
            return GetProjects(classes).FirstOrDefault(p => p.StudentIDs.Contains(student.ID));
        }

        public IEnumerable<Project> GetProjects(Classes classes)
        {
            return GetAllProjects.Where(p => p.ClassesID == classes.ID);
        }

        public IEnumerable<Project> GetStudentProjects(Student student)
        {
            return GetAllProjects.Where(p => p.StudentIDs.Contains(student.ID));
        }
        public IEnumerable<Project> GetTeacherProjects(Teacher teacher)
        {
            return GetAllProjects.Where(p => p.ReviewerID == teacher.ID);
        }
        #endregion

        #region Students
        public IEnumerable<Student> GetAllStudents
        {
            get { return _context.Students; }
        }

        public Student GetStudent(int id)
        {
            return GetAllStudents.FirstOrDefault(s => s.ID == id);
        }

        public Student GetStudent(string email)
        {
            return GetAllStudents.FirstOrDefault(s => s.Email == email);
        }
        #endregion

        #region Teachers
        public IEnumerable<Teacher> GetAllTeachers
        {
            get { return _context.Teachers; }
        }

        public Teacher GetTeacher(int id)
        {
            return GetAllTeachers.FirstOrDefault(t => t.ID == id);
        }

        public Teacher GetTeacher(string email)
        {
            return GetAllTeachers.FirstOrDefault(t => t.Email == email);
        }
        #endregion

        #region Theses
        public IEnumerable<Thesis> GetAllTheses
        {
            get { return _context.Theses; }
        }

        public Thesis GetStudentThesis(Student student)
        {
            return GetAllTheses.FirstOrDefault(t => t.StudentID == student.ID);
        }

        public IEnumerable<Thesis> GetTeacherPromotingTheses(Teacher teacher)
        {
            return GetAllTheses.Where(t => t.PromoterID == teacher.ID);
        }

        public IEnumerable<Thesis> GetTeacherReviewingTheses(Teacher teacher)
        {
            return GetAllTheses.Where(t => t.ReviewerID == teacher.ID);
        }

        public Thesis GetThesis(int id)
        {
            return GetAllTheses.FirstOrDefault(t => t.ID == id);
        }

        public Thesis GetThesis(string title)
        {
            return GetAllTheses.FirstOrDefault(t => t.Title == title);
        }
        #endregion

        #region Users
        public IEnumerable<User> GetAllUsers
        {
            get { return _context.AllUsers; }
        }

        public User GetUser(string email)
        {
            return GetAllUsers.FirstOrDefault(u => u.Email == email);
        }
        #endregion

        #endregion

        #region Updates
        public Classes UpdateClasses(Classes classes)
        {
            _context.Classes.Update(classes);
            _context.SaveChanges();
            return classes;
        }

        public Project UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return project;
        }

        public Student UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

        public Teacher UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Thesis UpdateThesis(Thesis thesis)
        {
            _context.Theses.Update(thesis);
            _context.SaveChanges();
            return thesis;
        }

        public User UpdateUser(User user)
        {
            _context.AllUsers.Update(user);
            _context.SaveChanges();
            return user;
        }
        #endregion
    }
}
