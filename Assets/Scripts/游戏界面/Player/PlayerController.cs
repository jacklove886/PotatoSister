using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }
    public float speed = 5f;
    public Animator anim;
    public Transform PlayerLocalScale;
    public float currentHp;
    public int maxHp =15;
    public float exp;
    public int money;
    public bool isDead { get { return currentHp <= 0; } }

    public static event System.Action PlayerHurt;
    public static event System.Action PlayerDead;

    private void Awake()
    {
        instance = this;
        currentHp = maxHp;
    }

    private void Update()
    {
        if (isDead) return;
        Move();
    }

    //ÒÆ¶¯
    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(h, v).normalized;

        transform.Translate(movement * speed * Time.deltaTime);
        TurnAround(h);

        if (movement.magnitude != 0)
        {
            anim.SetBool("isMove", true);
        }
    }

    //°ÚÍ·
    public void TurnAround(float h)
    {
        if (h == -1)
        {
            PlayerLocalScale.localScale = new Vector3(-1, PlayerLocalScale.localScale.y, PlayerLocalScale.localScale.z);
        }
        else if(h == 1)
        {
            PlayerLocalScale.localScale = new Vector3(1, PlayerLocalScale.localScale.y, PlayerLocalScale.localScale.z);
        }
    }

    public void Hurt(float damage)
    {
        if (isDead) return;
        currentHp -= damage;
        if (isDead)
        {
            Dead();
        }

        PlayerHurt?.Invoke();
    }

    public void Dead()
    {
        anim.speed = 0;
        GamePanel.Instance.LoseGame();
        PlayerDead?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            money++;
            GamePanel.Instance.UpdateMoney();
        }
    }
}
