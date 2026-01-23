namespace HR_Domin.HR
{
    public abstract class Employee
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public int Age{get;set;}
        public double BaseSalary{get;set;}
        public Employee()
        {
            Id=0;
            Name="";
            Age=0;
            BaseSalary=0;
            Console.WriteLine("Constructor from Employee");
        }

        public Employee(int id, string name,int age,double baseSalary)
        {
            Id = id;
            Name = name;
            Age = age;
            BaseSalary = baseSalary;
            
        }

        public override string ToString()
        {
            return "Id: "+Id+"\nName: "+Name+"\nAge: "+Age;
        }
        public abstract void DoWork();
        public abstract void ComputePay();
    }
}