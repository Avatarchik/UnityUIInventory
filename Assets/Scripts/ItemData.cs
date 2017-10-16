using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{

    static Dictionary<Transform, Item> itemDictionary = new Dictionary<Transform, Item>();

    public static void SaveData(Transform id,Item item)
    {
        if (itemDictionary.ContainsKey(id))
            item.Count++;
        else
            itemDictionary.Add(id, item);
    }

    public static Item GetItem(Transform id)
    {
        if (itemDictionary.ContainsKey(id))
            return itemDictionary[id];
        else
            return null;
    }

    public static void DeleteItem(Transform id)
    {
        if (itemDictionary.ContainsKey(id))
        {
            itemDictionary.Remove(id);
        }
    }
}
