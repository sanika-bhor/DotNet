using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using Catalog;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        List<Product> products=new List<Product>();
        int i = 0;

        public MainForm()
        {

            Product product = new Product
            {
                Id = 1,
                Tittle = "rose",
                Discription = "valentine",
                UnitPrice = 25,
                Quantity = 560
            };
          //  products.Add(product);

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
            MessageBox.Show("product inserted successfully");

            Id.Text = null;
            ProductName.Text = null;
            Description.Text = null;
            UnitPrice.Text = null;
            Quantity.Text = null;

        }

        private void onNext(object sender, EventArgs e)
        {
            if (i > products.Count)
            {
                MessageBox.Show("something went wrong");
            }
            else
            {
               i++;
                Id.Text = products[i].Id.ToString();
                ProductName.Text = products[i].Tittle;
                Description.Text = products[i].Discription;
                UnitPrice.Text = products[i].UnitPrice.ToString();
                Quantity.Text = products[i].Quantity.ToString();
             }
        }


        private void onFirst(object sender, EventArgs e)
        {
            Id.Text=products[0].Id.ToString();
            ProductName.Text = products[0].Tittle;
            Description.Text = products[0].Discription;
            UnitPrice.Text=products[0].UnitPrice.ToString();
            Quantity.Text = products[0].Quantity.ToString();
        }

        private void onLast(object sender, EventArgs e)
        {
            Id.Text = products[products.Count-1].Id.ToString();
            ProductName.Text = products[products.Count-1].Tittle;
            Description.Text = products[products.Count - 1].Discription;
            UnitPrice.Text = products[products.Count-1].UnitPrice.ToString();
            Quantity.Text = products[products.Count - 1].Quantity.ToString();
        }

        private void onPrev(object sender, EventArgs e)
        {
            if (i < 0)
            {
                MessageBox.Show("something went wrong");
            }
            else
            {
                i--;
                Id.Text = products[i].Id.ToString();
                ProductName.Text = products[i].Tittle;
                Description.Text = products[i].Discription;
                UnitPrice.Text = products[i].UnitPrice.ToString();
                Quantity.Text = products[i].Quantity.ToString();
            }
        }
    }
}
