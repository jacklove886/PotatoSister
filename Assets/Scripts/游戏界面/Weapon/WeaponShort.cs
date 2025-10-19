using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShort : WeaponBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.transform == enemy)
            {
                collision.GetComponent<EnemyBase>().Hurt(WeaponDefine.damage);
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
            
        }
    }
}
