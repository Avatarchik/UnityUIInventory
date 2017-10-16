using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : Item {

	int DefendWeak { get; set; }
    int DefendPoison { get; set; }
    public Ring(int id, string name, string detail, int price,
        int count, string picture, int level, int weak = 0, int poison = 0)
        : base(id,name,detail,price,count,picture,level,ItemType.Ring)
    {
        this.Type = ItemType.Ring;
        this.DefendWeak = weak;
        this.DefendPoison = poison;
    }
}
