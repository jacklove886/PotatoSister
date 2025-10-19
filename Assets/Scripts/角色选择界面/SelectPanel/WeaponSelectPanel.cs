using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WeaponSelectPanel : MonoBehaviour
{
    private static WeaponSelectPanel instance;
    public static WeaponSelectPanel Instance
    {
        get
        {
            return instance;
        }
    }
    public List<WeaponDefine> WeaponDefines = new List<WeaponDefine>();
    private TextAsset weaponTextAsset;

    public Transform WeaponContent;
    public Transform weaponList;
    public GameObject WeaponInformation;//Œ‰∆˜–≈œ¢√Ê∞Â
    public CanvasGroup canvasGroup;

    public GameObject UIWeapon;

    private WeaponInformation weaponInformation;

    private void Awake()
    {
        instance = this;
        weaponTextAsset = Resources.Load<TextAsset>("Data/weapon");
        WeaponDefines = JsonConvert.DeserializeObject<List<WeaponDefine>>(weaponTextAsset.text);
    }

    private void Start()
    {
        UIWeapon firstWeapon = null;
        foreach (var weapon in WeaponDefines)
        {
            UIWeapon uiWeapon=GameObject.Instantiate(UIWeapon, weaponList).GetComponent<UIWeapon>();
            uiWeapon.SetInformation(weapon);
            weaponInformation = WeaponContent.GetComponent<WeaponInformation>();
            uiWeapon.WeaponInformation += weaponInformation.UpDateWeaponInformation;
            if (firstWeapon == null) firstWeapon = uiWeapon;
        }
        weaponInformation.UpDateWeaponInformation(WeaponDefines[0]);
    }

    private void OnDestroy()
    {
        weaponInformation = null;
    }


}
