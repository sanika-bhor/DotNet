// using ActionListener.Listener;
using ActionListener.publishers;
using FundTransfer.FileManager;
using FundTransfer.Listener;
using FundTransfer.models;
using FundTransfer.NotificationServices;
using FundTransfer.UIManager;

// NotificationService smsService=new SMSService();

// Account account=new Account(5000, smsService);

// account.addListener(new AccountsDepartment());
// account.withdraw(4500);
// account.deposite(300000);


// AccountDepartmentRepository accountDepartmentRepository=new AccountDepartmentRepository();
// List<Account> accounts=accountDepartmentRepository.GetAllAccounts();
// foreach(Account account in accounts)
// {
//     Console.WriteLine(account.Name);
// }


int choice;

do
{
    UIManager ui = new UIManager();
    ui.displayMenu();

    choice = ui.getChoice();
    IFileManager accountDepartmentRepository = new AccountDepartmentRepository();
    NotificationService smsService = new SMSService();
    List<Account> accounts = accountDepartmentRepository.GetAllAccounts();
    List<Operation> operations = accountDepartmentRepository.GetAllOperations();
    AccountDepartment accountDepartment = new AccountDepartment(accounts, smsService, accountDepartmentRepository);
    accountDepartment.addListener(new AccountEventHandler());
    switch (choice)
    {
        case 1:
        {
                string accno = ui.enterAccountNumber();
            double balance = accountDepartment.getBalance(accno);
            if (balance > 0)
            {
            ui.displayBalance(balance);
            }
            else
            {
                ui.displayMessage("Account not exists");
            }
            break;
    }
        case 2:
            {
                string accno = ui.enterAccountNumber();
                double amount = ui.enterAmount();
                bool status = accountDepartment.withdraw(accno, amount);
                if (status)
                {
                    Operation newOperation = new Operation { AccountNumber = accno, Status = "D", StatusMessage = "ATM cash withdrawal.", OperationON = DateTime.Now };
                    operations.Add(newOperation);
                    accountDepartmentRepository.saveOpeations(operations);
                    ui.displayMessage("withdraw amount succesfully");
                }
                else
                {
                    ui.displayMessage("does not withdraw amount first check your balance");
                }

                break;
            }
        case 3:
            {
                string accno = ui.enterAccountNumber();
                double amount = ui.enterAmount();
                bool status = accountDepartment.deposite(accno, amount);
                if (status)
                {
                    Operation newOperation = new Operation { AccountNumber = accno, Status = "C", StatusMessage = "Salary credited to account", OperationON = DateTime.Now };
                    operations.Add(newOperation);
                    accountDepartmentRepository.saveOpeations(operations);
                    ui.displayMessage("deposite amount successfully");
                }
                else
                {
                    ui.displayMessage("does not Deposite amount first check your balance");
                }
                break;
            }
        case 4:
            {
                double amount = ui.enterAmount();
                string fromAccount = ui.enterAccountNumber("from: ");
                string toAccount = ui.enterAccountNumber("To: ");

                bool status = accountDepartment.tranferFund(fromAccount, toAccount, amount);


                if (status)
                {
                    Operation newOperation1 = new Operation { AccountNumber = fromAccount, Status = "D", StatusMessage = "Fund transfer to "+toAccount, OperationON = DateTime.Now };
                    Operation newOperation2 = new Operation { AccountNumber = toAccount, Status = "C", StatusMessage = "Fund received from "+fromAccount, OperationON = DateTime.Now };
                    operations.Add(newOperation1);
                    operations.Add(newOperation2);
                    accountDepartmentRepository.saveOpeations(operations);
                     ui.displayMessage("fund transfer successfully");
                }
                else
                {
                    ui.displayMessage("fund not transfer!! check your balance");
                }
                break;
            }

        case 5:
            {
                Account account=ui.getAccountInfo();
                bool status=accountDepartment.createAccount(account);
                if (status)
                {
                    ui.displayMessage("account created successfully");
                }
                else
                {
                    ui.displayMessage("account not created");
                }
            }
            break;
            
        case 6:
            ui.exitApplication();
            break;
    }
} while (choice != 5);

