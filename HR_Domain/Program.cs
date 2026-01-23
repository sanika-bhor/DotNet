// See https://aka.ms/new-console-template for more information
using HR_Domin.HR;
using HR_Domin.HR.Interfaces;

Console.WriteLine("Hello, World!");

Console.WriteLine("\n\nSales Employee");
Employee salesEmp=new SalesEmployee(1,"sanika",20,30000,5000,10000);

salesEmp.DoWork();
Console.WriteLine(salesEmp);
salesEmp.ComputePay();

Console.WriteLine("\n\nSales Manager");
SalesManager salesMgr = new SalesManager(1, "sanika", 20, 30000, 5000, 10000,5000);
salesMgr.DoWork();
Console.WriteLine(salesMgr);
salesMgr.ComputePay();

IAppraisable appraisable=salesMgr;
appraisable.ConductAppraisal();

IBonusEligible bonusEligible=salesMgr;
bonusEligible.CalculateBonus();

IInterviewPanel interviewPanel=salesMgr;
interviewPanel.TakeInterview();


Console.WriteLine("\n\nHR");
Employee hrMgr = new HRManager(1, "sanika", 20, 30000,5000);
hrMgr.DoWork();
Console.WriteLine(hrMgr);
hrMgr.ComputePay();
if(hrMgr.Equals(salesMgr))
{
    Console.WriteLine("hrMgr is the object of HRManager");
}
else
{
    Console.WriteLine("Not the object of HRManager");
}

