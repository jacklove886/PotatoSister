using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RandomWeapon : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image background;
    public Button button;
    public WeaponInformation WeaponInformation;
    private WeaponDefine weapon;

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(207 / 255f, 207 / 255f, 207 / 255f);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(34 / 255f, 34 / 255f, 34 / 255f);
    }

    public void OnClickButton()
    {
        int weaponIndex = Random.Range(0, WeaponSelectPanel.Instance.WeaponDefines.Count);
        weapon = WeaponSelectPanel.Instance.WeaponDefines[weaponIndex];
        WeaponInformation.UpDateWeaponInformation(weapon);
        SelectHelper.SelectWeapon(weapon);
    }
}
