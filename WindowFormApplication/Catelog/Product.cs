
using System;

namespace Catalog
{
    [Serializable]
    public class Product:IDisposable
    {
        private int id;
        private string tittle;
        private string discription;
        private int quntity;
        private int unitPrice;


        public Product()
        {
            this.id = 1;
            this.tittle = "rose";
            this.discription = "valentine flower";
            this.quntity = 20;
            this.unitPrice = 5;
        }

        public Product(int id, string tittle, string discription, int quntity, int unitPrice)
        {
            this.id = id;
            this.tittle = tittle;
            this.discription = discription;
            this.quntity = quntity;
            this.unitPrice = unitPrice;

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tittle
        {
            get { return tittle; }
            set { tittle = value; }
        }

        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        public int Quantity
        {
            get { return quntity; }
            set { quntity = value; }
        }
        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public void Dispose()
        {
            Console.WriteLine("Relesing resources");
            GC.SuppressFinalize(this);
        }
        public override string ToString()
        {
            return this.id + " " + this.tittle + " " + this.discription + " " + this.quntity + " " + this.unitPrice;
        }
        ~Product()
        {
            Console.WriteLine("Relesing resources By constructor");

        }
    }
}
