using System.Security.Cryptography.X509Certificates;

class Player
{
    // auto property
    public Room CurrentRoom { get; set; }
    public int health; //zet health nog op private later en fix die melding :)

    // public int Health
    // {
    //     get { return health; }
    //     set { health = value; }
    // }


    // constructor
    public Player()
    {

        CurrentRoom = null;
        health = 100;
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


