using SRP;
using OCP;
using LSP;
using ISP;

Console.WriteLine("Hello, World!");

//**************SRP (Single responsibilty principle) test**********************
//object of serverUtility
IServerUtility utility = new ServiceUtility();

//object of NotificationUtility
IServerUtility notify=new NotificationUtility();

//creating SRP (single resposibility principle) 
//server is a single class  that can handle responsibility of multify classes by passing object as a paramater
// so that it can call perticular method of different classes
Server server = new Server(utility);
Server notifyServer=new Server(notify);

//handle serviceUtility 
server.GetMessageService();
server.DoService();
server.DispatchService();

//handle NotificationUtility 
notifyServer.GetMessageService();
notifyServer.DoService();
notifyServer.DispatchService();

Console.WriteLine();
Console.WriteLine();


//**********************OCP(Open Closed Principle) Test**********************
// Open for extension but closed for modification
// open for extension means we can add new functionality without modifying existing code
// closed for modification means we can modify existing code without affezsecting other functionality
IAccount regularAccount=new RegularSavingAccount();
regularAccount.CalculateInterest();

IAccount salaryAccount=new SalarySavingAccount();
salaryAccount.CalculateInterest();

IAccount corporateAccount=new CorporateSavingAccount();
corporateAccount.CalculateInterest();

Console.WriteLine();
Console.WriteLine();

//**********************LSP(Liskov's substitution principle) Test**********************
Triangle triangle=new Triangle();
triangle.Draw();

Circle circle=new Circle();
circle.Draw();

Console.WriteLine();
Console.WriteLine();

//**********************ISP(Interface segragation principle) Test**********************
IOrder order=new OnlineOrder();
order.AddToCart();
IOnlineOrder onlineOrder=new OnlineOrder();
onlineOrder.PayOnline();

IOrder oflineOrder=new OflineOrder();
oflineOrder.AddToCart();


