using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public interface IWDWebRepository
    {
        IList<FinalNote> FinalNotes { get; }
        IList<Project> Projects { get; }
        IList<Class> Classes { get; }
        IList<Thesis> Theses { get; }
        IList<File> Files { get; }

        FinalNote Add(FinalNote finalNote);
        FinalNote Delete(FinalNote finalNote);
        FinalNote Update(FinalNote finalNote);

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