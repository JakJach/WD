using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public interface IWDWebRepository
    {
        IList<FinalNote> FinalNotes { get; }

        FinalNote Add(FinalNote finalNote);
        FinalNote Delete(FinalNote finalNote);
        FinalNote Update(FinalNote finalNote);
    }
}