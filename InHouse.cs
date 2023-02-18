using InventoryManagementSystem.model;

namespace InventoryManagementSystem
{
    public class InHouse : Part
    {
        //Properties
        public int MachineID { get; set; }
        //InHouse inherits properties from Part class as well.

        //Constructors
        public InHouse()
        {
            
        }

        public InHouse(int partID, string name, int inStock, decimal price, int min, int max)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
        }
        public InHouse(int partID, string name, int inStock, decimal price, int min, int max, int machineID)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
            MachineID = machineID;
        }        
    }
}
