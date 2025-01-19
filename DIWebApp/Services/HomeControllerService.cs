namespace DIWebApp.Services;
public interface IHomeControllerService
{
    string sayHello();
}

public class HomeControllerService:IHomeControllerService
{
    public string sayHello()
    {
        return "Hello everyone";
    }
}