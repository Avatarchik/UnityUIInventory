using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necklace : Item {

    public int SkillSpeed { get; set; }
    public int SkillRange { get; set; }

    public Necklace(int id, string name, string detail, int price,
        int count, string picture, int level, int skillSpeed = 0, int SkillRange = 0)
        : base(id,name,detail,price,picture,level,ItemType.Necklace,count)
    {
        this.Type = ItemType.Necklace;
        this.SkillSpeed = skillSpeed;
        this.SkillRange = SkillRange;
    }
}
