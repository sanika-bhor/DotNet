using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Catalog;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        List<Product> products=new List<Product>();
        int i=0;

        public MainForm()
        {

             InitializeComponent();
             LoginForm lfre = new LoginForm();   
             lfre.ShowDialog();
        }

        private void onFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                string fileName=openFileDialog.FileName;
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                products=(List<Product>)bf.Deserialize(stream);
                stream.Close();

                dataGridView1.DataSource = products;
            }
        }

        private void onFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream,products);
                stream.Close();
            }
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
           // MessageBox.Show("product inserted successfully");

            Id.Text = null;
            ProductName.Text = null;
            Description.Text = null;
            UnitPrice.Text = null;
            Quantity.Text = null;

            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = products; 
        }

        private void onNext(object sender, EventArgs e)
        {
            if(i== products.Count-1)
            {
                MessageBox.Show("No products available.");               
            }
            else if (i != products.Count)
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
            i = 0;
            Id.Text = products[i].Id.ToString();
            ProductName.Text = products[i].Tittle;
            Description.Text = products[i].Discription;
            UnitPrice.Text = products[i].UnitPrice.ToString();
            Quantity.Text = products[i].Quantity.ToString();
        }

        private void onLast(object sender, EventArgs e)
        {
            i=products.Count-1;
            Id.Text = products[i].Id.ToString();
            ProductName.Text = products[i].Tittle;
            Description.Text = products[i].Discription;
            UnitPrice.Text = products[i].UnitPrice.ToString();
            Quantity.Text = products[i].Quantity.ToString();
        }

        private void onPrev(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MessageBox.Show("No products available.");

            }
            else if (i != 0 )
            { 
                i--;
                Id.Text = products[i].Id.ToString();
                ProductName.Text = products[i].Tittle;
                Description.Text = products[i].Discription;
                UnitPrice.Text = products[i].UnitPrice.ToString();
                Quantity.Text = products[i].Quantity.ToString();
            }
        }

        private void onRemove(object sender, EventArgs e)
        {
            int id = int.Parse(Id.Text);
            string name = ProductName.Text;
            string description = Description.Text;
            int unitPrice = int.Parse(UnitPrice.Text);
            int quantity = int.Parse(Quantity.Text);

         
            foreach (Product p in products)
            {
                if(p.Id == id)
                {
                    products.Remove(p);
                }
            }
        }

        private void onUpdate(object sender, EventArgs e)
        {
            bool status=false;
            int id = int.Parse(Id.Text);
            string name = ProductName.Text;
            string description = Description.Text;
            int unitPrice = int.Parse(UnitPrice.Text);
            int quantity = int.Parse(Quantity.Text);

            Product product = new Product
            {
                Id = id,
                Tittle = name,
                Discription = description,
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            foreach (Product p in products)
            {
                if(p.Id==id)
                {
                    products.Remove(p);
                    status = true;
                    break;
                }
            }

            if (status)
            {
                products.Add(product);
            }
            else
            {
                MessageBox.Show("No such product to update check this id is available or not");
            }

            Id.Text = null;
            ProductName.Text = null;
            Description.Text = null;
            UnitPrice.Text = null;
            Quantity.Text = null;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
        }
    }
}
