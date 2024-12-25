using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoginForm lfre = new LoginForm();   
            lfre.ShowDialog();
        }

        private void onFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        private void onFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }

        private void onFileExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onMenuLogin(object sender, EventArgs e)
        {
            LoginForm Lfrm=new LoginForm();
            Lfrm.ShowDialog();
        }

      
    }
}
