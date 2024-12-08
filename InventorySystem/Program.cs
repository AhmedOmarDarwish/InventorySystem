namespace InventorySystem
{
    internal class Program
    {
        static string[,] inventory = new string[50, 3];
        static int productCount = 0;
        static void Main(string[] args)
        {
            //Add Product
            //Update Product
            //View Product(ID, Name, Quantity, Price)
            //Exit
            while (true)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Welcome To The Inventory System, Enter your Choice");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                string userInput = Console.ReadLine();
                int choiceUser = int.Parse(userInput);
                switch (choiceUser)
                {
                    case 1:
                        //Add Product
                        AddProduct();
                        break;
                    case 2:
                        //View Product
                        ViewProducts();
                        break;
                    case 3:
                        //Update Product
                        UpdateProduct();
                        break;
                    case 4:
                        //Delete Product
                        DeleteProduct();
                        break;
                    case 5:
                        //Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Enter Right Number");
                        break;
                }
            }
        }
        private static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            string productQuantity = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            string productPrice = Console.ReadLine();
            inventory[productCount,0] = productName;
            inventory[productCount,1] = productQuantity;
            inventory[productCount,2] = productPrice;
            productCount++;
            Console.WriteLine("Product Added Successfully");

        }
        private static void ViewProducts()
        {
            if (productCount > 0)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Product List");
                Console.WriteLine("-------------");

                for (int p = 0; p < productCount; p++)
                {
                    Console.WriteLine($"Product ID: {p+1},\n\t" +
                        $"Product Name: {inventory[p, 0]}, Product Quantity: {inventory[p, 1]}, Product Price: {inventory[p, 2]}");

                }
            } else
            {
                Console.WriteLine("Inventory Is Empty!, Please Add Products :)");

            }
        }
        private static void UpdateProduct()
        {
           
            if (productCount > 0)
            {
                Console.Write("Enter Product Name To Update: ");
                string searchProduct = Console.ReadLine();
                int productID = -1;
                for (int p = 0; p < productCount; p++)
                {
                    if (inventory[p, 0].ToLower() == searchProduct.Trim().ToLower())
                    {
                        productID = p;
                        break;
                    }
                }
                if (productID != -1) {
                    Console.WriteLine("Do You Need to change Product Name Y or N: ");
                    if (Console.ReadLine().Trim().ToLower() == "y")
                    {
                        Console.Write("Enter Product New Name:");
                        inventory[productID, 0] = Console.ReadLine();
                        Console.WriteLine("Product Renamed Successfully");
                    }
                    Console.WriteLine("Do You Need to change Product Quantity Y or N: ");
                    if (Console.ReadLine().Trim().ToLower() == "y")
                    {
                        Console.Write("Enter Product New Quantity:");
                        inventory[productID, 1] = Console.ReadLine();
                        Console.WriteLine("Product Updated Successfully");
                    }
                    Console.WriteLine("Do You Need to change Product Price Y or N: ");
                    if (Console.ReadLine().Trim().ToLower() == "y")
                    {
                        Console.Write("Enter Product New Price:");
                        inventory[productID, 2] = Console.ReadLine();
                        Console.WriteLine("Product Updated Successfully");
                    }


                } else
                {
                    Console.WriteLine("Product Not Found :(");
                    UpdateProduct();
                }
            }
            else {
                Console.WriteLine("Inventory Is Empty!, Please Add Products :)");
            }
        }
        private static void DeleteProduct()
        {
            if (productCount > 0)
            {
                Console.Write("Enter Product Name To Delete: ");
                string searchProduct = Console.ReadLine();
                int productID = -1;
                for (int p = 0; p < productCount; p++)
                {
                    if (inventory[p, 0].ToLower() == searchProduct.Trim().ToLower())
                    {
                        productID = p;
                        break;
                    }
                }
                if (productID != -1)
                {
                    for (int p = productID; p < productCount; p++)
                    {
                        inventory[p, 0] = inventory[p + 1, 0];
                        inventory[p, 1] = inventory[p + 1, 1];
                        inventory[p, 2] = inventory[p + 1, 2];
                        Console.WriteLine("Product Delete Successfully");
                    }
                    productCount = productCount > 0 ? --productCount: 0;
                    ViewProducts();



                }
                else
                {
                    Console.WriteLine("Product Not Found :(");
                    DeleteProduct();
                }
            }
            else
            {
                Console.WriteLine("Inventory Is Empty!, Please Add Products :)");
            }
        }

    }

}
