using Catalog;
using Repository.ProductRepository;

// Product marigold = new Product();
// marigold.display();
// marigold.setTitle("Marigold");
// marigold.setDescription("festival flowers");
// marigold.display();

// Product gerbera = new Product(2, "gerbera", "beautiful flower", 6, 13);
// gerbera.display();



// // int id;
// // string name;
// // string description;
// // double price;
// // int quantity;

// // Console.WriteLine("Enter Product Id:");
// // id = Convert.ToInt32(Console.ReadLine());

// // Console.WriteLine("Enter Product Title:");
// // name = Console.ReadLine();

// // Console.WriteLine("Enter Product Description:");
// // description = Console.ReadLine();

// // Console.WriteLine("Enter Product UnitPrice");
// // price = Convert.ToDouble(Console.ReadLine());

// // Console.WriteLine("Enter ProductQuantity");
// // quantity = Convert.ToInt32(Console.ReadLine());

// // Product newFlower = new Product(id, name, description, price, quantity);
// // newFlower.display();



ProductRepository repo = new ProductRepository();

Console.WriteLine("***********Product details***********************");
Console.WriteLine("1.Insert new Product");
Console.WriteLine("2.Display all Products");
Console.WriteLine("3.Update Existing Product");
Console.WriteLine("4.Delete Existing Product");
Console.WriteLine("5.Exit");
int choice;
do
{
    Console.WriteLine("Enter your choice:");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Product Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Title:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Product UnitPrice");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Product Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Product newProduct = new Product(id, name, description, price, quantity);
            repo.insert(newProduct);
            break;

        case 2:
            List<Product> allProducts = repo.getAll();
            if (allProducts != null)
            {
                foreach (Product p in allProducts)
                {
                    p.display();
                    Console.WriteLine("------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("no product available");
            }
            break;

        case 3:
            Console.WriteLine("Enter Product Id to update:");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Product Title:");
            string nameToUpdate = Console.ReadLine();
            Console.WriteLine("Enter new Product Description:");
            string descriptionToUpdate = Console.ReadLine();
            Console.WriteLine("Enter new Product UnitPrice");
            double priceToUpdate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter new Product Quantity");
            int quantityToUpdate = Convert.ToInt32(Console.ReadLine());
            Product updateProduct = new Product(idToUpdate, nameToUpdate, descriptionToUpdate, priceToUpdate, quantityToUpdate);
            repo.update(updateProduct);
            break;

        case 4:
            Console.WriteLine("Enter Product Id to delete:");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            repo.delete(idToDelete);
            break;

        case 5:
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;

    }
} while (choice != 5);