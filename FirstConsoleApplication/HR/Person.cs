using System;


namespace HR
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime dob { get; set; }

        public Person()
        {
            Id = 0;
            FirstName = "sanika";
            LastName = "bhor";
            dob = DateTime.Now;
        }

        public Person(int id, string firstName, string lastName, DateTime dob)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.dob = dob;

        }

        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + dob + " ";
        }
    }
}
