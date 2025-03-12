using System;

class Game
{

	// Private fields
	private Parser parser;
	private Player player;
	// private Room currentRoom { get; set; }

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room start = new Room("you are deep into the woods.");
		Room house = new Room("you found a cabin in the woods.");
		Room pool = new Room("you found a abandoned swimming pool deep in the woods.");
		Room lab = new Room("you found mysterious lab in the woods.");
		Room park = new Room("you are in a park its dark but you feel like u have been here before.");
		Room basement = new Room("you are in the basement, maybe we should go back but there could be something useful in here.");
		Room fountain = new Room("you are by the fountain, maybe there is something here?");
		Room darkbasement = new Room("in the dark basement, it's dark in here but maybe there could be something here.");
		Room insidehouse = new Room("its a small house, you hope you find something useful in here.");
		Room insidelab = new Room("you are inside of the lab and you didnt find anything.");
		Room End = new Room("You have successfully escaped the creature and you are safe for now.");

		// Initialise room exits
		start.AddExit("east", house);
		start.AddExit("south", lab);
		start.AddExit("west", pool);
		start.AddExit("north", park);


		//basement
		basement.AddExit("up", house);
		// basement.AddExit("north", darkbasement);

		//darkbasement
		darkbasement.AddExit("up", insidelab);
		darkbasement.AddExit("south", End);

		//house
		house.AddExit("west", start);
		house.AddExit("inside", insidehouse);

		//insidehouse
		insidehouse.AddExit("outside", house);
		insidehouse.AddExit("down", basement);

		//park
		park.AddExit("south", start);
		park.AddExit("east", fountain);

		//fountain
		fountain.AddExit("west", park);

		//pool
		pool.AddExit("east", start);

		//lab
		lab.AddExit("north", start);
		lab.AddExit("inside", insidelab);

		//insidelab
		insidelab.AddExit("outside", lab);
		insidelab.AddExit("down", darkbasement);

		//End
		End.AddExit("back", start);


		// Create your Items here
		// ...

		Item sword = new Item(10, "A sturdy iron sword");
		Item shield = new Item(3, "A shield");
		Item potion = new Item(5, "A small health potion");

		// Add items to the rooms

		basement.AddItem("sword", sword);
		insidehouse.AddItem("shield", shield);
		fountain.AddItem("potion", potion);

		// The end
		// if (End == player.CurrentRoom)
		// {
		// 	Console.WriteLine("You have successfully escaped the creature and you are safe for now.");
		// 	Console.WriteLine("Press [Enter] to continue.");
		// 	Console.ReadLine();
		// 	Environment.Exit(0);
		// }




		// And add them to the Rooms
		// ...

		// insidehouse.new Item("sword", sword);
		// insidehouse.new Item("shield", shield);


		// Start game outside
		player.CurrentRoom = start;
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to my text-adventure");
		Console.WriteLine();
		Console.WriteLine("This is a simple text-based adventure game.");
		Console.WriteLine("You are lost in the woods and you need to escape.");
		Console.WriteLine("You are hurt causing you to lose health points when moving.");
		Console.WriteLine("Your objective is to escape the creature that hurt you.");
		Console.WriteLine("You have 100 health points.");
		Console.WriteLine();
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();

		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, ip;p;cffffffffffffcxffft returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if (command.IsUnknown())
		{


			return wantToQuit; // false
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "quit":
				wantToQuit = true;
				break;
			case "look":
				Look();
				break;
			case "status":
				Status();
				break;
			case "take":
				Take(command);
				break;
			case "drop":
				Drop(command);
				break;
				// case "use":
				// Use(command);
				// break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################

	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost, You are alone.");
		Console.WriteLine("You are wandering around in the forest.");
		Console.WriteLine();

		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;


		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		player.Damage(10); // player takes 10 damage when moving
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}

		if (player.Health >= 10)
		{
			player.CurrentRoom = nextRoom;
			Console.WriteLine(player.CurrentRoom.GetLongDescription());
		}

		if (player.Health <= 0)
		{
			// Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("You bled out, game over.");
			Console.WriteLine("If you wish to play again press [Enter] and type 'dotnet run' in the console.");
			Console.ReadLine();
			Environment.Exit(0);
		}


	}

	private void Look()
{
    List<string> items = player.CurrentRoom.Chest.ListItems();
    if (items.Count > 0)
    {
        Console.WriteLine("Items in the room: " + string.Join(", ", items));
    }
    else
    {
        Console.WriteLine("No items in the room.");
    }
}
	private void Status()
	{
		Console.WriteLine("Player's health: " + player.Health);

		Console.WriteLine("your inventory: " + player.Inventory);

	}


	// Methods
	private void Take(Command command)
	{
		
	}

	private void Drop(Command command)
	{
		// TODO: Implement logic for dropping an item
	}
}
