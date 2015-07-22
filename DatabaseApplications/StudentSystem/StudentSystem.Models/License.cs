namespace StudentSystem.Models
{
    public class License
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual System.Collections.Generic.ICollection<Resource> Resources { get; set; }
    }
}
