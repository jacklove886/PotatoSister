using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase
{
    protected override void LaunchSkill(Vector2 direction)
    {
        GameObject bullet = Instantiate(GameManager.Instance.EnemyBullet, this.transform);
        bullet.GetComponent<EnemyBullet>().dir = direction;
    }
}
