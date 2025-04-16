using Controller.ProductController;
using Model.Catalog;
using Repositories.ProductRepository;
using Services.ProductService;

namespace UI.UiManager
{
    public class UiManager{


        
        public void displayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Transflower Store!");
        }

       public void displayGoodbyeMessage()
        {
            Console.WriteLine("Thank you for visiting Transflower Store!");
        }
        public void displayErrorMessage(string message) {
			 Console.WriteLine("Error: " +message );
		}
		public void displaySuccessMessage(string message)
        {
            Console.WriteLine("Success: " + message );
        }


       public void displayProductDetails(Product product) {
			product.display();
		}

		public void displayProducts(ProductRepository repo)
        {
            repo.getAll();
        }

       public void displayProductNotFound()
        {
           Console.WriteLine("Product not found!" );
        }

        void displayProductAdded()
        {
            Console.WriteLine("Product added successfully!");
        }

        public void displayMenu()
        {
            Console.WriteLine("***********Product details***********************");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Remove Product");
            Console.WriteLine("4. Display Products");
            Console.WriteLine("5.Apply discount");
            Console.WriteLine("6.Calculate total price");
            Console.WriteLine("7.Search Product by Title");
            Console.WriteLine("8.Exit");
        }


       public Product getProductDetails()
        {
            Console.WriteLine("Enter Product ID: ");
           int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Title: ");
          string  title= Console.ReadLine();
            Console.WriteLine("Enter Description: ");
           string description = Console.ReadLine();
            Console.WriteLine("Enter Quantity: ");
          double  price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Price: ");
           int quantity = Convert.ToInt32(Console.ReadLine());

            Product p=new Product(id,title,description,price,quantity);
            return p;
        }

       public void getDiscountDetails(out int productId,out double discount)
        {
            Console.WriteLine("Enter Product Id to apply discount:");
            productId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter total discount percentage:");
            discount = Convert.ToDouble(Console.ReadLine());
        }


       public int getProductId( )
        {
            Console.WriteLine("Enter Product Id to apply discount:");
           int productId = Convert.ToInt32(Console.ReadLine());
           return productId;
        }

        public int getProductIndex()
        {
             Console.WriteLine("Enter Product index:");
           int index = Convert.ToInt32(Console.ReadLine());
           return index;
        }




        public string getProductTitle()
        {
            Console.WriteLine("Enter Title: ");
           string title = Console.ReadLine();
           return title;
        }



       public void handleUserInput(ProductController controller, ProductService srv)
        {
            int choice;
            do
            {
                displayMenu();
                Console.WriteLine("Enter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            int id, quantity;
                            string title, description, category;
                            double price;
                           Product p= getProductDetails();
                            controller.insert(p);
                            displayProductAdded();
                            break;
                        }
                    case 2:
                        {
                           int index= getProductIndex();
                            Product product = new Product(); // Create a temporary product object
                            
                           Product product1= getProductDetails();
                            product.setTitle(product1.getTitle());
                            product.setDescription(product1.getDescription());
                            product.setQuantity(product1.getQuantity());
                            product.setPrice(product1.getPice());
                            controller.update(product);
                            break;
                        }
                    case 3:
                        {
                            int index= getProductIndex();
                            controller.delete(index);
                            break;
                        }
                    case 4:
                        controller.getAll();
                        break;
                    case 5:
                        {
                            int productId;
                            double discount;
                            getDiscountDetails(out productId, out discount);
                            srv.applyDiscount(productId, discount);
                            break;
                        }
                    case 6:
                        {
                            int productId;
                            productId= getProductId();
                            srv.calculateTotalPrice(productId);
                            break;
                        }
                    case 7:
                        {
                            string title;
                            title= getProductTitle();
                            // controller.searchProductByTitle(title);
                            break;
                        }
                    case 8:
                       Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            } while (choice != 8);
        }

    }
}