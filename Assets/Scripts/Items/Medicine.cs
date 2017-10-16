using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Item {

	int Hp { get; set; }
    int Mp { get; set; }
    public Medicine(int id, string name, string detail, int price,
        int count, string picture, int level, ItemType type, int hp=0,int mp=0)
        : base(id,name,detail,price,count,picture,level,ItemType.Weapon)
    {
        this.Hp = hp;
        this.Mp = mp;
    }
}
