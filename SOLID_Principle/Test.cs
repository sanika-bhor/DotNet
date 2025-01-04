using SRP;
using OCP;
using LSP;
using ISP;
using DIP;

Console.WriteLine("Hello, World!");

//**************SRP (Single responsibilty principle) test**********************
//object of serverUtility
IServerUtility utility = new ServiceUtility();

//object of NotificationUtility
IServerUtility notify=new NotificationUtility();

//creating SRP (single resposibility principle) 
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

IBankAccount regularAccount=new RegularSavingAccount();
regularAccount.CalculateInterest();

IBankAccount salaryAccount=new SalarySavingAccount();
salaryAccount.CalculateInterest();

IBankAccount corporateAccount=new CorporateSavingAccount();
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

Console.WriteLine();
Console.WriteLine();

//**********************DCP(Dependency inversion principle) Test**********************
IAccount account= new Admin();
AccountController controller=new AccountController(account);
controller.Login();
controller.Register();

account=new User();
AccountController controller1=new AccountController(account);
controller1.Login();
controller1.Register();