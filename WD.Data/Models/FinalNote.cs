namespace WD.Data.Models
{
    public partial class FinalNote
    {
        public int NoteId { get; set; }
        public string Note { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}