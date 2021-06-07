using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public interface IWDWebRepository
    {
        IList<Class> Classes { get; }
        IList<File> Files { get; }
        IList<Project> Projects { get; }
        IList<ProjectFile> ProjectFiles { get; }
        IList<ProjectStudent> ProjectStudents { get; }
        IList<StudentClass> StudentClasses { get; }
        IList<Thesis> Theses { get; }
        IList<ThesisFile> ThesisFiles { get; }

        Class Add(Class _class);
        Class Delete(Class _class);
        Class Update(Class _class);

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

        StudentClass Add(StudentClass studentClass);
        StudentClass Delete(StudentClass studentClass);
        StudentClass Update(StudentClass studentClass);

        Thesis Add(Thesis thesis);
        Thesis Delete(Thesis thesis);
        Thesis Update(Thesis thesis);

        ThesisFile Add(ThesisFile thesisFile);
        ThesisFile Delete(ThesisFile thesisFile);
        ThesisFile Update(ThesisFile thesisFile);
    }
}