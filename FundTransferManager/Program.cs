using ActionListener.Listener;
using ActionListener.publishers;
using ActionListener.Services;

NotificationService smsService=new SMSService();

Account account=new Account(5000, smsService);

account.addListener(new AccountsDepartment());
account.withdraw(4500);
account.deposite(300000);
