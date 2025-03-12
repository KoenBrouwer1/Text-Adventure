using System.Collections.Generic;

class Room
{
    // Private fields
    private string description;
    private Dictionary<string, Room> exits; // stores exits of this room.
    private readonly Inventory chest;

    // Property
    public Inventory Chest => chest;

    // Constructor
    public Room(string desc)
    {
        description = desc;
        exits = new Dictionary<string, Room>();
        chest = new Inventory(999999); // Initialize the chest with a large max weight
    }

    // Define an exit for this room.
    public void AddExit(string direction, Room neighbor)
    {
        exits.Add(direction, neighbor);
    }

    // Return the description of the room.
    public string GetShortDescription()
    {
        return description;
    }

    // Return a long description of this room, in the form:
    //     You are in the kitchen.
    //     Exits: north, west
    public string GetLongDescription()
    {
        string str = ""; //zet hier discription in van de kamers
        str += description;
        str += "\n"; //voor de punt enzo
        str += GetExitString();
        return str;
    }

    // Return the room that is reached if we go from this room in direction
    // "direction". If there is no room in that direction, return null.
    public Room GetExit(string direction)
    {
        if (exits.ContainsKey(direction))
        {
            return exits[direction];
        }
        return null;
    }

    // Return a string describing the room's exits, for example
    // "Exits: north, west".
    private string GetExitString()
    {
        string str = "Exits: ";
        str += String.Join(", ", exits.Keys);
        return str;
    }

    // Method to add an item to the room's inventory
    public void AddItem(string itemName, Item item)
    {
        chest.Put(itemName, item);
    }

    // Method to remove an item from the room's inventory
    public Item RemoveItem(string itemName)
    {
        return chest.Get(itemName);
    }
}