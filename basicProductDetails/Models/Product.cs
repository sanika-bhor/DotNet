using System.Text.Json.Serialization;

namespace Model.Catalog
{
    // [Serializable]
    public class Product
    {

        private int id;
        private string title;
        private string description;
        private double unitPrice;
        private int quantity;

        public Product()
        {
            this.id = 1;
            this.title = "Rose";
            this.description = "Red rose";
            this.unitPrice = 20;
            this.quantity = 10;
        }

        public Product(int id, string title, string des, double price, int quantity)
        {
            this.id = id;
            this.title = title;
            this.description = des;
            this.unitPrice = price;
            this.quantity = quantity;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getTitle()
        {
            return this.title;
        }

        public void setDescription(string des)
        {
            this.description = des;
        }

        public string getDescription()
        {
            return this.description;
        }

        public void setPrice(double p)
        {
            this.unitPrice = p;
        }

        public double getPice()
        {
            return this.unitPrice;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public int getQuantity()
        {
            return this.quantity;
        }

        public double getTotalPrice() { return quantity * unitPrice; }
        public double getDiscountedPrice(double discount)  { return unitPrice- (unitPrice * discount / 100); }


public void display()
        {
            Console.WriteLine("-----------PRODUCT DETAILS------------");
            Console.WriteLine("Id:" + id);
            Console.WriteLine("Title:" + title);
            Console.WriteLine("Description:" + description);
            Console.WriteLine("UnitPrice" + unitPrice);
            Console.WriteLine("Quantity" + quantity);
            Console.WriteLine();
        }
    }
}



