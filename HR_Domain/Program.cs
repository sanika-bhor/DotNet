// See https://aka.ms/new-console-template for more information
using HR_Domin.HR;

Console.WriteLine("Hello, World!");

Console.WriteLine("\n\nSales Employee");
Employee salesEmp=new SalesEmployee(1,"sanika",20,30000,5000,10000);

salesEmp.DoWork();
Console.WriteLine(salesEmp);
salesEmp.ComputePay();

Console.WriteLine("\n\nSales Manager");
Employee salesMgr = new SalesManager(1, "sanika", 20, 30000, 5000, 10000,5000);
salesMgr.DoWork();
Console.WriteLine(salesMgr);
salesMgr.ComputePay();