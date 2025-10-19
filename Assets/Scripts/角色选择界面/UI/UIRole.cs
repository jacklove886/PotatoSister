using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRole : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image background;
    public Image avatar;
    public Button button;
    private RoleDefine RoleDefine;
    public event System.Action<RoleDefine> RoleInformation;

    public void SetInformation(RoleDefine RoleDefine)
    {
        this.RoleDefine = RoleDefine;
        if(RoleDefine.unlock==1)
        avatar.sprite = Resources.Load<Sprite>(RoleDefine.avatar);
        else
        {
            avatar.sprite = Resources.Load<Sprite>("Image/UI/锁");
        }
        button.onClick.AddListener(OnClickButton);
    }

    //点击后进入游戏
    public void OnClickButton()
    {
        SelectHelper.SelectRole(this.RoleDefine);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(207 / 255f, 207 / 255f, 207 / 255f);
        RoleInformation?.Invoke(RoleDefine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(34 / 255f, 34 / 255f, 34 / 255f);
    }


}
