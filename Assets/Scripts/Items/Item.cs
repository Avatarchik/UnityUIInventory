public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public int Price { get; set; }
    public string Picture { get; set; }

    public int Count { get; set; }

    public int Level { get; set; }

    public ItemType Type { get; set; }

    public Item(int id, string name, string detail, int price, 
         string picture,int level,ItemType type,int count=1)
    {
        this.Id = id;
        this.Name = name;
        this.Detail = detail;
        this.Price = price;
        this.Count = count;
        this.Picture = picture;
        this.Level = level;
        this.Type = type;
    }
}

public enum ItemType
{
    Weapon=0,
    Armor,
    Ring,
    Necklace,
    Medicine,
}
