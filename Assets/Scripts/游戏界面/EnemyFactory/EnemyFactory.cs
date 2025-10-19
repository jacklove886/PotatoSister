using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal1,
    Normal2,
    Charge,
    Remote,
    Boss
}

public class EnemyFactory : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPrefabPair
    {
        public EnemyType type;
        public GameObject prefab;
    }

    private static EnemyFactory instance;
    public static EnemyFactory Instance => instance;
    public Transform item_Parent;//道具的父物体
    public Transform enemy_Parent;//怪物父物体
    public Transform Map;
    public float spawnTime;
    public static string enemyPrefab="Prefabs/Enemy/";
    public GameObject Redfork;//红叉
    public Dictionary<string, EnemyDefine> EnemyDefine = new Dictionary<string, EnemyDefine>();

    private void Awake()
    {
        instance = this;
        LoadEnemyDefine();
    }

    private void LoadEnemyDefine()
    {
        TextAsset enemyAsset = Resources.Load<TextAsset>("Data/enemy");
        List<EnemyDefine> enemyList = JsonConvert.DeserializeObject<List<EnemyDefine>>(enemyAsset.text);
        foreach (var enemy in enemyList)
        {
            EnemyDefine[enemy.name] = enemy;
        }
    }
    public void CreateEnemies(LevelDefine currentLevelDefine)
    {
        foreach(WaveDefine waveDefine in currentLevelDefine.enemys)
        {
            StartCoroutine(SpawnEnemies(waveDefine));
        }
    }

    public IEnumerator SpawnEnemies(WaveDefine waveDefine)
    {
        yield return new WaitForSeconds(waveDefine.timeAxis);
        for (int i=0;i<waveDefine.count;i++)
        {
            yield return new WaitForSeconds(spawnTime);
            var spawnPoint = GetRandomSpawnPosition(Map.GetComponent<SpriteRenderer>().bounds);

            GameObject redfork=Instantiate(Redfork, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Destroy(redfork);

            //生成真正的敌人
            GameObject prefab = Resources.Load<GameObject>(enemyPrefab+waveDefine.enemyName);
            EnemyBase go = Instantiate(prefab, spawnPoint, Quaternion.identity, enemy_Parent).GetComponent<EnemyBase>();
            go.Items = item_Parent;

            EnemyDefine define = GetEnemyDefine(waveDefine.enemyName);
            go.Init(define);

            yield return new WaitForSeconds(0.1f);
        }
        
        
    }

    private Vector3 GetRandomSpawnPosition(Bounds bounds)
    {
        float safeDistance = 4f;

        float randomX = UnityEngine.Random.Range(bounds.min.x+ safeDistance, bounds.max.x- safeDistance);
        float randomY = UnityEngine.Random.Range(bounds.min.y+ safeDistance, bounds.max.y- safeDistance);
        float randomZ = 0;
        return new Vector3(randomX, randomY, randomZ);
    }

    public EnemyDefine GetEnemyDefine(string enemyName)
    {
        if (EnemyDefine.ContainsKey(enemyName))
        {
            return EnemyDefine[enemyName];
        }

        return null;
    }

}
