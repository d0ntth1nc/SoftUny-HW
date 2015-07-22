namespace StudentSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType Type { get; set; }

        public string URL { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual System.Collections.Generic.ICollection<License> Licenses { get; set; }
    }
}
