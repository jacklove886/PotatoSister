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

    [Header("����")]
    public float lastAttackTime = 0;//������ʱ��
    public bool canAttack=> Time.time - lastAttackTime >= define.attackTime;//���Թ���
    public bool isContact = false;//���������

    [Header("����")]
    public float lastSkillTime = 0;//���ܼ�ʱ��
    public bool canSkill => Time.time - lastSkillTime >= define.skillTime&&define.skillTime>0;

    [Header("����")]

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
    }

    public virtual void Move()
    {
        Vector2 distance = PlayerController.Instance.transform.position-transform.position;
        Vector2 movement = new Vector2(distance.x, distance.y).normalized;
        transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, define .speed* Time.deltaTime);

        //������ұ�
        if (distance.x >= 0.1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //��������
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

        //�жϾ���
        float distance = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        if (distance <= define.range)
        {
            //��������
            Vector2 direction = (PlayerController.Instance.transform.position - transform.position).normalized;
            LaunchSkill(direction);
        }
    }

    //��������
    public virtual void LaunchSkill(Vector2 direction)
    {
        lastSkillTime = Time.time;
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
