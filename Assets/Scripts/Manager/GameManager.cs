using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public RoleDefine role=null;
    public List<WeaponDefine> weapon=new List<WeaponDefine>();
    public DiffDefine diff = null;
    public int currentWave=1;//当前波次
    public int currentLevel;//当前关卡

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    
}
