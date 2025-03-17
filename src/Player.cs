
//test
class Player
{
    public Inventory backpack { get; set; }


    public string Use(string itemName)
    {
        return $"You used {itemName}.";
    }

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

        CurrentRoom = null;
        health = 100;
        backpack = new Inventory(25);

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
                Console.WriteLine($"You took {itemName} in your backpack.");
                return true;
            }
            else
            {
                CurrentRoom.Chest.Put(itemName, item);
                return false;
            }
        }
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
}