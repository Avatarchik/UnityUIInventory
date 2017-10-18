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

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }

    public string GetStringText(Item item)
    {
        if (item == null)
            return null;
        StringBuilder content = new StringBuilder();
        content.AppendFormat("<size=25><b>{0}</b></size>\n\n", item.Name);
        content.AppendFormat("等级：{0}\n", item.Level);
        switch (item.Type)
        {
            case ItemType.Armor:
                Armor armor = item as Armor;
                content.AppendFormat("防御：{0}\n",armor.Defense);
                break;
            case ItemType.Medicine:
                Medicine medicine = item as Medicine;
                content.AppendFormat("Hp:{0}\nMp:{1}\n",medicine.Hp, medicine.Mp);
                break;
            case ItemType.Necklace:
                Necklace necklace = item as Necklace;
                content.AppendFormat("攻击范围+:{0}\n攻击速度+:{1}\n",necklace.SkillRange,necklace.SkillSpeed);
                break;
            case ItemType.Ring:
                Ring ring = item as Ring;
                content.AppendFormat("抗疲劳+:{0}\n抗毒+:{1}\n", ring.DefendWeak, ring.DefendPoison);
                break;
            case ItemType.Weapon:
                Weapon weapon = item as Weapon;
                content.AppendFormat("攻击+：{0}\n",weapon.Damage);
                break;
            default:
                break;
        }
        content.AppendFormat("购买价格：{0}\n\n详情：{1}\n", item.Price, item.Detail);
        return content.ToString();
    }
}
