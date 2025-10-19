using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CommonButtons : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private Image image;
    private TextMeshProUGUI text;
    private Color oriImage;
    private Color oriText;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        oriImage = image.color;
        oriText = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(255, 255, 255);
        text.color = new Color(0, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = oriImage;
        text.color = oriText;
    }
}
