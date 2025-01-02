using SRP;

Console.WriteLine("Hello, World!");

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
