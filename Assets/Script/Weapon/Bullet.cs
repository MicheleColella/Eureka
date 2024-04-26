using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    [SerializeField] float DestroyTime;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyhealth.TakeDamage(Damage);
            //Debug.Log("Enemy");
        }
        Destroy(gameObject);
    }
}
