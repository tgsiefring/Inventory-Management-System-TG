using System.ComponentModel;

namespace InventoryManagementSystem.model
{
    public class Product
    {
        //Properties
        public BindingList<Part> AssociatedParts = new BindingList<Part>(); 
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }       
        public int Min { get; set; }
        public int Max { get; set; }

        //Constructors
        public Product() { }
        public Product(int productID, string name, int inStock, decimal price, int min, int max)
        {
            ProductID = productID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
        }

        //Methods
        public bool RemoveAssociatedPart(int partID) //This method is not currently used.
        {
            bool removed = false;
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {
                    AssociatedParts.Remove(part);
                    return removed = true;
                }


                else
                {
                    removed = false;
                }
            }
                return removed;
        }

        public void AddAssociatedPart(Part part) //This method is used.
        {
            AssociatedParts.Add(part);
        }

        public Part LookupAssociatedPart(int partID) //This method is not currently used.
        {

            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {

                    return part;

                }             
            }
            return new InHouse();
        }
    }
}
