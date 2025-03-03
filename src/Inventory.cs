class Inventory
{
    // fields
    private int maxWeight; private Dictionary<string, Item> items;
    // constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }
    // methods
    public bool Put(string itemName, Item item)
    {
        // TODO implement:
        // Check the Weight of the Item and check 
        //  for enough space in the Inventory
        //  Does the Item fit?
        //  Put Item in the items Dictionary
        //  Return true/false for success/failure
        return false;
    }
    public Item Get(string itemName)
    {
        // TODO implement:
        // Check if the Item is in the Inventory
        //  Remove the Item from the items Dictionary
        //  Return the Item
        //  Return null if the Item is not in the Inventory
        return null;
    }
}

// class Room
// {
//     // field
//     private Inventory chest;
//     //property
//     public Inventory //Chest
// {get { return chest; }}
// // constructor
// public Room()
// {
//     // a Room can handle a big Inventory.
//     chest = new Inventory(999999);
// }
// }