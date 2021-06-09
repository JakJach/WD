using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public interface IWDWebRepository
    {
        IList<Course> Courses { get; }
        IList<File> Files { get; }
        IList<Project> Projects { get; }
        IList<ProjectFile> ProjectFiles { get; }
        IList<ProjectStudent> ProjectStudents { get; }
        IList<StudentCourses> StudentCourses { get; }
        IList<Thesis> Theses { get; }
        IList<ThesisFile> ThesisFiles { get; }

        Course Add(Course course);
        Course Delete(Course course);
        Course Update(Course course);

        File Add(File file);
        File Delete(File file);
        File Update(File file);

        Project Add(Project project);
        Project Delete(Project project);
        Project Update(Project project);

        ProjectFile Add(ProjectFile projectFile);
        ProjectFile Delete(ProjectFile projectFile);
        ProjectFile Update(ProjectFile projectFile);

        ProjectStudent Add(ProjectStudent projectStudent);
        ProjectStudent Delete(ProjectStudent projectStudent);
        ProjectStudent Update(ProjectStudent projectStudent);

        StudentCourses Add(StudentCourses studentCourse);
        StudentCourses Delete(StudentCourses studentCourse);
        StudentCourses Update(StudentCourses studentCourse);

        Thesis Add(Thesis thesis);
        Thesis Delete(Thesis thesis);
        Thesis Update(Thesis thesis);

        ThesisFile Add(ThesisFile thesisFile);
        ThesisFile Delete(ThesisFile thesisFile);
        ThesisFile Update(ThesisFile thesisFile);
    }
}