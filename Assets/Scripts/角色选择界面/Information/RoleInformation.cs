using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleInformation : MonoBehaviour
{
    public Image avator;//头像
    public TextMeshProUGUI roleName;//名字
    public TextMeshProUGUI describe;//描述
    public TextMeshProUGUI record;//记录

    public Sprite unlock;//上锁

    public void UpDateRoleInformation(RoleDefine role)
    {
        if (role.unlock==1)
        {
            avator.sprite = Resources.Load<Sprite>(role.avatar);
            roleName.text = role.name;
            describe.text = role.describe;
            record.text = role.record.ToString()+" 级";
        }
        else
        {
            avator.sprite = unlock;
            roleName.text = "???";
            describe.text = "解锁条件"+role.unlockConditions;
            record.text = "尚无记录";
        }
    }
}
