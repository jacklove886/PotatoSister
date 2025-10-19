using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WeaponBase : MonoBehaviour
{
    public WeaponDefine WeaponDefine;

    public int damage;
    public bool isRange;//怪物在范围中
    public float speed;
    private float lastAttackTime;
    public float attackTime;//攻击间隔
    public bool canAim = true;
    public bool isCooling
    {
        get { return Time.time - lastAttackTime < attackTime; }
    }
    
    public bool canAttack
    {
        get { return isRange && !isCooling&&canAim; }
    }

    public UnityEngine.Transform enemy;//要攻击敌人
    private Vector3 originalPosition;
    private float originZ;//原始的Z轴
    public CapsuleCollider2D capsule;

    void Awake()
    {
        originZ = transform.eulerAngles.z;
        originalPosition = transform.localPosition;
        capsule = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //自动瞄准
        if(canAim) Aiming();

        //攻击
        if (canAttack) Fire();

    }

    void Aiming()
    {
        if (enemy != null)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
            if (distanceToEnemy <= WeaponDefine.range)
            {
                // 敌人还在范围内，继续瞄准它
                isRange = true;
                Vector2 enemyPos = enemy.position;
                Vector2 direction = enemyPos - (Vector2)transform.position;
                float angle = Vector2.SignedAngle(Vector2.right, direction);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, originZ + angle);
                return; 
            }
            else
            {
                // 敌人超出范围，清除目标
                enemy = null;
            }
        }

        Collider2D[] ememiesInRange = Physics2D.OverlapCircleAll(
            transform.position, WeaponDefine.range, LayerMask.GetMask("Enemy"));

        if (ememiesInRange.Length > 0)
        {
            isRange = true;

            //获取最近的敌人
            Collider2D nearestEnemy=ememiesInRange.OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).First();
            enemy = nearestEnemy.transform;

            Vector2 enemyPos = enemy.position;
            Vector2 direction = enemyPos - (Vector2)transform.position;

            float angle = Vector2.SignedAngle(Vector2.right, direction);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, originZ + angle);

        }

        else
        {
            isRange = false;
            enemy = null;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, originZ);
        }
    }

    void Fire()
    {
        if (isCooling)
        {
            return;
        }
        capsule.enabled = true;
        canAim = false;
        StartCoroutine(GoPosition());

        lastAttackTime = Time.time;
    }

    IEnumerator GoPosition()
    {
        if (enemy == null) yield break;

        while (true)
        {
            if (enemy == null)
            {
                // 敌人死了，直接返回原位
                capsule.enabled = false;
                StartCoroutine(ReturnPosition());
                yield break;
            }

            var enemyPosition = enemy.position + new Vector3(0, enemy.GetComponent<SpriteRenderer>().size.y / 2, 0);

            // 检查是否到达目标
            if (Vector2.Distance(transform.position, enemyPosition) <= 0.1f)
            {
                break; 
            }

            Vector3 moveDistance = (enemyPosition - transform.position).normalized * speed * Time.deltaTime;
            transform.position += moveDistance;
            yield return null;
        }
        yield return null;
        //关闭碰撞器
        capsule.enabled = false;
        StartCoroutine(ReturnPosition());
        
    }

    IEnumerator ReturnPosition()
    {
        while ((originalPosition- transform.localPosition).magnitude > 0.1f)
        {
            Vector3 direction = (originalPosition - transform.localPosition).normalized;
            transform.localPosition += direction * speed * Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
        //回到原点后可以进行瞄准
        canAim = true;
    }
}
