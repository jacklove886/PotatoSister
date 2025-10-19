using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleInformation : MonoBehaviour
{
    public Image avator;//ͷ��
    public TextMeshProUGUI roleName;//����
    public TextMeshProUGUI describe;//����
    public TextMeshProUGUI record;//��¼

    public Sprite unlock;//����

    public void UpDateRoleInformation(RoleDefine role)
    {
        if (role.unlock==1)
        {
            avator.sprite = Resources.Load<Sprite>(role.avatar);
            roleName.text = role.name;
            describe.text = role.describe;
            record.text = role.record.ToString()+" ��";
        }
        else
        {
            avator.sprite = unlock;
            roleName.text = "???";
            describe.text = "��������"+role.unlockConditions;
            record.text = "���޼�¼";
        }
    }
}
