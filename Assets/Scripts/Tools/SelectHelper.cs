using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SelectHelper
{
    public static void SelectRole(RoleDefine role)
    {
        // ��¼ѡ���ɫ����Ϣ
        GameManager.Instance.role = role;

        // RoleSelectPanel���ر�
        RoleSelectPanel.Instance.canvasGroup.alpha = 0;
        RoleSelectPanel.Instance.canvasGroup.interactable = false;
        RoleSelectPanel.Instance.canvasGroup.blocksRaycasts = false;

        // ����RoleInformation
        GameObject go = GameObject.Instantiate(RoleSelectPanel.Instance.RoleInformation, WeaponSelectPanel.Instance.WeaponContent);
        go.transform.SetSiblingIndex(0);

        // WeaponSelectPanel��忪��
        WeaponSelectPanel.Instance.canvasGroup.alpha = 1;
        WeaponSelectPanel.Instance.canvasGroup.interactable = true;
        WeaponSelectPanel.Instance.canvasGroup.blocksRaycasts = true;
    }

    public static void SelectWeapon(WeaponDefine weapon)
    {
        // ��¼ѡ���ɫ����Ϣ
        GameManager.Instance.weapon.Add(weapon);

        // WeaponSelectPanel���ر�
        WeaponSelectPanel.Instance.canvasGroup.alpha = 0;
        WeaponSelectPanel.Instance.canvasGroup.interactable = false;
        WeaponSelectPanel.Instance.canvasGroup.blocksRaycasts = false;

        // ����RoleInformation��WeaponInformation
        GameObject goRole = GameObject.Instantiate(RoleSelectPanel.Instance.RoleInformation, DiffSelectPanel.Instance.DiffContent);
        goRole.transform.SetSiblingIndex(0);

        GameObject goWeapon = GameObject.Instantiate(WeaponSelectPanel.Instance.WeaponInformation, DiffSelectPanel.Instance.DiffContent);
        goWeapon.transform.SetSiblingIndex(1);

        // DiffSelectPanel��忪��
        DiffSelectPanel.Instance.canvasGroup.alpha = 1;
        DiffSelectPanel.Instance.canvasGroup.interactable = true;
        DiffSelectPanel.Instance.canvasGroup.blocksRaycasts = true;
    }

    public static void SelectDiff(DiffDefine diff)
    {
        //��¼�Ѷ���Ϣ
        GameManager.Instance.diff = diff;

        //������Ϸ����
        SceneManager.LoadScene(2);
    }
}
