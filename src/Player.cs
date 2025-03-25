using System.Runtime.CompilerServices;

class Player
{
    public Inventory backpack { get; set; }
    public Inventory Inventory { get; private set; }

    // auto property
    public Room CurrentRoom { get; set; }

    private int health = 100;
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
        else
        {
            Console.WriteLine($"you don't have a {itemName} in your inventory");
        }
        return false;
    }
    public string Use(string itemName)
    {

        if (backpack.Get(itemName) == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You don't have a {itemName} in your inventory.");
            Console.ResetColor();
            return null;
        }
        switch (itemName)
        {

            case "skull":
                UseSkull(itemName);
                return itemName;

            case "rock":
                UseRock(itemName);
                return itemName;
            case "bone":
                UseBone(itemName);
                return itemName;
            case "potion":

                UsePotion(itemName);
                return itemName;

            case "endkey":
                UseEndKey(itemName);
                return itemName;

            case "basementkey":
                UseBasementKey(itemName);
                return itemName;

            case "stick":
                UseStick(itemName);
                return itemName;


        }

        return null;
    }

    private void UseSkull(string itemName)
    {
        Console.WriteLine("you looked at the skull and desided to put it back");
        CurrentRoom.Chest.Put(itemName, new Item(5, "skull"));

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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You have used the end key. Congratulations, you have won the game!");
        Console.ResetColor();
        Console.WriteLine("Press [Enter] to exit.");
        Console.ReadLine();
        Environment.Exit(0);

    }
    private void UseBasementKey(string itemName)
    {
        backpack.Get(itemName);
        Console.WriteLine("You used the basementkey");

    }
    private void UseRock(string itemName)
    {
        Console.WriteLine("you threw the rock on the floor");
        CurrentRoom.Chest.Put(itemName, new Item(2, "rock"));
    }
    private void UseBone(string itemName)
    {
        Console.WriteLine("you put it back");
        CurrentRoom.Chest.Put(itemName, new Item(2, "bone"));
    }
    private void UseStick(string itemName)
    {
        Console.WriteLine("It snapped :(");
        CurrentRoom.Chest.Put("SnappedStick", new Item(1, "SnappedStick"));
    }

}