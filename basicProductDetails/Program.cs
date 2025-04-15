using Model.Catalog;
using Repository.ProductRepository;
using Controller.ProductController;
using Services.ProductService;

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



ProductRepository repo=new ProductRepository();
ProductService srv=new ProductService(repo);
ProductController cont = new ProductController(repo,srv);

Console.WriteLine("***********Product details***********************");
Console.WriteLine("1.Insert new Product");
Console.WriteLine("2.Display all Products");
Console.WriteLine("3.Update Existing Product");
Console.WriteLine("4.Delete Existing Product");
Console.WriteLine("5.Apply discount for product");
Console.WriteLine("6.Calculate totalprice");
Console.WriteLine("7.get Product by Title");
Console.WriteLine("8.Exit");
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
            cont.insert(newProduct);
            break;

        case 2:
            cont.getAll();
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
            cont.update(updateProduct);
            break;

        case 4:
            Console.WriteLine("Enter Product Id to delete:");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            cont.delete(idToDelete);
            break;

        case 5:
            Console.WriteLine("Enter Product Id to apply discount:");
            int idToDiscount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter total discount percentage:");
            double discountPercentage = Convert.ToDouble(Console.ReadLine());
            srv.applyDiscount(idToDiscount, discountPercentage);
        break;

        case 6:
            Console.WriteLine("Enter Product Id to calculate total price:");
            int idToCalculateTotalPrice = Convert.ToInt32(Console.ReadLine());
            srv.calculateTotalPrice(idToCalculateTotalPrice);
        break;

        case 7:
            Console.WriteLine("Enter Product title to search product:");
            string titleToSearch = Console.ReadLine();
            srv.searchProductByTitle(titleToSearch);
            break;
        case 8:
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;

    }
} while (choice != 8);