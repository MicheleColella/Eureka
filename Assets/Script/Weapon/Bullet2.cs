using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public int Damage;
    public float checkRadius;
    public LayerMask checkLayers;

    [SerializeField] float DestroyTime;
    public bool haveDestroy;
    public bool haveExplosion;

    public GameObject ExplosionVFX;

    private void Start()
    {
        if (haveDestroy)
        {
            Destroy(gameObject, DestroyTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        foreach (Collider item in colliders)
        {
            if (item.tag == "Enemy")
            {
                EnemyHealth enemyhealth = item.gameObject.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(Damage);
            }
        }

        if (haveExplosion)
        {
            var Explosion = Instantiate(ExplosionVFX, transform.position, transform.rotation);
            Destroy(Explosion, 3.0f);
        }
        
        Destroy(gameObject);
        /*
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyhealth.TakeDamage(Damage);
            //Debug.Log("Enemy");
        }
        Destroy(gameObject);
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
