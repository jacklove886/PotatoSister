using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickEvent : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
