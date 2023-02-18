using InventoryManagementSystem.model;

namespace InventoryManagementSystem
{
    public class OutSourced : Part
    {
        //Properties
        public string CompanyName { get; set; }
        //OutSourced inherits properties from Part class as well.

        //Constructors
        public OutSourced()
        {

        }

        public OutSourced(int partID, string name, int inStock, decimal price, int min, int max)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
        }

        public OutSourced(int partID, string name, int inStock, decimal price, int min, int max, string compName)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
            CompanyName = compName;
        }        
    }
}
