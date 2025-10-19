using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInformation : MonoBehaviour
{
    public Image avator;//头像
    public TextMeshProUGUI weaponName;//名字
    public TextMeshProUGUI weaponClass;//类型
    public TextMeshProUGUI describe;//描述

    public void UpDateWeaponInformation(WeaponDefine weapon)
    {
        avator.sprite = Resources.Load<Sprite>(weapon.avatar);
        weaponName.text = weapon.name;
        describe.text = weapon.describe;
        weaponClass.text = weapon.isLong==0?"近战": "远程";
    }
}
