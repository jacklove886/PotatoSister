using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SelectHelper
{
    public static void SelectRole(RoleDefine role)
    {
        // 记录选择角色的信息
        GameManager.Instance.role = role;

        // RoleSelectPanel面板关闭
        RoleSelectPanel.Instance.canvasGroup.alpha = 0;
        RoleSelectPanel.Instance.canvasGroup.interactable = false;
        RoleSelectPanel.Instance.canvasGroup.blocksRaycasts = false;

        // 复制RoleInformation
        GameObject go = GameObject.Instantiate(RoleSelectPanel.Instance.RoleInformation, WeaponSelectPanel.Instance.WeaponContent);
        go.transform.SetSiblingIndex(0);

        // WeaponSelectPanel面板开启
        WeaponSelectPanel.Instance.canvasGroup.alpha = 1;
        WeaponSelectPanel.Instance.canvasGroup.interactable = true;
        WeaponSelectPanel.Instance.canvasGroup.blocksRaycasts = true;
    }

    public static void SelectWeapon(WeaponDefine weapon)
    {
        // 记录选择角色的信息
        GameManager.Instance.weapon.Add(weapon);

        // WeaponSelectPanel面板关闭
        WeaponSelectPanel.Instance.canvasGroup.alpha = 0;
        WeaponSelectPanel.Instance.canvasGroup.interactable = false;
        WeaponSelectPanel.Instance.canvasGroup.blocksRaycasts = false;

        // 复制RoleInformation和WeaponInformation
        GameObject goRole = GameObject.Instantiate(RoleSelectPanel.Instance.RoleInformation, DiffSelectPanel.Instance.DiffContent);
        goRole.transform.SetSiblingIndex(0);

        GameObject goWeapon = GameObject.Instantiate(WeaponSelectPanel.Instance.WeaponInformation, DiffSelectPanel.Instance.DiffContent);
        goWeapon.transform.SetSiblingIndex(1);

        // DiffSelectPanel面板开启
        DiffSelectPanel.Instance.canvasGroup.alpha = 1;
        DiffSelectPanel.Instance.canvasGroup.interactable = true;
        DiffSelectPanel.Instance.canvasGroup.blocksRaycasts = true;
    }

    public static void SelectDiff(DiffDefine diff)
    {
        //记录难度信息
        GameManager.Instance.diff = diff;

        //进入游戏场景
        SceneManager.LoadScene(2);
    }
}
