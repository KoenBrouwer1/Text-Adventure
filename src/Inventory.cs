// class Inventory
// {
//     // fields
//     private int maxWeight; private Dictionary<string, Item> items;
//     // constructor
//     public Inventory(int maxWeight)
//     {
//         this.maxWeight = maxWeight;
//         this.items = new Dictionary<string, Item>();
//     }
//     // methods
//     public bool Put(string itemName, Item item)
//     {
//         // TODO implement:
//         // Check the Weight of the Item and check 
//         //  for enough space in the Inventory
//         //  Does the Item fit?
//         //  Put Item in the items Dictionary
//         //  Return true/false for success/failure
//         return false;
//     }
//     public Item Get(string itemName)
//     {
//         // TODO implement:
//         // Check if the Item is in the Inventory
//         //  Remove the Item from the items Dictionary
//         //  Return the Item
//         //  Return null if the Item is not in the Inventory
//         return null;
//     }
// }

public class Inventory
{
    // Velden
    private int maxWeight;
    private Dictionary<string, Item> items;

    // Constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }
}
    // Methode om een item toe te voegen
//     public bool Put(string itemName, Item item)
//     {
//         // Controleer of het item in de inventory past
//         if (item.Weight + TotalWeight() > maxWeight)
//         {
//             return false; // Niet genoeg ruimte
//         }

//         // Voeg item toe aan de dictionary
//         items[itemName] = item;
//         return true;
//     }

//     // Methode om een item eruit te halen
//     public Item Get(string ItemName)
//     {
//         if (items.TryGetValue(ItemName, out Item item))
//         {
//             items.Remove(ItemName);
//             return item;
//         }
//         return null; // Item niet gevonden
//     }

//     // Bereken het totale gewicht van alle items in de inventory
//     public int TotalWeight()
//     {
//         int total = 0;
//         foreach (var item in items.Values)
//         {
//             total += item.Weight;
//         }
//         return total;
//     }

//     // Bereken hoeveel ruimte er nog over is
//     public int FreeWeight()
//     {
//         return maxWeight - TotalWeight();
//     }
// }
