using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Data.Services
{
    public interface IVDRepository
    {
        #region Classes
        IEnumerable<Classes> GetAllClasses { get; }
        Classes GetClasses(int id);
        Classes GetClasses(string name);
        IEnumerable<Classes> GetStudentClasses(Student student);
        IEnumerable<Classes> GetTeacherClasses(Teacher teacher);
        Classes UpdateClasses(Classes classes);
        #endregion

        #region Projects
        IEnumerable<Project> GetAllProjects { get; }
        Project GetProject(int id);
        Project GetProject(string name);
        Project GetProject(Classes classes, Student student);
        IEnumerable<Project> GetProjects(Classes classes);
        IEnumerable<Project> GetStudentProjects(Student student);
        IEnumerable<Project> GetTeacherProjects(Teacher teacher);
        Project UpdateProject(Project project);
        #endregion

        #region Student
        IEnumerable<Student> GetAllStudents { get; }
        Student GetStudent(int id);
        Student GetStudent(string email);
        Student UpdateStudent(Student student);
        #endregion

        #region Teacher
        IEnumerable<Teacher> GetAllTeachers { get; }
        Teacher GetTeacher(int id);
        Teacher GetTeacher(string email);
        Teacher UpdateTeacher(Teacher teacher);
        #endregion

        #region Thesis
        IEnumerable<Thesis> GetAllTheses { get; }
        Thesis GetThesis(int id);
        Thesis GetThesis(string title);
        Thesis GetStudentThesis(Student student);
        IEnumerable<Thesis> GetTeacherPromotingTheses(Teacher teacher);
        IEnumerable<Thesis> GetTeacherReviewingTheses(Teacher teacher);
        Thesis UpdateThesis(Thesis thesis);
        #endregion

        #region Users
        IEnumerable<User> GetAllUsers { get; }
        User GetUser(string email);
        User UpdateUser(User user);
        #endregion
    }
}
