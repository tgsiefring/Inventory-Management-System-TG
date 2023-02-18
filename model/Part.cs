namespace InventoryManagementSystem.model
{
    //Part is divided into classes InHouse and OutSourced.
    public abstract class Part
    {      
        //Properties
        public int PartID { get; set; }

        public string Name { get; set; }

        public int InStock { get; set; }

        public decimal Price { get; set; }       

        public int Min { get; set; }

        public int Max { get; set; }

        //Part constructors are not necessary due to abstraction and are not used
    }
}
