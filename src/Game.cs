using System;
using System.Runtime.CompilerServices;

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
		Room deepwoods = new Room("you are in the deep woods, It dark here");
		Room cave = new Room("you found a cave hidden in the woods.");
		Room insidecave = new Room("you are inside the cave this is the monser his house");
		Room basement = new Room("you are in the basement, maybe we should go back but there could be something useful in here.");
		Room darkbasement = new Room("in the dark basement, it's dark in here but maybe there could be something here.");
		Room insidehouse = new Room("its a small house, you hope you find something useful in here.");
		Room insidelab = new Room("you are inside of the lab and you didnt find anything.");
		Room End = new Room("You have successfully escaped the creature and you are safe for now.");

		// Initialise room exits
		start.AddExit("east", house);
		start.AddExit("south", lab);
		start.AddExit("west", pool);
		start.AddExit("north", deepwoods);


		//basement
		basement.AddExit("up", house);

		//darkbasement
		darkbasement.AddExit("up", insidelab);
		darkbasement.AddExit("south", End);

		//house
		house.AddExit("west", start);
		house.AddExit("inside", insidehouse);

		//insidehouse
		insidehouse.AddExit("outside", house);
		insidehouse.AddExit("down", basement);

		//deepwoods
		deepwoods.AddExit("south", start);
		deepwoods.AddExit("north", cave);

		//cave
		cave.AddExit("south", start);
		cave.AddExit("inside", insidecave);

		//insidecave
		insidecave.AddExit("outside", deepwoods);

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

		Item stick = new Item(1, "stick");
		Item potion = new Item(2, "health potion");
		Item endkey = new Item(10, "end key");
		Item basementkey = new Item(10, "basement key");
		Item rock = new Item(3, "rock");
		Item bone = new Item(2, "bone");
		Item skull = new Item(5, "skull");
		// Add items to the rooms

		Random rng = new();

		int kans1 = rng.Next(4);
		int kans2 = rng.Next(4);
		int kans3 = rng.Next(4);
		int kans4 = rng.Next(4);
		int kans5 = rng.Next(4);
		int kans6 = rng.Next(4);
		int kans7 = rng.Next(4);
		int kans8 = rng.Next(4);
		int kans9 = rng.Next(4);
		int kans10 = rng.Next(4);


		// Console.WriteLine($"kans1: {kans1}");
		// Console.WriteLine($"kans2: {kans2}");
		// Console.WriteLine($"kans3: {kans3}");
		// Console.WriteLine($"kans4: {kans4}");
		// Console.WriteLine($"kans5: {kans5}");
		// Console.WriteLine($"kans6: {kans6}");
		// Console.WriteLine($"kans7: {kans7}");
		// Console.WriteLine($"kans8: {kans8}");
		// Console.WriteLine($"kans9: {kans9}");
		// Console.WriteLine($"kans10: {kans10}");


		if (kans1 == 1)
		{
			deepwoods.AddItem("potion", potion);
		}
		else if (kans2 == 1)
		{
			darkbasement.AddItem("potion", potion);
		}
		else if (kans3 == 1)
		{
			pool.AddItem("potion", potion);
		}
		else if (kans4 == 1)
		{
			house.AddItem("potion", potion);
		}
		else if (kans5 == 1)
		{
			insidelab.AddItem("potion", potion);
		}
		else if (kans6 == 1)
		{
			cave.AddItem("potion", potion);
		}
		else if (kans7 == 1)
		{
			insidehouse.AddItem("potion", potion);
		}
		else if (kans8 == 1)
		{
			start.AddItem("potion", potion);
		}
		else if (kans9 == 1)
		{
			basement.AddItem("potion", potion);
		}
		else if (kans10 == 1)
		{
			lab.AddItem("potion", potion);
		}

		start.AddItem("stick", stick);
		lab.AddItem("stick", stick);
		house.AddItem("stick", stick);

		start.AddItem("rock", rock);
		lab.AddItem("rock", rock);
		house.AddItem("rock", rock);

		basement.AddItem("endkey", endkey);

		insidecave.AddItem("bone", bone);
		insidecave.AddItem("skull", skull);
		insidecave.AddItem("basementkey", basementkey);

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
		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine();
		Console.WriteLine("Welcome to my text-adventure");
		Console.WriteLine();
		Console.WriteLine("This is a simple text-based adventure game.");
		Console.WriteLine("You are lost in the woods and you need to escape.");
		Console.WriteLine("You are hurt causing you to lose health points when moving.");
		Console.WriteLine("Your objective is to escape the creature that hurt you.");
		Console.WriteLine("You have 100 health points.");
		Console.WriteLine("to heal you have a chance to find a health potion in any room!!");
		Console.WriteLine();
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.ResetColor();
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
			case "use":
				Use(command);
				break;
		}

		return wantToQuit;
	}
	private void PrintHelp()
	{
		Console.WriteLine("You are lost, You are alone.");
		Console.WriteLine("You are wandering around in the forest.");
		Console.WriteLine();

		// let the parser print the commands
		parser.PrintValidCommands();
	}
	private void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			Console.WriteLine("Go where?");
			return;


		}

		string direction = command.SecondWord;

		
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		player.Damage(10); 
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
		if (player.Health == 30)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("You are low on health you should heal quickly.");
			Console.ResetColor();
		}

		if (player.Health <= 0)
		{
			// Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine("You bled out, game over.");
			Console.ResetColor();
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
			Console.WriteLine(player.CurrentRoom.GetLongDescription());
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Items in the room: " + string.Join(", ", items));
			Console.ResetColor();
		}
		else
		{
			Console.WriteLine("No items in the room.");
		}
	}
	private void Status()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Player's health: " + player.Health);
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("---------------------");
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine("Your inventory: " + string.Join(", ", player.backpack.ListItems()));
		Console.ResetColor();
	}


	// Methods
	private void Take(Command command)
	{
		if (!command.HasSecondWord())
		{
			Console.WriteLine("Take what?");
			return;
		}
		else
		{
			string itemName = command.SecondWord;
			player.TakeFromChest(itemName);
		}
	}

	private void Drop(Command command)
	{
		if (!command.HasSecondWord())
		{
			Console.WriteLine("Drop what?");
			return;
		}

		else
		{
			string itemName = command.SecondWord;
			player.DropToChest(itemName);
		}
	}
	private void Use(Command command)
	{
		string itemName = command.SecondWord;

		if (command.HasSecondWord())
		{
			player.Use(itemName);
		}
		else
		{
			Console.WriteLine("Use what?");
		}
	}
}