using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UIDiff : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public Image background;
    public Image avatar;
    public Button button;
    public DiffDefine diffDefine;
    public event System.Action<DiffDefine> DiffInformation;
    public void SetInformation(DiffDefine diff)
    {
        diffDefine = diff;
        avatar.sprite = Resources.Load<SpriteAtlas>("Image/UI/Œ£œ’µ»º∂").GetSprite(diff.name);
        button.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        SelectHelper.SelectDiff(diffDefine);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(207 / 255f, 207 / 255f, 207 / 255f);
        DiffInformation?.Invoke(diffDefine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(34 / 255f, 34 / 255f, 34 / 255f);
    }

}
