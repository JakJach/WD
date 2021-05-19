using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public interface IWDWebRepository
    {
        IList<FinalNote> FinalNotes { get; }
        IList<Student> Students { get; }
        IList<Teacher> Teachers { get; }
        IList<User> Users { get; }
        IList<Project> Projects { get; }
        IList<Class> Classes { get; }
        IList<Thesis> Theses { get; }
        IList<File> Files { get; }

        FinalNote Add(FinalNote finalNote);
        FinalNote Delete(FinalNote finalNote);
        FinalNote Update(FinalNote finalNote);

        Student Add(Student student);
        Student Delete(Student student);
        Student Update(Student student);

        Teacher Add(Teacher teacher);
        Teacher Delete(Teacher teacher);
        Teacher Update(Teacher teacher);

        User Add(User user);
        User Delete(User user);
        User Update(User user);

        Project Add(Project project);
        Project Delete(Project project);
        Project Update(Project project);

        Class Add(Class _class);
        Class Delete(Class _class);
        Class Update(Class _class);

        Thesis Add(Thesis thesis);
        Thesis Delete(Thesis thesis);
        Thesis Update(Thesis thesis);

        File Add(File file);
        File Delete(File file);
        File Update(File file);
    }
}