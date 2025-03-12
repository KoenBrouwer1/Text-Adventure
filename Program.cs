class Program
{
	public static void Main(string[] args){
	
		// Create and play the Game.
		Game game = new Game();
		game.Play();
		// Create an inventory with a maximum weight of 100
        Inventory inventory = new Inventory(100);

        // Create items
        Item sword = new Item("Sword", 10);
        Item shield = new Item("Shield", 15);
        Item potion = new Item("Potion", 5);

        // Add items to the inventory
        inventory.Put("Sword", sword);
        inventory.Put("Shield", shield);
        inventory.Put("Potion", potion);

        // Display the status of the inventory
        // inventory.Status();
    }
}

