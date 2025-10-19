using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDefine
{
    public int id;
    public int waveTimer;
    public List<WaveDefine> enemys;
}

public class WaveDefine
{
    public string enemyName;
    public int timeAxis;//刷新时间
    public int count;//生成数量
}
