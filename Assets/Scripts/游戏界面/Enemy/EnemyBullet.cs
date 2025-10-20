using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage=1f;
    public float deadTime=5f;
    public float speed;
    private float currentTime;
    public Vector2 dir;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= deadTime)
        {
            Destroy(this.gameObject);
        }
        transform.position += (Vector3)dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.Hurt(damage);
        }
    }
}
