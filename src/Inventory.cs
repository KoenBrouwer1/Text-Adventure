using System;
using System.Collections.Generic;

class Inventory
{
    public int maxWeight
    {
        get;
        private set;
    }

    private Dictionary<string, Item> items;

    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

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

    // New method to list all items
    public List<string> ListItems()
    {
        return new List<string>(items.Keys);
    }

     public string Show()
    {
        string result = "";
        foreach (var itemName in ListItems())
        {
            result += itemName + " ";
        }
        return result;
    }
}