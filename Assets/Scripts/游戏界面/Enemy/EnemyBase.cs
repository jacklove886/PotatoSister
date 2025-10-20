using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    public EnemyDefine define;

    [Header("攻击")]
    public float lastAttackTime = 0;//攻击计时器
    public bool canAttack=> Time.time - lastAttackTime >= define.attackTime;//可以攻击
    public bool isContact = false;//触碰到玩家

    [Header("技能")]
    public float lastSkillTime = 0;//技能计时器
    public bool canSkill => Time.time - lastSkillTime >= define.skillTime&&define.skillTime>0;

    [Header("其他")]

    public GameObject money_Prefab;
    public Transform Items;

    private void Awake()
    {
        money_Prefab = Resources.Load<GameObject>("Prefabs/Money");
    }

    public void Init(EnemyDefine define)
    {
        this.define = new EnemyDefine
        {
            id = define.id,
            name = define.name,
            hp = define.hp,
            damage = define.damage,
            speed = define.speed,
            attackTime = define.attackTime,
            provideExp = define.provideExp,
            skillTime = define.skillTime,
            range = define.range
        };
    }

    private void Update()
    {
        Move();
        Attack();
        UpdateSkill();
    }

    public virtual void Move()
    {
        Vector2 distance = PlayerController.Instance.transform.position-transform.position;
        Vector2 movement = new Vector2(distance.x, distance.y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, define .speed* Time.deltaTime);

        //玩家在右边
        if (distance.x >= 0.1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //玩家在左边
        if (distance.x < -0.1)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    public void Attack()
    {
        if (canAttack&&isContact)
        {
            lastAttackTime = Time.time;
            PlayerController.Instance.Hurt(define.damage);
        }
    }

    private void UpdateSkill()
    {
        if (!canSkill) return;

        //判断距离
        float distance = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        if (distance <= define.range)
        {
            //发动技能
            Vector2 direction = (PlayerController.Instance.transform.position - transform.position).normalized;   
            LaunchSkill(direction);
            lastSkillTime = Time.time;
        }
    }

    //发动技能
    protected virtual void LaunchSkill(Vector2 direction)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isContact = true;
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isContact = false;
        }
    }

    public void Hurt(float damage)
    {
        if (define.hp <= damage)
        {
            define.hp = 0;
            Dead();
        }
        else
        {
            define.hp -= damage;
        }      
    }

    public void Dead()
    {
        PlayerController.Instance.exp += define.provideExp;
        GamePanel.Instance.UpdateExp();
        GameObject go=GameObject.Instantiate(money_Prefab, Items);
        go.transform.position = this.transform.position;

        Destroy(this.gameObject);    
    }

}
