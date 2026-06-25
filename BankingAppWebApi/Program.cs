using ActionListener.publishers;
using TFLBank.FileManager;
using TFLBank.models;
using TFLBank.NotificationServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IAccountsRepository,AccountsRepository>();
builder.Services.AddScoped<IOperationsRepository,OperationsRepository>();
builder.Services.AddScoped<INotificationService,SMSService>();
builder.Services.AddScoped<AccountsDepartment>();

var app = builder.Build();


app.UseHttpsRedirection();

// IAccountsRepository accountsRepository = new AccountsRepository();
// IOperationsRepository operationsRespository = new OperationsRepository();
// INotificationService smsService = new SMSService();

// AccountsDepartment accountDepartment = new AccountsDepartment(smsService, accountsRepository, operationsRespository);

app.MapGet("/GetBalance/{accno}", (string accno, AccountsDepartment accountDepartment) =>
{
    double balance = accountDepartment.GetBalance(accno);
    Account account = accountDepartment.GetAccount(accno);
    if (balance > 0)
    {
        return Results.Ok(new
        {
            Account = account,
            Balance = balance
        });
    }

    return Results.NotFound("Account does not exist");

});


app.MapPost("/Withdraw/{accno}/Amount/{amount}", (string accno,double amount, AccountsDepartment accountDepartment,IOperationsRepository operationsRespository) =>
{
    List<Operation> operations = operationsRespository.GetAllOperations();
    bool status = accountDepartment.Withdraw(accno, amount);
    double balance = accountDepartment.GetBalance(accno);
    if (status)
    {
        Operation newOperation = new Operation { AccountNumber = accno, Status = "D", StatusMessage = "ATM cash withdrawal.", OperationON = DateTime.Now, Amount = amount, CurrentBalance = balance };
        operations.Add(newOperation);
        operationsRespository.SaveOpeations(operations);
        return Results.Ok("withdraw amount succesfully");
    }
    else
    {
        return Results.NotFound("does not withdraw amount first check your balancet");
    }

});



app.MapPost("/Deposite/{accno}/Amount/{amount}", (string accno, double amount, AccountsDepartment accountDepartment, IOperationsRepository operationsRespository) =>
{
    List<Operation> operations = operationsRespository.GetAllOperations();
  
    bool status = accountDepartment.Deposit(accno, amount);
    double balance = accountDepartment.GetBalance(accno);
    if (status)
    {
        Operation newOperation = new Operation { AccountNumber = accno, Status = "C", StatusMessage = "Salary credited to account", OperationON = DateTime.Now, Amount = amount, CurrentBalance = balance };
        operations.Add(newOperation);
        operationsRespository.SaveOpeations(operations);
        return Results.Ok("deposite amount successfully");
    }
    else
    {
        return Results.NotFound("does not Deposite amount first check your balance");
    }

});

app.MapPost("/FundTransfer/From/{fromaccno}/To/{toaccno}/Amount/{amount}", (string fromaccno,string toaccno, double amount, AccountsDepartment accountDepartment, IOperationsRepository operationsRespository) =>
{
    List<Operation> operations = operationsRespository.GetAllOperations();

    bool status = accountDepartment.FundTransfer(fromaccno, toaccno, amount);


    if (status)
    {
        double fromAccountBalance = accountDepartment.GetBalance(fromaccno);
        double toAccountBalance = accountDepartment.GetBalance(toaccno);
        Operation newOperation1 = new Operation { AccountNumber = fromaccno, Status = "D", StatusMessage = "Fund transfer to " + toaccno, OperationON = DateTime.Now, Amount = amount, CurrentBalance = fromAccountBalance };
        Operation newOperation2 = new Operation { AccountNumber = toaccno, Status = "C", StatusMessage = "Fund received from " + fromaccno, OperationON = DateTime.Now, Amount = amount, CurrentBalance = toAccountBalance };
        operations.Add(newOperation1);
        operations.Add(newOperation2);
        operationsRespository.SaveOpeations(operations);
        return Results.Ok("fund transfer successfully");
    }
    else
    {
        return Results.NotFound("fund not transfer!! check your balance");
    }

});


app.MapPost("/AddAccount", (Account account, AccountsDepartment accountDepartment) =>
{
    bool status = accountDepartment.CreateAccount(account);
    if (status)
    {
        return Results.Ok("account created successfully");
    }
    else
    {
        return Results.NotFound("account not created");
    }

});


app.MapGet("/Ministatement/{accno}", (string accno, AccountsDepartment accountDepartment) =>
{
    List<Operation> miniStatement = accountDepartment.GetMiniStatement(accno);
    return Results.Ok(miniStatement);

});


app.MapGet("/CalculateInterest/{accno}", (string accno, AccountsDepartment accountDepartment, IOperationsRepository operationsRespository) =>
{
    List<Operation> operations = operationsRespository.GetAllOperations();
    double totalInterest = accountDepartment.CalculateInterest(accno);

    bool status = accountDepartment.Deposit(accno, totalInterest);

    double balance = accountDepartment.GetBalance(accno);
    if (status)
    {
        Operation newOperation = new Operation { AccountNumber = accno, Status = "I", StatusMessage = "Interest is deposited", OperationON = DateTime.Now, Amount = totalInterest, CurrentBalance = balance };
        operations.Add(newOperation);
        operationsRespository.SaveOpeations(operations);
        return Results.Ok("Interest amount deposit successfully");
    }
    else
    {
        return Results.NotFound("Interest amount not deposit");
    }
});

app.Run();
