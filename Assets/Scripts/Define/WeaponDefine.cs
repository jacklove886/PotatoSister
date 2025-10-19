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
    public string grade;//�ȼ�
    public string price;
    public float damage;
    public int isLong;//��սԶ��
    public int range;//��Χ
    public float critical_strikes_multiple;//��������
    public float critical_strikes_probability;//��������
    public float cooling;//��ȴʱ��
    public int repel;//���˾���
    public string describe;
}
