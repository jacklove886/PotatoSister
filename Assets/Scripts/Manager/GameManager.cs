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
    public int currentWave=1;//��ǰ����
    public int currentLevel;//��ǰ�ؿ�
    public GameObject EnemyBullet;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    
}
