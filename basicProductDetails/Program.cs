using Catalog;

Product marigold = new Product();
marigold.display();
marigold.setTitle("Marigold");
marigold.setDescription("festival flowers");
marigold.display();

Product gerbera = new Product(2, "gerbera", "beautiful flower", 6, 13);
gerbera.display();



int id;
string name;
string description;
double price;
int quantity;

Console.WriteLine("Enter Product Id:");
id = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter Product Title:");
name = Console.ReadLine();

Console.WriteLine("Enter Product Description:");
description = Console.ReadLine();

Console.WriteLine("Enter Product UnitPrice");
price = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter ProductQuantity");
quantity = Convert.ToInt32(Console.ReadLine());

Product newFlower = new Product(id, name, description, price, quantity);
newFlower.display();