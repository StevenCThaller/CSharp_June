namespace FirstProject.Models
{
    public class Result
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Result(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}