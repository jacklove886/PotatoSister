using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image background;
    public Image avator;
    public Button button;
    public WeaponDefine WeaponDefine;
    public event System.Action<WeaponDefine> WeaponInformation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(207 / 255f, 207 / 255f, 207 / 255f);
        WeaponInformation?.Invoke(WeaponDefine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(34 / 255f, 34 / 255f, 34 / 255f);
    }

    public void SetInformation(WeaponDefine weapon)
    {
        WeaponDefine = weapon;
        avator.sprite = Resources.Load<Sprite>(weapon.avatar);
        button.onClick.AddListener(OnClickButton);
    }

    public void OnClickButton()
    {
        SelectHelper.SelectWeapon(this.WeaponDefine);
    }
}
