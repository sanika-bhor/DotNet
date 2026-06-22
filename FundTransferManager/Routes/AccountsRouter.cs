
using ActionListener.publishers;
using TFLBank.FileManager;
using TFLBank.Listener;
using TFLBank.models;
using TFLBank.NotificationServices;
using TFLBank.UIManagers;


namespace TFLBank.Routes
{
    public class AccountsRouter
    {
        int choice;
        IAccountsRepository accountsRepository = new AccountsRepository();
        IOperationsRepository operationsRespository = new OperationsRepository();
        INotificationService smsService = new SMSService();
       
        UIManager ui = new UIManager();

        public void BankingOperations()
        {
            List<Account> accounts = accountsRepository.GetAllAccounts();
            List<Operation> operations = operationsRespository.GetAllOperations();
            AccountsDepartment accountDepartment = new AccountsDepartment(accounts, smsService, accountsRepository, operationsRespository);

            accountDepartment.addListener(new AccountsHandler());
            
            do
            {
                ui.DisplayMenu();
                choice = ui.GetChoice();
                
                switch (choice)
                {
                    case 1:
                        {
                            string accno = ui.EnterAccountNumber();
                            double balance = accountDepartment.GetBalance(accno);
                            if (balance > 0)
                            {
                                ui.DisplayBalance(balance);
                            }
                            else
                            {
                                ui.DisplayMessage("Account not exists");
                            }
                            break;
                        }
                    case 2:
                        {
                            string accno = ui.EnterAccountNumber();
                            double amount = ui.EnterAmount();
                            bool status = accountDepartment.Withdraw(accno, amount);
                            if (status)
                            {
                                Operation newOperation = new Operation { AccountNumber = accno, Status = "D", StatusMessage = "ATM cash withdrawal.", OperationON = DateTime.Now, Amount = amount };
                                operations.Add(newOperation);
                                operationsRespository.SaveOpeations(operations);
                                ui.DisplayMessage("withdraw amount succesfully");
                            }
                            else
                            {
                                ui.DisplayMessage("does not withdraw amount first check your balance");
                            }

                            break;
                        }
                    case 3:
                        {
                            string accno = ui.EnterAccountNumber();
                            double amount = ui.EnterAmount();
                            bool status = accountDepartment.Deposit(accno, amount);
                            if (status)
                            {
                                Operation newOperation = new Operation { AccountNumber = accno, Status = "C", StatusMessage = "Salary credited to account", OperationON = DateTime.Now, Amount = amount };
                                operations.Add(newOperation);
                                operationsRespository.SaveOpeations(operations);
                                ui.DisplayMessage("deposite amount successfully");
                            }
                            else
                            {
                                ui.DisplayMessage("does not Deposite amount first check your balance");
                            }
                            break;
                        }
                    case 4:
                        {
                            double amount = ui.EnterAmount();
                            string fromAccount = ui.EnterAccountNumber("from: ");
                            string toAccount = ui.EnterAccountNumber("To: ");

                            bool status = accountDepartment.FundTransfer(fromAccount, toAccount, amount);


                            if (status)
                            {
                                Operation newOperation1 = new Operation { AccountNumber = fromAccount, Status = "D", StatusMessage = "Fund transfer to " + toAccount, OperationON = DateTime.Now, Amount = amount };
                                Operation newOperation2 = new Operation { AccountNumber = toAccount, Status = "C", StatusMessage = "Fund received from " + fromAccount, OperationON = DateTime.Now, Amount = amount };
                                operations.Add(newOperation1);
                                operations.Add(newOperation2);
                                operationsRespository.SaveOpeations(operations);
                                ui.DisplayMessage("fund transfer successfully");
                            }
                            else
                            {
                                ui.DisplayMessage("fund not transfer!! check your balance");
                            }
                            break;
                        }

                    case 5:
                        {
                            Account account = ui.GetAccountInfo();
                            bool status = accountDepartment.CreateAccount(account);
                            if (status)
                            {
                                ui.DisplayMessage("account created successfully");
                            }
                            else
                            {
                                ui.DisplayMessage("account not created");
                            }
                        }
                        break;

                    case 6:
                        {
                            string accno = ui.EnterAccountNumber();
                            List<Operation> miniStatement = accountDepartment.GetMiniStatement(accno);
                            double balance = accountDepartment.GetBalance(accno);
                            ui.DisplayBalance(balance);
                            foreach (Operation op in miniStatement)
                            {

                                ui.DisplayOperation(op);

                            }
                            break;
                        }

                    case 7:
                        ui.ExitApplication();
                        break;
                }
            } while (choice != 7);

        }
    }
}