namespace TFLCollection.Model
{
    public class Person
    {
        int Id { get; set; }
        string Name { get; set; }

       int Age{get;set;}

        public Person(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
    }
}