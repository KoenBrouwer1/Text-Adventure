
//test
class Player
{

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
        Inventory inventory = new Inventory(10);
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
    public bool IsAlive()
    {
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
//damage staat in de game file in rij 186 :)