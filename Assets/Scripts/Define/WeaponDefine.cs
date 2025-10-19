using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class WeaponDefine
{
    public int id;
    public string name;
    public string avatar;
    public string grade;//等级
    public string price;
    public float damage;
    public int isLong;//近战远程
    public int range;//范围
    public float critical_strikes_multiple;//暴击倍率
    public float critical_strikes_probability;//暴击概率
    public float cooling;//冷却时间
    public int repel;//击退距离
    public string describe;
}
