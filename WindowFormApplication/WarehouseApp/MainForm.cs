using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Catalog;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        List<Product> products=new List<Product>();

        public MainForm()
        {
            InitializeComponent();
            LoginForm lfre = new LoginForm();   
           // lfre.ShowDialog();
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

        private void onInsert(object sender, EventArgs e)
        {
            int id = int.Parse(Id.Text);
            string name = ProductName.Text;
            string description = Description.Text;
            int unitPrice = int.Parse(UnitPrice.Text);
            int quantity = int.Parse(Quantity.Text);

            Product product=new Product
            {
                Id = id,
                Tittle=name,
                Discription=description,
                UnitPrice=unitPrice,
                Quantity=quantity
            };

            products.Add(product);
          //  MessageBox.Show("product inserted successfully");
        }

        
    }
}
