namespace WD.Data.Models
{
    public partial class FinalNote
    {
        public int NoteId { get; set; }
        public float Note { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}