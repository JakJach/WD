namespace WD.Data.Models
{
    public partial class ProjectStudent
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string StudentId { get; set; }
        public float Note { get; set; }
    }
}
