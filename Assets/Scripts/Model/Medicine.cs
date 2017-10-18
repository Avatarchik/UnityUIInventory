using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Item {

	public int Hp { get; set; }
    public int Mp { get; set; }
    public Medicine(int id, string name, string detail, int price,
        int count, string picture, int level, int hp = 0,int mp = 0)
        : base(id,name,detail,price,picture,level,ItemType.Medicine,count)
    {
        this.Type = ItemType.Medicine;
        this.Hp = hp;
        this.Mp = mp;
    }
}
