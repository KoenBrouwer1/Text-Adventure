class Player
{
    // auto property
    public Room CurrentRoom { get; set; }
    public int health;

    // constructor
    public Player()
    {

        CurrentRoom = null;
        health = 100;
    }

  // methods
    public int Damage(int amount ) {
        health -= amount;
        return health;
    } 
    // player loses some health
    public int Heal( int amount) {
        health += amount;
        return health;
    } 
    // player's health restores
    public bool IsAlive() { 
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    } 
    // checks whether the player is alive or not}
}
