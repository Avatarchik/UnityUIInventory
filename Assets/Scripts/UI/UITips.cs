using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class UITips : MonoBehaviour {
    public static UITips instance = null;
    public Text backgroundText;
    public Text contentText;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    public void UpdateText(string text)
    {
        backgroundText.text = text;
        contentText.text = text;
    }

    public void ShowTips()
    {
        gameObject.SetActive(true);
    }

    public void HideTips()
    {
        gameObject.SetActive(false);
    }
    
    public string GetStringText(Item item)
    {
        if (item == null)
            return null;
        StringBuilder content = new StringBuilder();
        content.AppendFormat("<color=red>{0}</color>\n\n", item.Name);
        switch (item.Type)
        {
            case ItemType.Armor:
                Armor armor = item as Armor;
                content.AppendFormat("名称:{0}\n等级:{1}\n防御:{2}\n详情:{3}\n\n", 
                    armor.Name, armor.Level, armor.Defense,armor.Detail);
                break;
            case ItemType.Medicine:
                Medicine medicine = item as Medicine;
                content.AppendFormat("名称:{0}\n等级:{1}\nHp:{2}\nMp:{3}\n详情:{4}\n\n",
                    medicine.Name, medicine.Level, medicine.Hp, medicine.Mp, medicine.Detail);
                break;
            case ItemType.Necklace:
                Necklace necklace = item as Necklace;
                content.AppendFormat("名称:{0}\n等级:{1}\n攻击范围+:{2}\n攻击速度+:{3}\n详情:{4}\n\n",
                    necklace.Name, necklace.Level, necklace.SkillRange, necklace.SkillSpeed, necklace.Detail);
                break;
            case ItemType.Ring:
                Ring ring = item as Ring;
                content.AppendFormat("名称:{0}\n等级:{1}\n抗疲劳+:{2}\n抗毒+:{3}\n详情:{4}\n\n",
                    ring.Name, ring.Level, ring.DefendWeak, ring.DefendPoison, ring.Detail);
                break;
            case ItemType.Weapon:
                Weapon weapon = item as Weapon;
                content.AppendFormat("名称:{0}\n等级:{1}\n伤害+:{2}\n抗毒+:{3}\n详情:{4}\n\n",
                    weapon.Name, weapon.Level, weapon.Damage, weapon.Detail);
                break;
            default:
                break;
        }
        //content.AppendFormat("<size=25><color=white>购买价格：{0}\n出售价格：{1}</color></size>\n\n<color=yellow><size=20>描述：{2}</size></color>", item.BuyPrice, item.SellPrice, item.Description);
        return content.ToString();
    }
}
