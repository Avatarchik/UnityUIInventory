public class Item
{
    int Id { get; set; }
    string Name { get; set; }
    string Detail { get; set; }
    int Price { get; set; }
    string Picture { get; set; }

    int Count { get; set; }

    int Level { get; set; }

    int ItemType { get; set; }
}

public enum ItemType
{
    Weapon=0,
    Armor,
    Ring,
    Necklace,
    
}
