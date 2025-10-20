using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : EnemyBase
{
    float chargeTime=0;//≥Â∑Ê ±º‰ 0.6s

    protected override void LaunchSkill(Vector2 direction)
    {
        StartCoroutine(Charge(direction));
    }

    IEnumerator Charge(Vector2 direction)
    {
        if (chargeTime < 0.6f)
        {
            chargeTime += Time.deltaTime;
            transform.position += (Vector3)direction * define.speed * Time.deltaTime;
            yield return null;
        }
    }
}
