namespace Proiect_Inginerie_Software.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Stadium() { }
        public Stadium(int id, string name, string description, int capacity)
        {
            Id = id;
            Name = name;
            Description = description;
            Capacity = capacity;
        }
    }
}
