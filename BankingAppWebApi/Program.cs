using ActionListener.publishers;
using TFLBank.FileManager;
using TFLBank.models;
using TFLBank.NotificationServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IAccountsRepository,AccountsRepository>();
builder.Services.AddScoped<ITransactionsRepository,TransactionsRepository>();
builder.Services.AddScoped<INotificationService,SMSService>();
builder.Services.AddScoped<AccountsDepartment>(); 

var app = builder.Build();
app.UseHttpsRedirection();


app.MapGet("/GetBalance/{accountNumber}", (string accountNumber, AccountsDepartment accountDepartment) =>
{
    double currentBalance = accountDepartment.GetBalance(accountNumber);
    Account account = accountDepartment.GetAccount(accountNumber);
    if (currentBalance > 0)
    {
        return Results.Ok(new
        {
            Account = account,
            Balance = currentBalance
        });
    }
    return Results.NotFound("Account does not exist");

});

app.MapPost("/Withdraw/{accountNumber}/Amount/{withdrawAmount}", (string accountNumber,double withdrawAmount, AccountsDepartment accountDepartment,ITransactionsRepository transactionsRespository) =>
{
    List<Transaction> transactionHistory = transactionsRespository.LoadTransactions();
    bool isWithdrawSucessful = accountDepartment.Withdraw(accountNumber, withdrawAmount);
    double updatedBalance = accountDepartment.GetBalance(accountNumber);
    if (isWithdrawSucessful)
    {
        Transaction withdrawalTransaction = new Transaction { AccountNumber = accountNumber, TransactionStatus = "D", StatusMessage = "ATM cash withdrawal.", TransactionDate = DateTime.Now, Amount = withdrawAmount, CurrentBalance = updatedBalance };
        transactionHistory.Add(withdrawalTransaction);
        transactionsRespository.SaveTransactions(transactionHistory);
        return Results.Ok("withdraw amount succesfully");
    }
    else
    {
        return Results.NotFound("does not withdraw amount first check your balancet");
    }
});

app.MapPost("/Deposite/{accountNumber}/Amount/{depositAmount}", (string accountNumber, double depositAmount, AccountsDepartment accountDepartment, ITransactionsRepository transactionsRespository) =>
{
    List<Transaction> transactionsHistory = transactionsRespository.LoadTransactions();
  
    bool isDepositeSucessful = accountDepartment.Deposit(accountNumber, depositAmount);
    double updatedBalance = accountDepartment.GetBalance(accountNumber);
    if (isDepositeSucessful)
    {
        Transaction depositTransaction = new Transaction { AccountNumber = accountNumber, TransactionStatus = "C", StatusMessage = "Salary credited to account", TransactionDate = DateTime.Now, Amount = depositAmount, CurrentBalance = updatedBalance };
        transactionsHistory.Add(depositTransaction);
        transactionsRespository.SaveTransactions(transactionsHistory);
        return Results.Ok("deposite amount successfully");
    }
    else
    {
        return Results.NotFound("does not Deposite amount first check your balance");
    }

});

app.MapPost("/FundTransfer/From/{fromAccountNumber}/To/{toAccountNumber}/Amount/{transferAmount}", (string fromAccountNumber,string toAccountNumber, double transferAmount, AccountsDepartment accountDepartment, ITransactionsRepository transactionsRespository) =>
{
    List<Transaction> transactionsHistory = transactionsRespository.LoadTransactions();

    bool isTransferSucessful = accountDepartment.FundTransfer(fromAccountNumber, toAccountNumber, transferAmount);

    if (isTransferSucessful)
    {
        double fromAccountUpdatedBalance = accountDepartment.GetBalance(fromAccountNumber);
        double toAccountUpdatedBalance = accountDepartment.GetBalance(toAccountNumber);
        Transaction withdrawalTransaction = new Transaction { AccountNumber = fromAccountNumber, TransactionStatus = "D", StatusMessage = "Fund transfer to " + toAccountNumber, TransactionDate = DateTime.Now, Amount = transferAmount, CurrentBalance = fromAccountUpdatedBalance };
        Transaction depositTransaction = new Transaction { AccountNumber = toAccountNumber, TransactionStatus = "C", StatusMessage = "Fund received from " + fromAccountNumber, TransactionDate = DateTime.Now, Amount = transferAmount, CurrentBalance = toAccountUpdatedBalance };
        transactionsHistory.Add(withdrawalTransaction);
        transactionsHistory.Add(depositTransaction);
        transactionsRespository.SaveTransactions(transactionsHistory);
        return Results.Ok("fund transfer successfully");
    }
    else
    {
        return Results.NotFound("fund not transfer!! check your balance");
    }

});

app.MapPost("/AddAccount", (Account newAccount, AccountsDepartment accountDepartment) =>
{
    bool isAccountCreated = accountDepartment.CreateAccount(newAccount);
    if (isAccountCreated)
    {
        return Results.Ok("account created successfully");
    }
    else
    {
        return Results.NotFound("account not created");
    }

});

app.MapGet("/Ministatement/{accountNumber}", (string accountNumber, AccountsDepartment accountDepartment) =>
{
    List<Transaction> miniStatement = accountDepartment.GetMiniStatement(accountNumber);
    return Results.Ok(miniStatement);

});

app.MapPost("/CalculateInterest/{accountNumber}", (string accountNumber, AccountsDepartment accountDepartment, ITransactionsRepository transactionsRespository) =>
{
    List<Transaction> transactionsHistory = transactionsRespository.LoadTransactions();
    double totalInterest = accountDepartment.CalculateInterest(accountNumber);

    bool isDepositeSucessful = accountDepartment.Deposit(accountNumber, totalInterest);

    double updatedBalance = accountDepartment.GetBalance(accountNumber);
    if (isDepositeSucessful)
    {
        Transaction newOperation = new Transaction { AccountNumber = accountNumber, TransactionStatus = "I", StatusMessage = "Interest is deposited", TransactionDate = DateTime.Now, Amount = totalInterest, CurrentBalance = updatedBalance };
        transactionsHistory.Add(newOperation);
        transactionsRespository.SaveTransactions(transactionsHistory);
        return Results.Ok("Interest amount deposit successfully");
    }
    else
    {
        return Results.NotFound("Interest amount not deposit");
    }
});

app.MapPost("/ApplyInterestForAll/", ( AccountsDepartment accountDepartment) =>
{
    bool applyInterestStatus = accountDepartment.ApplyInterest();
    if (applyInterestStatus)
    {
        return Results.Ok("Interest amount deposit successfully");
    }
    else
    {
        return Results.NotFound("Interest amount not deposit");
    }
});

app.Run();
