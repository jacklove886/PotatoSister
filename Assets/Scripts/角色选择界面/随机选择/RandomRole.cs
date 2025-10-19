using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RandomRole : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image background;
    public Button button;
    public RoleInformation RoleInformation;
    private RoleDefine role;

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
        while (true)
        {
            int roleIndex = Random.Range(0, RoleSelectPanel.Instance.RoleDefines.Count);
            role = RoleSelectPanel.Instance.RoleDefines[roleIndex];
            if (role.unlock != 0)
            {
                RoleInformation.UpDateRoleInformation(role);
                SelectHelper.SelectRole(role);
                break;
            }
        }
        
    }
}
