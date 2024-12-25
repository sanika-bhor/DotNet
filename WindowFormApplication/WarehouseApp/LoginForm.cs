using System;
using System.Windows.Forms;
using MemberShip;

namespace WarehouseApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void onLogin(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            bool status = false;

            status=AccountManager.Login(userName, password);
            if(status)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid user!! please, try again");
            }
        }
    }
}
