using System.Runtime.CompilerServices;

class Inventory
{
    // Fields
    private int maxWeight;
    private Dictionary<string, Item> items;

    // Constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

    // Methods
    public bool Put(string itemName, Item item)
    {
        // TODO implement:
        // Check the weight of the item and check for enough space in the inventory
        // Does the item fit?
        // Put item in the items dictionary
        // Return true/false for success/failure
        return false;
    }

    public Item Get(string itemName)
    {
        // TODO implement:
        // Find item in items dictionary
        // Remove item from items dictionary if found
        // Return item or null
        return null;
    }
    // Velden
    // private int maxWeight;
    // private Dictionary<string, Item> items;

    // Constructor
//     public Inventory(int maxWeight)
//     {
//         this.maxWeight = maxWeight;
//         this.items = new Dictionary<string, Item>();
//     }
//     //code moet hier ingevoegd worden :)
    
}


