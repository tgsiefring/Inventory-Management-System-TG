using InventoryManagementSystem.model;
using System.ComponentModel;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        //Properties
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> AllParts = new BindingList<Part>();

        public static int SelectedIndex { get; set; }
        public static Part SelectedPart { get; set; }
        public static Product SelectedProduct { get; set; }

        //Methods

        //returns product based on ProductID.
        public static Product LookupProduct(int prodID) //This method is used.
        {
            foreach (Product product in Products)
            {
                if (product.ProductID == prodID)
                {
                    return product;
                }
            }
            return new Product();
        }

        //Returns part based on PartID
        public static Part LookupPart(int partID) //This method is not currently used.
        {
            foreach (Part part in AllParts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }
            return new InHouse();
        }

        //Updates data for a product by deleting the product and inserting a new product in it's place with the modified data.
        public static void UpdateProduct(int index, Product newProduct) //This method is used.
        {
            Inventory.Products.Remove(Inventory.SelectedProduct);
            Inventory.Products.Insert(Inventory.SelectedIndex, newProduct);
        }

        //Updates data for a part by deleting the part and inserting a new part in it's place with the modified data.
        //Updating in this way enables the user to change a part from Inhouse to Outsourced or vice versa
        public static void UpdatePart(int index, Part newPart) //This method is used.
        {
            Inventory.AllParts.Remove(Inventory.SelectedPart);
            Inventory.AllParts.Insert(Inventory.SelectedIndex, newPart);            
        }

     
        //Adds a product to Products BindingList.
        public static void AddProduct(Product product) //This method is used.
        {
            Products.Add(product);
        }

        //Removes a product from Products BindingList based on ProductID.
        public static bool RemoveProduct(int productID) //This method is used.
        {
            bool removed = false;
            foreach (Product product in Products)
            {
                if (product.ProductID == productID)
                {
                    Products.Remove(product);
                    return removed = true;
                }


                else
                {
                    removed = false;
                }
            }
            return removed;

        }

        //Adds a part to AllParts BindingList.
        public static void AddPart(Part part) //This method is used.
        {
            AllParts.Add(part);
        }

        //Removes a part from AllParts BindingList.
        public static bool DeletePart(Part part) //This method is used.
        {
            if (part == null)
            {
                return false;
            }
            else
            {
                AllParts.Remove(part);
                return true;
            }
        }

        //Generates a new part ID for a part when adding a part.
        public static int GeneratePartID() //This method is used.
        {
            int pregenID = 0;
            foreach (Part part in AllParts)
            {
                if (part.PartID > pregenID)
                    pregenID = part.PartID;
            }
            return pregenID + 1;
        }

        //Generates a new product ID for a product when adding a product.
        public static int GenerateProductID() //This method is used.
        {
            int pregenID = 0;
            foreach (Product product in Products)
            {
                if (product.ProductID > pregenID)
                    pregenID = product.ProductID;
            }
            return pregenID + 1;
        }

        //Populates data grids of main form with test parts and products.
        //Populates each test product with one associated part.
        public static void TestObjects() //This method is used.
        {
            Product car = new Product(1, "Malibu", 10, 5000.00m, 0, 20);
            Product truck = new Product(2, "Silverado", 25, 7000.00m, 0, 30);
            Product suv = new Product(3, "Trailblazer", 8, 6000.00m, 0, 10);
            Product motorcycle = new Product(4, "Harley", 3, 3000.00m, 0, 5);

            AddProduct(car);
            AddProduct(truck);
            AddProduct(suv);
            AddProduct(motorcycle);

            Part inHouseTire = new InHouse(1, "Inhouse Tire", 40, 25.00m, 0, 100, 507);
            Part inHouseFrame = new InHouse(2, "Inhouse Frame", 70, 800.00m, 0, 100, 623);
            Part inHouseRim = new InHouse(3, "Inhouse Rim", 40, 100.00m, 0, 100, 485);
            Part outSourcedTire = new OutSourced(4, "Outsourced Tire", 80, 30.00m, 0, 100, "Ford");
            Part outSourcedFrame = new OutSourced(5, "Outsourced Frame", 78, 1000.00m, 0, 100, "Chrysler");
            Part outSourcedRim = new OutSourced(6, "Outsourced Rim", 80, 120.00m, 0, 100, "GM");

            AddPart(inHouseTire);
            AddPart(inHouseFrame);
            AddPart(inHouseRim);
            AddPart(outSourcedTire);
            AddPart(outSourcedFrame);
            AddPart(outSourcedRim);

            car.AddAssociatedPart(inHouseTire);
            truck.AddAssociatedPart(outSourcedTire);
            suv.AddAssociatedPart(inHouseFrame);
            motorcycle.AddAssociatedPart(outSourcedRim);
        }
    }
}
