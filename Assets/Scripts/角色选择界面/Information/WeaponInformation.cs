using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInformation : MonoBehaviour
{
    public Image avator;//ͷ��
    public TextMeshProUGUI weaponName;//����
    public TextMeshProUGUI weaponClass;//����
    public TextMeshProUGUI describe;//����

    public void UpDateWeaponInformation(WeaponDefine weapon)
    {
        avator.sprite = Resources.Load<Sprite>(weapon.avatar);
        weaponName.text = weapon.name;
        describe.text = weapon.describe;
        weaponClass.text = weapon.isLong==0?"��ս": "Զ��";
    }
}
