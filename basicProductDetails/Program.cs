using Repositories.ProductRepository;
using Controller.ProductController;
using Services.ProductService;
using UI.UiManager;
using Model.Catalog;
using FileManager.FileOperation;

ProductRepository repo=new ProductRepository();

Console.WriteLine("Welcome to Transflower Store!\n");

// Create a ProductRepository and add some products

Product product1 = new Product(1, "Gerbera", "Wedding Flower", 19.99,10);
Product product2 = new Product(2, "Rose", "Valentine Flower", 29.99,5);
Product product3 = new Product(3, "Jasmine", "Smelling Flower" , 39.99,20);
Product product4 = new Product(4, "Mango", " Devgad Alphanso", 49.99,15);

repo.insert(product1);
repo.insert(product2);
repo.insert(product3);
repo.insert(product4);

repo.getAll();

Console.WriteLine("Apply Discount and Calculate Total Price\n");


ProductService srv = new ProductService(repo);
srv.applyDiscount(1, 10); // Apply 10% discount to product with ID 1
srv.calculateTotalPrice(1); // Calculate total price for product with ID 1
srv.searchProductByTitle("Rose"); // Search for product by title
Console.WriteLine("Adding a new product...\n");


ProductController controller = new ProductController(repo, srv);

controller.insert(product1);
controller.getAll(); // Display all products after adding a new one

Console.WriteLine("Updating product at index 1...\n");

controller.update(new Product(2, "Lily", "Summer Flower", 25.99,12)); // Update product at index 1
controller.getAll(); // Display all products after update



UiManager uiManager=new UiManager();
uiManager.displayWelcomeMessage();
uiManager.handleUserInput(controller,srv); // Handle user input through the UIManager
uiManager.displayGoodbyeMessage();


Console.WriteLine("Thank you for visiting Transflower Store!\n");

