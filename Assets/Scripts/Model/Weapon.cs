using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    public int Damage { get; set; }

    public Weapon(int id, string name, string detail, int price,
        int count, string picture, int level,int damage)
        : base(id,name,detail,price,picture,level,ItemType.Weapon,count)
    {
        this.Type = ItemType.Weapon;
        this.Damage = damage;
    }
}
