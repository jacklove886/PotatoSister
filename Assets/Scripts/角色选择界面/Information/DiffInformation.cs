using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DiffInformation : MonoBehaviour
{
    public Image avator;
    public TextMeshProUGUI diffName;
    public TextMeshProUGUI describe;

    public void UpDateDiffInformation(DiffDefine diff)
    {
        avator.sprite = Resources.Load<SpriteAtlas>("Image/UI/Œ£œ’µ»º∂").GetSprite(diff.name);
        diffName.text = diff.name;
        describe.text = diff.describe;
    }
}
