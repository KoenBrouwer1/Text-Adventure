using System;

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
        // Check if the item fits in the inventory
        if (item.Weight + TotalWeight() > maxWeight)
        {
            return false; // Not enough space
        }

        // Add the item to the inventory
        items[itemName] = item;
        return true;
    }

    public Item Get(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            Item item = items[itemName];
            items.Remove(itemName);
            return item;
        }
        return null;
    }

    public int TotalWeight()
    {
        int total = 0;
        // TODO implement:
        // loop through the items, and add all the weights

        foreach (var item in items.Values)
        {
            total += item.Weight;
        }
        return total;
        
    }   

    public int FreeWeight()
    {
        return maxWeight - TotalWeight();
    }
}

// Example Item class

