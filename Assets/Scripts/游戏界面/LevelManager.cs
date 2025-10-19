using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    public float waveTimer;//��ǰ����

    //���йؿ�������
    public Dictionary<int, List<LevelDefine>> allLevels = new Dictionary<int, List<LevelDefine>>();

    //��ǰ�ؿ�������
    public List<LevelDefine> currentLevelWaves = new List<LevelDefine>();

    //��ǰ���ε�����
    public LevelDefine currentLevelDefine;

    private void Awake()
    {
        instance = this;
        LoadAllLevel();
    }

    private void LoadAllLevel()
    {
        for(int i = 0; i <= 5; i++)
        {
            TextAsset levelAsset = Resources.Load<TextAsset>("Data/level" + i);
            List<LevelDefine> waves = JsonConvert.DeserializeObject<List<LevelDefine>>(levelAsset.text);
            allLevels[i] = waves;
        }
    }

    private void Start()
    {
        LoadData();
        EnemyFactory.Instance.CreateEnemies(currentLevelDefine);
    }

    public void LoadData()
    {
        int currentWave = GameManager.Instance.currentWave;
        currentLevelWaves = allLevels[0];
        currentLevelDefine = currentLevelWaves[currentWave-1];
        waveTimer = currentLevelDefine.waveTimer;//��ǰ���ε�ʱ��
    }

    private void Update()
    {
        if(waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
            GamePanel.Instance.UpdateWave((int)waveTimer);
            if (waveTimer <= 0)
            {
                if (isWin())
                {
                    GamePanel.Instance.SuccessGame();
                    return;
                }
                waveTimer = 0;
                GameManager.Instance.currentWave++;
                waveTimer = 10 + 5 * GameManager.Instance.currentWave;
            }
        }
        
    }

    public bool isWin()
    {
        if (GameManager.Instance.currentWave== 2)
        {
            return true;
        }
        return false;
    }
}
