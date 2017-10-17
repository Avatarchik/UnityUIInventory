using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {

    public int Defense { get; set; }
    public Armor(int id, string name, string detail, int price,
        int count, string picture, int level, ItemType type, int defense)
        : base(id,name,detail,price,picture,level,ItemType.Armor,count)
    {
        this.Defense = defense;
    }
}
