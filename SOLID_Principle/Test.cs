using SRP;

Console.WriteLine("Hello, World!");

IServerUtility utility = new ServiceUtility();
Server server = new Server(utility);

server.GetMessageService();
server.DoService();
server.DispatchService();