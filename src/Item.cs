class Item
{

	//fields
	static void Items()
    {
        List<Item> Inventory = new List<Item>();

        // Items aanmaken en toevoegen aan de lijst
        Inventory.Add(new Item(5, "A small health potion"));
        Inventory.Add(new Item(10, "A sturdy iron sword"));
        Inventory.Add(new Item(3, "A magic scroll"));

        // Inventaris tonen
        foreach (Item item in Inventory)
        {
            Console.WriteLine($"{item.Description} - Weight: {item.Weight}");
        }
    }
	public int Weight { get; }
	public string Description { get; }
	public Item(int weight, string description)
	{
		Weight = weight;
		Description = description;

	}
	class Chest
    {
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        public Item GetItem(string itemName)
        {
            if (items.ContainsKey(itemName))
            {
                Item item = items[itemName];
                items.Remove(itemName);
                return item;
            }
            return null;
        }

        public bool AddItem(string itemName, Item item)
        {
            if (!items.ContainsKey(itemName))
            {
                items[itemName] = item;
                return true;
            }
            return false;
        }
    }
    // Methods
    public string Use(string itemName)
    {
        // TODO: Implement logic for using an item
        return $"You used {itemName}.";
    }
}
