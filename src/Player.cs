
//test
using System.Runtime.CompilerServices;

class Player
{
    public Inventory backpack { get; set; }




    // auto property
    public Room CurrentRoom { get; set; }
    private int health = 100;

    public Inventory Inventory { get; private set; }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }


    // constructor
    public Player()
    {
        health = 100;
        CurrentRoom = null;
        backpack = new Inventory(15);

    }

    // methods
    public int Damage(int amount)
    {
        health -= amount;
        return health;
    }
    // player loses some health
    public int Heal(int amount)
    {
        health += amount;
        if (health > 100)
        {
            health = 100;
        }
        return health;
    }
    // player's health restores
    public bool TakeFromChest(string itemName)
    {
        Item item = CurrentRoom.Chest.Get(itemName);
        if (item != null)
        {
            if (backpack.Put(itemName, item))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Added {itemName} to your inventory.");
                Console.ResetColor();
                return true;

            }
            else
            {
                CurrentRoom.Chest.Put(itemName, item);
                Console.WriteLine("You can't carry that much.");
                return false;
            }
        }
        if (item == null)
            Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("there is no " + itemName + " in this room");
        Console.ResetColor();

        return false;
    }

    public bool DropToChest(string itemName)
    {
        Item item = backpack.Get(itemName);
        if (item != null)
        {
            if (CurrentRoom.Chest.Put(itemName, item))
            {
                Console.WriteLine($"You dropped {itemName} in the room.");
                return true;
            }
            else
            {
                backpack.Put(itemName, item);
                return false;
            }
        }
        return false;
    }
    public string Use(string itemName)
    {


        switch (itemName)
        {
            case "sword":
                UseSword();
                return itemName;

            case "potion":
                if (backpack.Get(itemName) == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You don't have a {itemName} in your inventory.");
                    Console.ResetColor();
                    return null;
                }
                UsePotion(itemName);
                return itemName;

            case "endkey":
                if (backpack.Get(itemName) == null)
                {     if (backpack.Get(itemName) == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You don't have a {itemName} in your inventory.");
            Console.ResetColor();
            return null;
        }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You don't have a {itemName} in your inventory.");
                    Console.ResetColor();
                    return null;
                }
                UseEndKey(itemName);
                return itemName;

            case "basementkey":
                if (backpack.Get(itemName) == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You don't have a {itemName} in your inventory.");
                    Console.ResetColor();
                    return null;
                }
                UseBasementKey(itemName);
                return itemName;


        }

        return null;
    }

    private void UseSword()
    {
        Console.WriteLine("very good very nice :)");

    }
    private void UsePotion(string itemName)
    {
        backpack.Get(itemName);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("You used a potion and got back 30 health");
        Console.ResetColor();
        Heal(30);

    }
    private void UseEndKey(string itemName)
    {
        backpack.Get(itemName);

        Console.WriteLine("very keye endkey :)");
    }
    private void UseBasementKey(string itemName)
    {
        backpack.Get(itemName);
        Console.WriteLine("very keye basement key:)");
    }
}