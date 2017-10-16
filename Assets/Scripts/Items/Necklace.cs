using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necklace : Item {

    int SkillSpeed { get; set; }
    int SkillRange { get; set; }

    public Necklace(int id, string name, string detail, int price,
        int count, string picture, int level, ItemType type, int skillSpeed = 0, int SkillRange = 0)
        : base(id,name,detail,price,count,picture,level,ItemType.Weapon)
    {
        this.SkillSpeed = skillSpeed;
        this.SkillRange = SkillRange;
    }
}
