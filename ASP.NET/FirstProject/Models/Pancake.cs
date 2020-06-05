namespace FirstProject.Models
{
    public class Pancake
    {
        public string Name { get; set; }
        public bool Syrup { get; set; }
        public Pancake(string name, bool syrup)
        {
            Name = name;
            Syrup = syrup;
        }
    }
}